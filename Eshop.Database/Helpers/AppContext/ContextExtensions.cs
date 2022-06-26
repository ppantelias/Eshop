using Eshop.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eshop.Database.Helpers.AppContext
{
    public static class ContextExtensions
    {

        private static readonly List<Action<IMutableEntityType>> _conventions = new();

        public static void AddRemovePluralizeConvention()
        {
            _conventions.Add(et => et.SetTableName(et.DisplayName()));
        }

        public static void AddRemoveCascadeConvention()
        {
            _conventions.Add(et => et.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.NoAction));
        }

        public static void ApplyConventions(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (Action<IMutableEntityType> action in _conventions)
                    action(entityType);
            }

            _conventions.Clear();
        }

        public static void AddIdentityDbConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbi");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles", "dbi");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims", "dbi");
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins", "dbi");
            modelBuilder.Entity<ApplicationUserToken>().ToTable("UserTokens", "dbi");
            modelBuilder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims", "dbi");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRoles", "dbi");

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }
    }
}