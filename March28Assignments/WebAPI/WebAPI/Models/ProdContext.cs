using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class ProdContext : DbContext
    {
        public ProdContext(DbContextOptions<ProdContext> dbContextOptions) :
            base(dbContextOptions)
        {

        }

        public DbSet<Product> product { set; get;}
    }
}
