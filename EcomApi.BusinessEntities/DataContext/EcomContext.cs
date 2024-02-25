using Microsoft.EntityFrameworkCore;
using EcomApi.Utils;
using EcomApi.DataEntities.Models;
using EcomApi.DataEntities.ViewModels;
using System.Reflection.Emit;

namespace EcomApi.BusinessEntities
{
    public class EcomContext : DbContext
    {
        internal EcomContext() : base()
        {
        }
        internal EcomContext(DbContextOptions<EcomContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = AppSettings.Settings.SqlConnection.EcomDB;
            var con = connection.ConnectionString;
            var to = connection.CommandTimeout;
            optionsBuilder.UseSqlServer(con, sqlServerOptions => sqlServerOptions.CommandTimeout(to));

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetails>()
               .HasKey(od => new { od.OrderID, od.ProductID });


            builder.Entity<Users>().ToTable(tb => tb.HasTrigger("tr_Users"));
            builder.Entity<Products>().ToTable(tb => tb.HasTrigger("tr_Products"));
            builder.Entity<Coupons>().ToTable(tb => tb.HasTrigger("tr_Coupons"));
            builder.Entity<Carts>().ToTable(tb => tb.HasTrigger("tr_Carts"));
            builder.Entity<Wishlists>().ToTable(tb => tb.HasTrigger("tr_Wishlists"));
            builder.Entity<Orders>().ToTable(tb => tb.HasTrigger("tr_Orders"));
            builder.Entity<OrderDetails>().ToTable(tb => tb.HasTrigger("tr_OrderDetails"));
            builder.Entity<LoyaltyPoints>().ToTable(tb => tb.HasTrigger("tr_LoyaltyPoints"));
            builder.Entity<Complaints>().ToTable(tb => tb.HasTrigger("tr_Complaints"));
            builder.Entity<DeliveryStatus>().ToTable(tb => tb.HasTrigger("tr_DeliveryStatus"));
            builder.Entity<Deliveries>().ToTable(tb => tb.HasTrigger("tr_Deliveries"));
            builder.Entity<DeliveryUpdates>().ToTable(tb => tb.HasTrigger("tr_DeliveryUpdates"));
            builder.Entity<ComplaintResolutionStatus>().ToTable(tb => tb.HasTrigger("tr_ComplaintResolutionStatus"));
            builder.Entity<UserLoginAttempts>().ToTable(tb => tb.HasTrigger("tr_UserLoginAttempts"));


            builder.Entity<Users>().ToTable(tb => tb.HasTrigger("tr_Users_delete"));
            builder.Entity<Products>().ToTable(tb => tb.HasTrigger("tr_Products_delete"));
            builder.Entity<Coupons>().ToTable(tb => tb.HasTrigger("tr_Coupons_delete"));
            builder.Entity<Carts>().ToTable(tb => tb.HasTrigger("tr_Carts_delete"));
            builder.Entity<Wishlists>().ToTable(tb => tb.HasTrigger("tr_Wishlists_delete"));
            builder.Entity<Orders>().ToTable(tb => tb.HasTrigger("tr_Orders_delete"));
            builder.Entity<OrderDetails>().ToTable(tb => tb.HasTrigger("tr_OrderDetails_delete"));
            builder.Entity<LoyaltyPoints>().ToTable(tb => tb.HasTrigger("tr_LoyaltyPoints_delete"));
            builder.Entity<Complaints>().ToTable(tb => tb.HasTrigger("tr_Complaints_delete"));
            builder.Entity<DeliveryStatus>().ToTable(tb => tb.HasTrigger("tr_DeliveryStatus_delete"));
            builder.Entity<Deliveries>().ToTable(tb => tb.HasTrigger("tr_Deliveries_delete"));
            builder.Entity<DeliveryUpdates>().ToTable(tb => tb.HasTrigger("tr_DeliveryUpdates_delete"));
            builder.Entity<ComplaintResolutionStatus>().ToTable(tb => tb.HasTrigger("tr_ComplaintResolutionStatus_delete"));
            builder.Entity<UserLoginAttempts>().ToTable(tb => tb.HasTrigger("tr_UserLoginAttempts_delete"));


            // Add other entities here

            base.OnModelCreating(builder);
        }
        internal DbSet<Carts> Carts { get; set; }
        internal DbSet<Complaints> Complaints { get; set; }
        internal DbSet<Coupons> Coupons { get; set; }
        internal DbSet<Deliveries> Deliveries { get; set; }
        internal DbSet<DeliveryStatus> DeliveryStatus { get; set; }
        internal DbSet<DeliveryUpdates> DeliveryUpdates { get; set; }
        internal DbSet<LoyaltyPoints> LoyaltyPoints { get; set; }
        internal DbSet<OrderDetails> OrderDetails { get; set; }
        internal DbSet<Orders> Orders { get; set; }
        internal DbSet<Products> Products { get; set; }
        internal DbSet<Users> Users { get; set; }
        internal DbSet<Wishlists> Wishlists { get; set; }
        public DbSet<SalesDashboardViewModel> SalesDashboard { get; set; }
        public DbSet<DeliveryUpdatesDashboardViewModel> DeliveryUpdatesDashboard { get; set; }
        public DbSet<ComplaintResolutionDashboardViewModel> ComplaintResolutionDashboard { get; set; }
        public DbSet<UserLoginAttempts> UserLoginAttempts { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}
