using AutoMapper;
using Models;
using System;

namespace DataBaseWeb.Mappers
{
    internal class BookMapper : IMapper<DbBook, CreateBookRequest>
    {
        public DbBook ToDb(CreateBookRequest book)
        {
            DbBook dbBook = new()
            {
                Id = Guid.NewGuid(),
                Name = book.Name,
                Author = book.Author,
                Year = book.Year
            };
            return dbBook;
        }

        public CreateBookRequest FromDb(DbBook dbBook)
        {
            CreateBookRequest bookRequest = new()
            {
                Name = dbBook.Name,
                Author = dbBook.Author,
                Year = dbBook.Year
            };
            return bookRequest;
        }
    }
}
