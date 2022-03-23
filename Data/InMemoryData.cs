using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Entities;

namespace Bookstore.Data
{


    public class InMemoryData : InterfaceMemData
    {
        private readonly List<Book> books = new()
        {
            new Book { Id = Guid.NewGuid(), Name = "The Alchemist", Author = "Paulo Coelho", Price = 9, CreatedDate = System.DateTimeOffset.UtcNow },
            new Book { Id = Guid.NewGuid(), Name = "Atomic Habits", Author = "James Clear", Price = 20, CreatedDate = System.DateTimeOffset.UtcNow },
            new Book { Id = Guid.NewGuid(), Name = "Relativity ", Author = "Albert Einstein", Price = 18, CreatedDate = System.DateTimeOffset.UtcNow }

        };
        public IEnumerable<Book> GetItems()
        {
            return books;
        }

        public Book GetItem(Guid id)
        {
            return books.Where(book => book.Id == id).SingleOrDefault();
        }

        public void CreateItem(Book book)
        {
            books.Add(book);
        }

        public void UpdateItem(Book book)
        {
            var index = books.FindIndex(existingItem => existingItem.Id == book.Id);
            books[index] = book;
        }

        public void DeleteItem(Guid id)
        {
            var index = books.FindIndex(existingItem => existingItem.Id == id);
            books.RemoveAt(index);
        }
    }
}