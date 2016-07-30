using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Com.Jamim.Model.Entities;
using Com.Jamim.Model.Carts;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Model.Stores;
using Com.Jamim.Model.Customers;
using Com.Jamim.Model.Locations;
using Com.Jamim.Model.Manufacturers;
using Com.Jamim.Model.Orders;
using Com.Jamim.Model.Products;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Model.Taxes;
using Com.Jamim.Model.ValueObjects;
using Com.Jamim.Model.Images;

namespace Com.Jamim.Repository
{
    public class JamimDataContext : DbContext
    {
        public JamimDataContext()
            : base("DefaultConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryPerson> DeliveryPersons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryAccess> CategoryAccess {get; set;}
        public DbSet<Catalog> Catalogues { get; set; }
        public DbSet<Review> Reviewes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetailes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Weight> Weights { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ImagePath> ImagePaths { get; set; }

        public DbSet<ImageType> ImageTypes { get; set; }

        public DbSet<Store> Stores{get; set;}
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ProductConfiguration());  
        }
    }


    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {

        }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {

        }
    }

}
