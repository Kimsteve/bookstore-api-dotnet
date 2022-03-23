using System;
namespace Bookstore.Entities
{
    //record types use for immutable objects..esp for objects from the web
    public record Book
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public string Author { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }

}