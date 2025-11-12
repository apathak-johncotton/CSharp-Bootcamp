using System.ComponentModel.DataAnnotations;

namespace Day2_CRUD_And_Validation.Models
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
