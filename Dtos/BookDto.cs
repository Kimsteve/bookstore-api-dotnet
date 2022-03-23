using System;

namespace Bookstore.Dtos
{

    public record BookDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public string Author { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
