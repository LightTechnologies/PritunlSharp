using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper.Models
{
    /// <summary>
    /// organizations
    /// </summary>
    public partial class Organization
    {
        /// <summary>
        /// The auth api
        /// </summary>
        [JsonProperty("auth_api")]
        public bool AuthApi { get; set; }
        /// <summary>
        /// The name of the <see cref="Organization"></see>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the auth token
        /// </summary>
        [JsonProperty("auth_token")]
        public object AuthToken { get; set; }
        /// <summary>
        /// the users in the <see cref="Organization"/>
        /// </summary>
        [JsonProperty("user_count")]
        public long UserCount { get; set; }
        /// <summary>
        /// auth secret
        /// </summary>
        [JsonProperty("auth_secret")]
        public object AuthSecret { get; set; }
        /// <summary>
        /// the id of the <see cref="Organization"/>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
