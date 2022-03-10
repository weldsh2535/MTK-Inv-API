using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Models
{
    public class dataContext:DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {

        }
        public DbSet<AddStock> AddStock { get; set; }
        public DbSet<LookupCatagory> LookupCatagory { get; set; }
        public DbSet<Lookup> lookup { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<IdSetting> IdSetting { get; set; }
        public DbSet<functionality> functionality { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<Vocher> Vocher { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<ItemLocation> ItemLocation  { get; set; }
        public DbSet<UserRole> userRole{ get; set; }
        public DbSet<ItemStoreBalance> ItemStoreBalance { get; set; }
        public DbSet<StoreTransfer> storeTransfer { get; set; }
        public DbSet<VocherStoreTransation> vocherStoreTransation { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<StockAdjustment> StockAdjustment { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<CountSheet> CountSheet { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Email> email { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
