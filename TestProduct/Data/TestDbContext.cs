using Microsoft.EntityFrameworkCore;
using TestProduct.Models;


namespace TestProduct.Data
{
    public class TestDbContext : DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> dbContextOptions) : base(dbContextOptions)
        {


        }

        public DbSet<Product> Products { get; set; }









    }







}
