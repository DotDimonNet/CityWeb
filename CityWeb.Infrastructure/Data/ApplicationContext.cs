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
        public DbSet<TransportJourneyModel> TransportJourneys { get; set; }
        public DbSet<RentCarModel> RentCars { get; set; }
        public DbSet<TaxiCarModel> TaxiCar { get; set; }

        public DbSet<DeliveryModel> Deliveries { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<HousePayModel> HousePays { get; set; }
        public DbSet<CounterModel> Counters { get; set; }
        public DbSet<EntertainmentModel> Entertaiments { get; set; }
        public DbSet<PeriodModel> Periods { get; set; }
        public DbSet<CarSharingModel> CarSharings { get; set; }
        public DbSet<TaxiModel> Taxi { get; set; }




        // enums tables

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<EntertainmentType> EventTypes { get; set; }
        public DbSet<DeliveryFromType> DeliveryFromType { get; set; }
        public DbSet<HousePaymentType> HousePaymentType { get; set; }
        public DbSet<HotelRoomType> HotelRoomType { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProfileModel>().HasOne(x => x.User).WithOne(x => x.Profile).HasForeignKey<UserProfileModel>(x => x.Id).OnDelete(DeleteBehavior.Cascade);

            #region ApplicationUserModel
            //builder.Entity<ApplicationUserModel>().HasMany(x => x.Balances).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Ratings).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Payments).WithOne(x => x.Owner).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Services).WithMany(x => x.Users);
            builder.Entity<ApplicationUserModel>().HasMany(x => x.Discounts).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
           
            #endregion

            #region ServiceModel
            //builder.Entity<ServiceModel>().HasMany(x => x.Discounts).WithOne(x => x.Service).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.Entertaiments).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.Hotels).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.HousePayments).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.CarSharing).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.Taxi).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ServiceModel>().HasMany(x => x.Deliverys).WithOne(x => x.Service).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Enums
            builder.Entity<PaymentStatus>().HasKey(x => x.ValueId).HasName("PK_PaymentStatus");
            builder.Entity<TransportType>().HasKey(x => x.ValueId).HasName("PK_TransportType");
            builder.Entity<EntertainmentType>().HasKey(x => x.ValueId).HasName("PK_EventType");
            builder.Entity<HotelRoomType>().HasKey(x => x.ValueId).HasName("PK_HotelRoomType");
            builder.Entity<HousePaymentType>().HasKey(x => x.ValueId).HasName("PK_HousePaymentType");
            builder.Entity<ProductType>().HasKey(x => x.ValueId).HasName("PK_ProductType");
            #endregion

            builder.Entity<DeliveryModel>().HasMany(x => x.Products).WithOne(x => x.Delivery).HasForeignKey(x => x.DeliveryId);
            builder.Entity<HotelModel>().HasMany(x => x.Rooms).WithOne(x => x.Hotel).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CarSharingModel>().HasMany(x => x.Vehicle).WithOne(x => x.CarSharing).HasForeignKey(x => x.CarSharingId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TaxiModel>().HasMany(x => x.Vehicle).WithOne(x => x.Taxi).HasForeignKey(x => x.TaxiId);
            builder.Entity<EntertainmentModel>().HasMany(x => x.Event).WithOne(x => x.Entertaiment).HasForeignKey(x => x.EntertaimentId);

            //builder.Entity<ServiceModel>().HasMany(x => x.Users).WithOne(x => x.Services).HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Cascade);




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
