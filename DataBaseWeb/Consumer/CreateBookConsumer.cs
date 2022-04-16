using DataBaseWeb.Mappers;
using DataBaseWeb.Repositories;
using MassTransit;
using Models;
using System;
using System.Threading.Tasks;

namespace DataBaseWeb.Consumer
{
    internal class CreateBookConsumer : IConsumer<CreateBookRequest>
    {
        private readonly IMapper<DbBook,CreateBookRequest> _mapper;
        public CreateBookConsumer(IMapper<DbBook, CreateBookRequest> mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<CreateBookRequest> context)
        {
            using(DataBaseContext con = new())
            {
                BookRepository repository = new(con);
                await repository.CreateAsync(_mapper.ToDb(context.Message));
            }
            
            var response = new CreateBookResponse()
            {
                IsSuccess = true,
                Errors = new()
            };
            await context.RespondAsync<CreateBookResponse>(response);
        }
    } 
}
