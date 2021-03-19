using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pritunl.Wrapper.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServers
    {
        /// <summary>
        /// Gets a server from the pritunl server by name
        /// </summary>
        /// <param name="name">The name of the pritunl server</param>
        /// <returns>The named server</returns>
        /// <exception cref="PritunlException"></exception>
        Task<Server> GetServerAsync(string name);
        /// <summary>
        /// Gets the servers on the pritunl server
        /// </summary>
        /// <returns>The list of servers</returns>
        Task<List<Server>> GetServersAsync();
    }
}