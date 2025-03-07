using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data{
    public class ApplicationDbContext:DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
        :base(options){
            Products=Set<Product>();
        }

        public DbSet<Product> Products{get;set;}
        
    }
}