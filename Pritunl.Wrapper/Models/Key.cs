using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper.Models
{
    internal partial class Key
    {
        [JsonProperty("view_url")]
        public string ViewUrl { get; set; }

        [JsonProperty("key_url")]
        public string KeyUrl { get; set; }

        [JsonProperty("uri_url")]
        public string UriUrl { get; set; }

        [JsonProperty("key_zip_url")]
        public string KeyZipUrl { get; set; }

        [JsonProperty("key_onc_url")]
        public string KeyOncUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
