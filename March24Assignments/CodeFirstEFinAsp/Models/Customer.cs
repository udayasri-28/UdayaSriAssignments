using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFinAsp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
