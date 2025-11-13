using System.ComponentModel.DataAnnotations;

namespace Day3_EFCore_Integration.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 5000)]
        public decimal Price { get; set; }
    }
}
