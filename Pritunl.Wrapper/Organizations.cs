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
    /// dont use directly
    /// </summary>
    public class Organizations : IOrganizations
    {
        private readonly IPritunlRequest _request;

        internal Organizations(IPritunlRequest request)
        {
            _request = request;
        }

        /// <summary>
        /// Gets a list of the organizations on the pritunl server
        /// </summary>
        /// <returns>List of Organizations</returns>
        public async Task<List<Organization>> GetOrganizations()
        {
            return await _request.GetAsync<List<Organization>>("organization");
        }
        /// <summary>
        /// Gets a single organization by name throws a pritunl exception if it couldn't find the organization
        /// </summary>
        /// <param name="name">The name of the organization</param>
        /// <returns>The named organization</returns>
        /// <exception cref="PritunlException"></exception>
        public async Task<Organization> GetOrganization(string name)
        {
            var orgs = await GetOrganizations();

            if (!orgs.Any(x => x.Name == name))
                throw new PritunlException("Couldn't find the organization");

            return orgs.First(x => x.Name == name);
        }
    }
}