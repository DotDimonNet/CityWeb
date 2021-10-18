using CityWeb.Domain.Entities;
using CityWeb.Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityWeb.Infrastucture.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUserModel, ApplicationUserRole, Guid>, IDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
             Database.SetCommandTimeout(1000);
        }

        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<BalanceModel> Balances { get; set; }
        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<PriceModel> Prices { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ServiceBranchModel> ServiceBranches { get; set; }
        public DbSet<TransportJourneyModel> TransportJourneys { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }


        // enums tables

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<HousePaymentType> HousePaymentType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProfileModel>().HasOne(x => x.User).WithOne(x => x.Profile).HasForeignKey<UserProfileModel>(x => x.Id).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Balances).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Ratings).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Payments).WithOne(x => x.Owner).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Services).WithMany(x => x.Users);
            builder.Entity<ServiceModel>().HasMany(x => x.Branches).WithOne(x => x.Service).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PaymentStatus>().HasKey(x => x.ValueId).HasName("PK_PaymentStatus");
            builder.Entity<TransportType>().HasKey(x => x.ValueId).HasName("PK_TransportType");
            builder.Entity<EventType>().HasKey(x => x.ValueId).HasName("PK_EventType");
            builder.Entity<HousePaymentType>().HasKey(x => x.ValueId).HasName("PK_HousePaymentType");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Entity)entity.Entity).Created = DateTime.UtcNow;
                }

                ((Entity)entity.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
