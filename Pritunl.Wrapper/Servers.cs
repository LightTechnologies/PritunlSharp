using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritunl.Wrapper
{
    public static class Servers
    {
        /// <summary>
        /// Gets the servers on the pritunl server
        /// </summary>
        /// <returns>The list of servers</returns>
        public static async Task<List<Server>> GetServersAsync()
        {
            return await PritunlRequest.GetAsync<List<Server>>("server");
        }
        /// <summary>
        /// Gets a server from the pritunl server by name
        /// </summary>
        /// <param name="name">The name of the pritunl server</param>
        /// <returns>The named server</returns>
        /// <exception cref="PritunlException"></exception>
        public static async Task<Server> GetServerAsync(string name)
        {
            var servers = await GetServersAsync();

            if (!servers.Any(x => x.Name == name))
                throw new PritunlException("Couldn't find the organization");

            return servers.First(x => x.Name == name);
        }
    }
}
