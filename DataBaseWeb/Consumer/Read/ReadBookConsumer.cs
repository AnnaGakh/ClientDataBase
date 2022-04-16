using DataBaseWeb.Mappers;
using DataBaseWeb.Repositories;
using MassTransit;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseWeb.Consumer.Read
{
    public class ReadBookConsumer : IConsumer<ReadBookRequest>
    {
        public async Task Consume(ConsumeContext<ReadBookRequest> context)
        {
            var response = new ReadBookResponse()
            {
                IsSuccess = true,
                Errors = new(),
                Books = new()
            };

            IEnumerable<DbBook> books;
            using (DataBaseContext con = new())
            {
                BookRepository repository = new(con);
                books = await repository.ReadAsync();
                foreach(DbBook bookItem in books)
                {
                    BookMapper bookMapper = new BookMapper();
                    response.Books.Add(bookMapper.FromDb(bookItem));
                }
            }
   
            await context.RespondAsync<ReadBookResponse>(response);
        }
    }
}
