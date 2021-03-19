using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper.Models
{
    /// <summary>
    /// pritunl user
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// The authtype of the user
        /// </summary>
        [JsonProperty("auth_type")]
        public AuthType AuthType { get; set; }
        /// <summary>
        /// the dns servers
        /// </summary>
        [JsonProperty("dns_servers")]
        public object DnsServers { get; set; }
        /// <summary>
        /// users pin
        /// </summary>
        [JsonProperty("pin")]
        public bool Pin { get; set; }
        /// <summary>
        /// the dns suffix
        /// </summary>
        [JsonProperty("dns_suffix")]
        public object DnsSuffix { get; set; }
        /// <summary>
        /// the servers the user is on
        /// </summary>
        [JsonProperty("servers")]
        public List<Server> Servers { get; set; }
        /// <summary>
        /// whether the user is disabled or not
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }
        /// <summary>
        /// the links of the user
        /// </summary>
        [JsonProperty("network_links")]
        public List<object> NetworkLinks { get; set; }
        /// <summary>
        /// what ports the user has forwarded
        /// </summary>
        [JsonProperty("port_forwarding")]
        public List<object> PortForwarding { get; set; }
        /// <summary>
        /// the id of the user
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// the <see cref="Organization"/> name the user is in 
        /// </summary>
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }
        /// <summary>
        /// the type of the user
        /// </summary>
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// the email of the user
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// the status of the user
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }
        /// <summary>
        /// dns mapping
        /// </summary>
        [JsonProperty("dns_mapping")]
        public object DnsMapping { get; set; }
        /// <summary>
        /// the otp secret
        /// </summary>
        [JsonProperty("otp_secret")]
        public string OtpSecret { get; set; }
        /// <summary>
        /// whether clientotclient is on
        /// </summary>
        [JsonProperty("client_to_client")]
        public bool ClientToClient { get; set; }
        /// <summary>
        /// the macaddresses
        /// </summary>
        [JsonProperty("mac_addresses")]
        public object MacAddresses { get; set; }
        /// <summary>
        /// the yubico id
        /// </summary>
        [JsonProperty("yubico_id")]
        public object YubicoId { get; set; }
        /// <summary>
        /// sso
        /// </summary>
        [JsonProperty("sso")]
        public object Sso { get; set; }
        /// <summary>
        /// whether the user bypasses the secondary authentication
        /// </summary>
        [JsonProperty("bypass_secondary")]
        public bool BypassSecondary { get; set; }
        /// <summary>
        /// the groups the user is in
        /// </summary>
        [JsonProperty("groups")]
        public List<object> Groups { get; set; }
        /// <summary>
        /// the audit 
        /// </summary>
        [JsonProperty("audit")]
        public bool Audit { get; set; }
        /// <summary>
        /// the name of the user
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// does the user use gravatar?
        /// </summary>
        [JsonProperty("gravatar")]
        public bool Gravatar { get; set; }
        /// <summary>
        /// whether the otp auth is on
        /// </summary>
        [JsonProperty("otp_auth")]
        public bool OtpAuth { get; set; }
    }
    /// <summary>
    /// The servers the user can connect to
    /// </summary>
    public partial class UserServer
    {
        /// <summary>
        /// ths status of the server
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; set; }
        /// <summary>
        /// the platform
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }
        /// <summary>
        /// the server id
        /// </summary>
        [JsonProperty("server_id")]
        public string ServerId { get; set; }
        /// <summary>
        /// the virtual ipv6 addresses
        /// </summary>
        [JsonProperty("virt_address6")]
        public string VirtAddress6 { get; set; }
        /// <summary>
        ///  the virtual addresses
        /// </summary>
        [JsonProperty("virt_address")]
        public string VirtAddress { get; set; }
        /// <summary>
        /// the name of the server
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the real address of the user
        /// </summary>
        [JsonProperty("real_address")]
        public string RealAddress { get; set; }
        /// <summary>
        /// how long the server has been connected since
        /// </summary>
        [JsonProperty("connected_since")]
        public long? ConnectedSince { get; set; }
        /// <summary>
        /// the id 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// the name of the device
        /// </summary>
        [JsonProperty("device_name")]
        public string DeviceName { get; set; }
    }

    /// <summary>
    /// ok for real fuck doing them all i do NOT have the time needed to do it for all 15 or so auth tyoes ill come back and do them at a later date 
    /// </summary>
    public enum AuthType { Local, Duo, Azure };
    /// <summary>
    /// the types
    /// </summary>
    public enum TypeEnum { Client, Server };
}
