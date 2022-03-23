using System;
using System.Collections.Generic;
using Bookstore.Entities;

namespace Bookstore.Data
{
    public interface InterfaceMemData
    {
        Book GetItem(Guid id);
        IEnumerable<Book> GetItems();

        void CreateItem(Book book);

        void UpdateItem(Book book);

        void DeleteItem(Guid id);
    }
}