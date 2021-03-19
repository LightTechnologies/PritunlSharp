using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;

namespace Pritunl.Wrapper
{
    public static class Users
    {
        /// <summary>
        /// Gets a list of users from the organization
        /// </summary>
        /// <param name="organization">The organization to fetch users from</param>
        /// <returns>List of users in the org</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization</remarks>
        public static async Task<List<User>> GetUsersAsync(string organization)
        {
            var org = await Organizations.GetOrganization(organization);

            return await PritunlRequest.GetAsync<List<User>>($"user/{org.Id}");
        }/// <summary>
         /// Gets a user from the organization
         /// </summary>
         /// <param name="organization">The organization to fetch users from</param>
         /// <param name="name">The name of the user to fetch</param>
         /// <returns>The named user</returns>
         /// <exception cref="PritunlException"></exception>
         /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        public static async Task<User> GetUserAsync(string organization, string name)
        {
            var users = await GetUsersAsync(organization);

            if (!users.Any(x => x.Name == name))
                throw new PritunlException("Couldn't find the user");

            return users.First(x => x.Name == name);
        }
        /// <summary>
        /// Creates a user on the pritunl server
        /// </summary>
        /// <param name="organization">the organization to create the user in</param>
        /// <param name="name">the name of the user to create </param>
        /// <param name="email">the email of the user to create</param>
        /// <param name="disabled">whether the user will disabled on creation</param>
        /// <returns>The created user</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization</remarks>
        public static async Task<User> CreateUser(string organization, string name, string email = null, bool disabled = false)
        {
            var org = await Organizations.GetOrganization(organization);
            return (await PritunlRequest.PostAsync<List<User>>($"user/{org.Id}", new { name, email, disabled })).First();
        }
        /// <summary>
        /// Deletes a user on the pritunl server
        /// </summary>
        /// <param name="organization">the organization to delete the user from</param>
        /// <param name="name">the name of the user to delete</param>
        /// <returns>A bool on whether the user was deleted or not</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        public static async Task<bool> DeleteUser(string organization, string name)
        {
            var org = await Organizations.GetOrganization(organization);
            var user = await GetUserAsync(organization, name);
            return await PritunlRequest.DeleteAsync<bool>($"user/{org.Id}/{user.Id}");
        }
        /// <summary>
        /// Gets an archive of the users openvpn configs
        /// </summary>
        /// <param name="organization">the organization to fetch configs from</param>
        /// <param name="name">the name of the user to fetch configs from</param>
        /// <param name="type">the archive type the config should be in</param>
        /// <returns>A byte array of the config data</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        public static async Task<byte[]> GetKeys(string organization, string name, KeyType type)
        {
            var org = await Organizations.GetOrganization(organization);
            var user = await GetUserAsync(organization, name);
            var key =  await PritunlRequest.GetAsync<Key>($"key/{org.Id}/{user.Id}");

            switch (type)
            {
                case KeyType.Tar:
                    return await PritunlRequest.GetAsync<byte[]>(key.KeyUrl);
                    
                case KeyType.Zip:
                    return await PritunlRequest.GetAsync<byte[]>(key.KeyZipUrl);

                case KeyType.Onc:
                    return await PritunlRequest.GetAsync<byte[]>(key.KeyOncUrl);

                default:
                    return null;
            }
        }
        public enum KeyType
        { 
            Tar,
            Zip,
            Onc
        }
    }
}
