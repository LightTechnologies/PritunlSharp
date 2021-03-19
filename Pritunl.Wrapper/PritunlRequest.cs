using Newtonsoft.Json;
using Pritunl.Wrapper.Exceptions;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pritunl.Wrapper
{
    internal class PritunlRequest
    {
        private readonly static HttpClient _client;
        private static readonly Random random = new Random();
        static PritunlRequest()
        {
            if (string.IsNullOrWhiteSpace(APICredentials.APISecret))
                throw new ArgumentException("APISecret has to be set", "APISecret");
            if (string.IsNullOrWhiteSpace(APICredentials.APIUrl))
                throw new ArgumentException("APIUrl has to be set", "APIUrl");
            if (string.IsNullOrWhiteSpace(APICredentials.APIToken))
                throw new ArgumentException("APIToken has to be set", "APIToken");
            if (_client == null)
            {
                var handler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (a, b, c, d) => true };
                _client ??= new HttpClient(handler);
                _client.BaseAddress = new Uri(APICredentials.APIUrl + "/api");
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Auth-Token", APICredentials.APIToken);
            }
        }
        public static async Task<T> GetAsync<T>(string endpoint)
        {
            GenerateHeaders(endpoint, "get");
            var resp = await _client.GetAsync(endpoint);

            return await HandleReturn<T>(resp);
        }
        public static async Task<T> PostAsync<T>(string endpoint, object obj)
        {
            GenerateHeaders(endpoint, "post");
            var resp = await _client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            return await HandleReturn<T>(resp);
        }
        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            GenerateHeaders(endpoint, "delete");
            var resp = await _client.DeleteAsync(endpoint);
            
            return await HandleReturn<T>(resp);
        }
        private static async Task<T> HandleReturn<T>(HttpResponseMessage resp)
        {
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new PritunlException("Endpoint not found");
            else if (resp.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new PritunlException("Unauthorized Check your api token and secret");
            else if (!resp.IsSuccessStatusCode)
                throw new PritunlException("Couldn't make request");

            if (typeof(T) == typeof(byte[]))
            {
                object retobj = await resp.Content.ReadAsByteArrayAsync();
                return (T)retobj;
            }
            if(typeof(T) == typeof(bool))
            {
                object retobj = resp.IsSuccessStatusCode;
                return (T)retobj;
            }
            if (typeof(T) == typeof(string))
            {
                object retobj = await resp.Content.ReadAsStringAsync();
                return (T)retobj;
            }
            return JsonConvert.DeserializeObject<T>(await resp.Content.ReadAsStringAsync());
        }
        private static void GenerateHeaders(string endpoint, string method)
        {
            if (_client.DefaultRequestHeaders.Contains("Auth-Nonce"))
                _client.DefaultRequestHeaders.Remove("Auth-Nonce");
            if (_client.DefaultRequestHeaders.Contains("Auth-Signature"))
                _client.DefaultRequestHeaders.Remove("Auth-Signature");
            if (_client.DefaultRequestHeaders.Contains("Auth-Timestamp"))
                _client.DefaultRequestHeaders.Remove("Auth-Timestamp");

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var nonce = RandomString(32);
            var sigstring = $"{APICredentials.APIToken}&{timestamp}&{nonce}&{method.ToUpper()}&/{endpoint}";
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Auth-Nonce", nonce);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Auth-Timestamp", timestamp);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Auth-Signature", CreateToken(sigstring, APICredentials.APISecret));
        }
        private static string CreateToken(string message, string secret)
        {
            secret ??= "";
            var encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
