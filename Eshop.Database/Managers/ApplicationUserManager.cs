using Eshop.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Errors = Eshop.Database.Helpers.ApplicationUserManagerErrors;

namespace Eshop.Database.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        /// <summary>
        /// Creates asynchronously a User and adds to him the given roles.
        /// </summary>
        /// <param name="user">The <see cref="ApplicationUser"/> to be created.</param>
        /// <param name="roles">The given roles in form of: <see cref="IEnumerable{T}"/> where <see cref="{T}"/> is type of <see cref="string"/>.</param>
        /// <param name="password">The <see cref="string"/> password to create the user.</param>
        /// <returns><see cref="IdentityResult"/> where <see cref="IdentityResult.Succeeded"/> is false if could not create user
        /// or is true if user created succesfully with roles.</returns>
        public async Task<IdentityResult> CreateUserWithRolesAsync(ApplicationUser user, IEnumerable<string> roles, string password = null)
        {
            var existingUser = await this.FindByEmailAsync(user.Email);

            if (existingUser != null)
                return IdentityResult.Failed(Errors.UserAlreadyExists);

            IdentityResult response;

            if (string.IsNullOrEmpty(password))
                response = await this.CreateAsync(user);
            else
                response = await this.CreateAsync(user, password);

            if (!response.Succeeded)
                return response;

            return await this.AddToRolesAsync(user, roles);
        }

        /// <summary>
        /// Finds asynchrosously a User by username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>An <see cref="ApplicationUser"/> if found else null or default.</returns>
        public async Task<ApplicationUser> FindUserByNameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return default;

            return await this.FindByNameAsync(username);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
            => Users.ToList();
    }
}