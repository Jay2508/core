using Ecommerces.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerces.Entity
{
    public class EntityDbContext:DbContext
    {
        public EntityDbContext(DbContextOptions options) : base(options) { 

        }
        public DbSet<CategoryTbl> CategoryTbls { get; set; }
        public DbSet<SubCategoryTbl> SubCategoryTbls { get; set; }
        public DbSet<ThierdCategoryTbl> ThirdCategoryTbls { get; set; }
        public DbSet<BrandTbl> BrandTbls { get; set; }
        public DbSet<ProductTbl> ProductTbls { get; set; }
        //public DbSet<StateTbl> StateTbls { get; set; }
        //public DbSet<CityTbl> CityTbls { get; set; }
        public DbSet<AreaTbl> AreaTbls { get; set; }
        public DbSet<RegisterTbl> RegisterTbls { get; set; }
        //public DbSet<CartTbl> CartTbls { get; set; }
        public DbSet<ShippingTbl> ShippingTbls { get; set; }
        //public DbSet<OrderTbl> OrderTbls { get; set; }
        public DbSet<OrderDetailTbl> OrderDetailTbls { get; set; }
        public DbSet<SpecificationsTbl> SpecificationsTbls { get; set; }
        public DbSet<SpecificationsOptionsTbl> SpecificationsOptionsTbls { get; set; }
        //public DbSet<Ecommerces.Entity.Model.SpecificationsOptionsTbl> SpecificationsOptionsTbl { get; set; } = default!;



    }
}
