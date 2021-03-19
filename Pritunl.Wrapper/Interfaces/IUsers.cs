using Pritunl.Wrapper.Exceptions;
using Pritunl.Wrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pritunl.Wrapper.Interfaces
{
    /// <summary>
    /// The users interface 
    /// </summary>
    public interface IUsers
    {
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
        Task<User> CreateUser(string organization, string name, string email = null, bool disabled = false);
        /// <summary>
        /// Deletes a user on the pritunl server
        /// </summary>
        /// <param name="organization">the organization to delete the user from</param>
        /// <param name="name">the name of the user to delete</param>
        /// <returns>A bool on whether the user was deleted or not</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        Task<bool> DeleteUser(string organization, string name);
          /// <summary>
        /// Gets an archive of the users openvpn configs
        /// </summary>
        /// <param name="organization">the organization to fetch configs from</param>
        /// <param name="name">the name of the user to fetch configs from</param>
        /// <param name="type">the archive type the config should be in</param>
        /// <returns>A byte array of the config data</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        Task<byte[]> GetKeys(string organization, string name, Users.KeyType type);
        /// <summary>
        /// Gets a user from the organization
        /// </summary>
        /// <param name="organization">The organization to fetch users from</param>
        /// <param name="name">The name of the user to fetch</param>
        /// <returns>The named user</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization or the user</remarks>
        Task<User> GetUserAsync(string organization, string name);
        /// <summary>
        /// Gets a list of users from the organization
        /// </summary>
        /// <param name="organization">The organization to fetch users from</param>
        /// <returns>List of users in the org</returns>
        /// <exception cref="PritunlException"></exception>
        /// <remarks>Throws a <see cref="PritunlException"/> if it could't find the organization</remarks>
        Task<List<User>> GetUsersAsync(string organization);
    }
}