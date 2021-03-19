using System.Threading.Tasks;

namespace Pritunl.Wrapper
{
    /// <summary>
    /// If you end up using this please make a fork and add what you used it for in the fork and make a pull request
    /// </summary>
    public interface IPritunlRequest
    {
        /// <summary>
        /// Makes an authorized delete request to pritunl
        /// </summary>
        /// <typeparam name="T">The type to deserialize supports classes structs string bool and byte[]</typeparam>
        /// <param name="endpoint">the endpoint like user</param>
        /// <returns></returns>
        Task<T> DeleteAsync<T>(string endpoint);
        /// <summary>
        /// Makes an authorized get request to pritunl
        /// </summary>
        /// <typeparam name="T">The type to deserialize supports classes structs string bool and byte[]</typeparam>
        /// <param name="endpoint">the endpoint like server</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string endpoint);
        /// <summary>
        /// makes an authorized post request to pritunl
        /// </summary>
        /// <typeparam name="T">The type to deserialize supports classes structs string bool and byte[]</typeparam>
        /// <param name="endpoint"></param>
        /// <param name="obj">anything you want to pass in to the request</param>
        Task<T> PostAsync<T>(string endpoint, object obj);
    }
}