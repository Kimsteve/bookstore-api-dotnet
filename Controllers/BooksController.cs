using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Dtos;
using Bookstore.Entities;
using Bookstore.Data;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore.Controllers
{
    //API controller
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly InterfaceMemData repository;

        public BooksController(InterfaceMemData repository)
        {
            this.repository = repository;
        }
        //GET /books --the following methods responds to this get.
        [HttpGet]
        public IEnumerable<BookDto> GetItems()
        {
            var books = repository.GetItems().Select(item => item.AsDto());
            return books;
        }
        // Get /items/id

        [HttpGet("{id}")]

        public ActionResult<BookDto> GetItem(Guid id)
        {
            var book = repository.GetItem(id);
            if (book is null)
            {
                return NotFound();
            }
            return book.AsDto();
        }
        //POST /books
        [HttpPost]
        public ActionResult<BookDto> CreateItem(CreateBookDto bookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                Name = bookDto.Name,
                Author = bookDto.Author,
                Price = bookDto.Price,
                CreatedDate = DateTimeOffset.UtcNow.Date
                
            };
            repository.CreateItem(book);

            return CreatedAtAction(nameof(GetItem), new { id = book.Id }, book.AsDto());
        }

        //PUT/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateBookDto bookDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            // record type with expression --existing item with the new properties
            Book updatedItem = existingItem with
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Price = bookDto.Price

            };
            repository.UpdateItem(updatedItem);

            return NoContent();

        }

        //DELETE    /books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}