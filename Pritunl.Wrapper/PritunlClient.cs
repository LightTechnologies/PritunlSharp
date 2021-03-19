using Pritunl.Wrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pritunl.Wrapper
{
    /// <summary>
    /// Wraps the classes around pritunl for easy access 
    /// </summary>
    public class PritunlClient
    {
        /// <summary>
        /// The user wrapper
        /// </summary>
        public IUsers Users { get; private set; }
        /// <summary>
        /// The server wrapper
        /// </summary>
        public IServers Servers { get; private set; }
        /// <summary>
        /// The organization wrapper
        /// </summary>
        public IOrganizations Organizations { get; private set; }
        /// <summary>
        /// Only use this if you need access to an endpoint if you need to access an endpoint that I have not made a wrapper around
        /// </summary>
        public IPritunlRequest PritunlRequester { get; private set; }
        /// <summary>
        /// Makes the wrapper for pritunl with all the required data
        /// </summary>
        /// <param name="apiurl"> The url of the server</param>
        /// <param name="apitoken">The token of the api user</param>
        /// <param name="apisecret">The secret of the api user</param>
        /// <remarks>Had to redo it without statics because khrysus yelled at me for making it with statics because he couldnt add it to the di container</remarks>
        public PritunlClient(string apiurl, string apitoken, string apisecret)
        {
            PritunlRequester = new PritunlRequest(apiurl, apitoken, apisecret);
            Organizations = new Organizations(PritunlRequester);
            Servers = new Servers(PritunlRequester);
            Users = new Users(PritunlRequester, Organizations);
        }
    }
}
