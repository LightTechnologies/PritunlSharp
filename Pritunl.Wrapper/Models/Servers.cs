using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper.Models
{
    /// <summary>
    /// pritunl server
    /// </summary>
    public partial class Server
    {
        /// <summary>
        /// the wireguard port
        /// </summary>
        [JsonProperty("port_wg")]
        public int? PortWg { get; set; }
        /// <summary>
        /// list of dnsservers
        /// </summary>
        [JsonProperty("dns_servers")]
        public List<string> DnsServers { get; set; }

        /// <summary>
        /// the protocol the server is listening on
        /// </summary>
        [JsonProperty("protocol")]
        public Protocol Protocol { get; set; }
        /// <summary>
        /// the max devices the server will allow one user to user
        /// </summary>
        [JsonProperty("max_devices")]
        public long MaxDevices { get; set; }
        /// <summary>
        /// the max clients the server will allow to connect
        /// </summary>
        [JsonProperty("max_clients")]
        public long MaxClients { get; set; }
        /// <summary>
        /// the timeout on link ping
        /// </summary>
        [JsonProperty("link_ping_timeout")]
        public long LinkPingTimeout { get; set; }
        /// <summary>
        /// the timeout on ping
        /// </summary>
        [JsonProperty("ping_timeout")]
        public long PingTimeout { get; set; }
        /// <summary>
        /// whether the server uses ipv6 or not
        /// </summary>
        [JsonProperty("ipv6")]
        public bool Ipv6 { get; set; }
        /// <summary>
        /// whether vxlan is enabled on the server
        /// </summary>
        [JsonProperty("vxlan")]
        public bool Vxlan { get; set; }
        /// <summary>
        /// the mode the server is on
        /// </summary>
        [JsonProperty("network_mode")]
        public NetworkMode NetworkMode { get; set; }
        /// <summary>
        /// the address the server is listening on 
        /// </summary>
        [JsonProperty("bind_address")]
        public string BindAddress { get; set; }
        /// <summary>
        /// whether the server configs block outside dns. Should be enabled as it prevents dns leaking
        /// </summary>
        [JsonProperty("block_outside_dns")]
        public bool BlockOutsideDns { get; set; }
        /// <summary>
        /// i dont even know what this is im not even going to pretend like i do
        /// </summary>
        [JsonProperty("network_start")]
        public string NetworkStart { get; set; }
        /// <summary>
        /// the name of the server
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the interval the server will ping the client o see if its alive
        /// </summary>
        [JsonProperty("ping_interval")]
        public long PingInterval { get; set; }
        /// <summary>
        /// devices allowed to connect
        /// </summary>
        [JsonProperty("allowed_devices")]
        public object AllowedDevices { get; set; }
        /// <summary>
        /// the users connected to the server
        /// </summary>
        [JsonProperty("users_online")]
        public long UsersOnline { get; set; }
        /// <summary>
        /// whether the server has the ipv6 firewall enabled
        /// </summary>
        [JsonProperty("ipv6_firewall")]
        public bool Ipv6Firewall { get; set; }
        /// <summary>
        /// the timeout of the sessions
        /// </summary>
        [JsonProperty("session_timeout")]
        public object SessionTimeout { get; set; }
        /// <summary>
        /// whether otpauth is on on the server
        /// </summary>
        [JsonProperty("otp_auth")]
        public bool OtpAuth { get; set; }
        /// <summary>
        /// whether the server will allow people to connect with the amount of devices set in the <see cref="MaxDevices"/>
        /// </summary>
        [JsonProperty("multi_device")]
        public bool MultiDevice { get; set; }
        /// <summary>
        /// the search domain
        /// </summary>
        [JsonProperty("search_domain")]
        public object SearchDomain { get; set; }

        /// <summary>
        /// whether compresion is enabled on the server. Recommended to keep off ad the voracle attack uses it
        /// </summary>
        [JsonProperty("lzo_compression")]
        public bool LzoCompression { get; set; }
        /// <summary>
        /// preconnect message
        /// </summary>
        [JsonProperty("pre_connect_msg")]
        public object PreConnectMsg { get; set; }
        /// <summary>
        /// the timeout for people who are inactive
        /// </summary>
        [JsonProperty("inactive_timeout")]
        public object InactiveTimeout { get; set; }
        /// <summary>
        /// the interval at what linkping will happen
        /// </summary>
        [JsonProperty("link_ping_interval")]
        public long LinkPingInterval { get; set; }
        /// <summary>
        /// the id of server
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// the timeout on the wireguard ping timeout
        /// </summary>
        [JsonProperty("ping_timeout_wg")]
        public long PingTimeoutWg { get; set; }
        /// <summary>
        /// how long the server has been up in seconds
        /// </summary>
        [JsonProperty("uptime")]
        public long? Uptime { get; set; }
        /// <summary>
        /// i dont even know
        /// </summary>
        [JsonProperty("network_end")]
        public string NetworkEnd { get; set; }
        /// <summary>
        /// again i dont even know
        /// </summary>
        [JsonProperty("network")]
        public string Network { get; set; }
        /// <summary>
        /// the amount of bits the duffie huffman key has
        /// </summary>
        [JsonProperty("dh_param_bits")]
        public long DhParamBits { get; set; }
        /// <summary>
        /// whether the server has wireguard enabled
        /// </summary>
        [JsonProperty("wg")]
        public bool Wg { get; set; }
        /// <summary>
        /// the port the server is listening on for connections via openvpn
        /// </summary>
        [JsonProperty("port")]
        public long Port { get; set; }
        /// <summary>
        /// the amount of devices online on the server
        /// </summary>
        [JsonProperty("devices_online")]
        public long DevicesOnline { get; set; }
        /// <summary>
        /// again im guessing its the subnet of the server no clue will figure out later
        /// </summary>
        [JsonProperty("network_wg")]
        public object NetworkWg { get; set; }
        /// <summary>
        /// the <see cref="Status"/> of the server
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }
        /// <summary>
        /// whetehr the server dnsmaps
        /// </summary>
        [JsonProperty("dns_mapping")]
        public bool DnsMapping { get; set; }
        /// <summary>
        /// what hashing algo the server uses
        /// </summary>
        [JsonProperty("hash")]
        public Hash Hash { get; set; }
        /// <summary>
        /// whether the server is in debug
        /// </summary>
        [JsonProperty("debug")]
        public bool Debug { get; set; }
        /// <summary>
        /// whether the server restricts routes
        /// </summary>
        [JsonProperty("restrict_routes")]
        public bool RestrictRoutes { get; set; }
        /// <summary>
        /// the amount of servers assigned to the server
        /// </summary>
        [JsonProperty("user_count")]
        public long UserCount { get; set; }
        /// <summary>
        /// list of groups on the server
        /// </summary>
        [JsonProperty("groups")]
        public List<object> Groups { get; set; }
        /// <summary>
        /// whether the server has interclient on or not
        /// </summary>
        [JsonProperty("inter_client")]
        public bool InterClient { get; set; }
        /// <summary>
        /// how many servers the server will replicate on to
        /// </summary>
        [JsonProperty("replica_count")]
        public long ReplicaCount { get; set; }
        /// <summary>
        /// what cipher the server uses
        /// </summary>
        [JsonProperty("cipher")]
        public Cipher Cipher { get; set; }
        /// <summary>
        /// i dont know
        /// </summary>
        [JsonProperty("mss_fix")]
        public object MssFix { get; set; }
        /// <summary>
        /// jumbo_frames idk
        /// </summary>
        [JsonProperty("jumbo_frames")]
        public bool JumboFrames { get; set; }
    }
    /// <summary>
    /// CIphers
    /// </summary>
    public enum Cipher { Blowfish128, Blowfish256, Aes128, Aes192, Aes256 };
    /// <summary>
    /// Hashes
    /// </summary>
    public enum Hash { MD5, SHA1, SHA256, SHA12 };
    /// <summary>
    /// NetworkModes
    /// </summary>
    public enum NetworkMode { Tunnel, Bridge };
    /// <summary>
    /// Protocols
    /// </summary>
    public enum Protocol { Udp, Tcp };
    /// <summary>
    /// The status of the server
    /// </summary>
    public enum Status { Online, Offline };
}
