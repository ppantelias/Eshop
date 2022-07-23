using Eshop.Database.Helpers.AppContext;
using Eshop.Database.Interceptors;
using Eshop.Domain.Models;
using Eshop.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eshop.Database.ApplicationDb
{
    public class ApplicationDbContext :
        IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        private readonly BaseEntitySaveChangesInterceptor _baseEntitySaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            BaseEntitySaveChangesInterceptor baseEntitySaveChangesInterceptor) : base(options)
        {
            _baseEntitySaveChangesInterceptor = baseEntitySaveChangesInterceptor;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
        public DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LoyaltyMembership> LoyaltyMemberships { get; set; }
        public DbSet<MembershipTier> MembershipTiers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStock> OrderStocks { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShipmentInfo> ShipmentInfos { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockOnHold> StocksOnHold { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            modelBuilder.AddIdentityDbConfiguration();
            //modelBuilder.AddRemovePluralizeConvention();
            ContextExtensions.AddRemoveCascadeConvention();
            modelBuilder.ApplyConventions();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultDbConnection");
            optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.AddInterceptors(_baseEntitySaveChangesInterceptor);
        }
    }
}