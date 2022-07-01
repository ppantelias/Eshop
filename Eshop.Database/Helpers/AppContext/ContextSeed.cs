using Eshop.Database.Helpers.AppStart;
using Eshop.Database.Managers;
using Eshop.Domain.Enums;
using Eshop.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Eshop.Database.Helpers.AppContext
{
    public static class ContextSeed
    {
        /// <summary>
        /// Seeds asynchronous all roles from Roles domain enum model into database.
        /// </summary>
        /// <param name="roleManager"><see cref="RoleManager{TRole}"/> where TRole of type <see cref="ApplicationRole"/>.</param>
        /// <returns></returns>
        public static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            foreach (string userRole in GetAllRoles())
            {
                var roleExists = await roleManager.RoleExistsAsync(userRole);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new ApplicationRole(userRole));
                }
            }
        }

        /// <summary>
        /// Seeds asynchronous FullAdmin into database. FullAmin takes all roles from enum domain model.
        /// FullAdmin details ara dynamically read by appsettings.json file with form:
        /// "SeedFullAdmin": {
        ///     "UserName": "UserName",
        ///     "Lastname": "Lastname",
        ///     "Firstname": "Firstname",
        ///     "Email": "Email",
        ///     "Password": "Password"
        /// }
        /// </summary>
        /// <param name="userManager"><see cref="UserManager{TUser}"/> where <see cref="{TUser}"/> of type <see cref="ApplicationUser"/>.</param>
        /// <param name="roleManager"><see cref="RoleManager{TRole}"/> where <see cref="{TRole}"/> of type <see cref="ApplicationRole"/>.</param>
        /// <param name="configuration"><see cref="ConfigurationManager"/>.</param>
        /// <returns></returns>
        public static async Task SeedFullAdminAsync(ApplicationUserManager userManager, RoleManager<ApplicationRole> roleManager, ConfigurationManager configuration)
        {
            var userId = Guid.NewGuid();

            if (userManager.Users.All(u => u.Id == userId))
                return;

            var seedFullAdminSection = configuration.GetSection(nameof(AppSettings.SeedFullAdmin));
            var email = seedFullAdminSection.GetSection(nameof(AppSettings.SeedFullAdmin.Email)).Value;
            var user = await userManager.FindByEmailAsync(email);

            if (user != null)
                return;

            var defaultUser = seedFullAdminSection.BuildApplicationUserFromAppSettings(email, userId);

            var password = seedFullAdminSection.GetSection(nameof(AppSettings.SeedFullAdmin.Password)).Value;

            await userManager.CreateUserWithRolesAsync(defaultUser, GetAllRoles(), password);
        }

        private static ApplicationUser BuildApplicationUserFromAppSettings(this IConfigurationSection seedFullAdminSection, string email, Guid userId)
        {
            var userName = seedFullAdminSection.GetSection(nameof(AppSettings.SeedFullAdmin.UserName)).Value;
            var firstName = seedFullAdminSection.GetSection(nameof(AppSettings.SeedFullAdmin.Firstname)).Value;
            var lastName = seedFullAdminSection.GetSection(nameof(AppSettings.SeedFullAdmin.Lastname)).Value;

            return new ApplicationUser
            {
                Id = userId,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false
            };
        }

        private static IEnumerable<string> GetAllRoles()
            => Enum.GetNames(typeof(UserRole));
    }
}