using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Interfaces;
using Pritunl.Wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritunl.Wrapper
{
    /// <summary>
    /// Servers class dont use directly
    /// </summary>
    public class Servers : IServers
    {
        private readonly IPritunlRequest _request;

        internal Servers(IPritunlRequest request)
        {
            _request = request;
        }

        /// <summary>
        /// Gets the servers on the pritunl server
        /// </summary>
        /// <returns>The list of servers</returns>
        public async Task<List<Server>> GetServersAsync()
        {
            return await _request.GetAsync<List<Server>>("server");
        }
        /// <summary>
        /// Gets a server from the pritunl server by name
        /// </summary>
        /// <param name="name">The name of the pritunl server</param>
        /// <returns>The named server</returns>
        /// <exception cref="PritunlException"></exception>
        public async Task<Server> GetServerAsync(string name)
        {
            var servers = await GetServersAsync();

            if (!servers.Any(x => x.Name == name))
                throw new PritunlException("Couldn't find the organization");

            return servers.First(x => x.Name == name);
        }
    }
}
