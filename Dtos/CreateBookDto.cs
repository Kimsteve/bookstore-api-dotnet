using System.ComponentModel.DataAnnotations;

namespace Bookstore.Dtos
{
    public record CreateBookDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string Author { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}