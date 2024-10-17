using System.ComponentModel.DataAnnotations;

namespace TestProduct.Models
{
    public class Product
    {

        [Key]
        public Guid ProductId { get; set; } // Primary Key

        public string? ProductTitle { get; set; }
        public string? Description { get; set; }




    }
}
