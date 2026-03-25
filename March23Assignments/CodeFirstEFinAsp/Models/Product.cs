using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFinAsp.Models
{
    public class Product
    {
        public int ProductId {  get; set; }
        [Required]
        public string ProductName { get; set; }
        [Display(Name ="who buyed")]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
