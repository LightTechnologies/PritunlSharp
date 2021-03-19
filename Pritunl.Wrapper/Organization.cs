using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pritunl.Wrapper
{
    public static class Organizations
    {
        /// <summary>
        /// Gets a list of the organizations on the pritunl server
        /// </summary>
        /// <returns>List of Organizations</returns>
        public static async Task<List<Organization>> GetOrganizations()
        {
            return await PritunlRequest.GetAsync<List<Organization>>("organization");
        }
        /// <summary>
        /// Gets a single organization by name throws a pritunl exception if it couldn't find the organization
        /// </summary>
        /// <param name="name">The name of the organization</param>
        /// <returns>The named organization</returns>
        /// <exception cref="PritunlException"></exception>
        public static async Task<Organization> GetOrganization(string name)
        {
            var orgs = await GetOrganizations();

            if (!orgs.Any(x => x.Name == name))
                throw new PritunlException("Couldn't find the organization");

            return orgs.First(x => x.Name == name);
        }
    }
}