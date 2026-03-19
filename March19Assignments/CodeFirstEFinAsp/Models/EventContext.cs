using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFinAsp.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions <EventContext> dbContextOptions):base(dbContextOptions) {
            
        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Author1> authors1 { get; set; }
        public DbSet<Course1> courses1 { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<UserDetails> userdetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
