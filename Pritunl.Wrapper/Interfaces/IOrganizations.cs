using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pritunl.Wrapper.Interfaces
{
    /// <summary>
    /// Organization
    /// </summary>
    public interface IOrganizations
    {
        /// <summary>
        /// Gets a single organization by name throws a pritunl exception if it couldn't find the organization
        /// </summary>
        /// <param name="name">The name of the organization</param>
        /// <returns>The named organization</returns>
        /// <exception cref="PritunlException"></exception>
        Task<Organization> GetOrganization(string name);
        /// <summary>
        /// Gets a list of the organizations on the pritunl server
        /// </summary>
        /// <returns>List of Organizations</returns>
        Task<List<Organization>> GetOrganizations();
    }
}