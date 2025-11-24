using System.ComponentModel.DataAnnotations;

namespace Day4_Repository_And_AutoMapper.Models
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
