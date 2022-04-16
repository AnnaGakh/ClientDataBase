using DataBaseWeb.Mappers;
using DataBaseWeb.Repositories;
using MassTransit;
using Models;
using System.Threading.Tasks;

namespace DataBaseWeb.Consumer
{
    internal class CreateSchoolConsumer : IConsumer<CreateSchoolRequest>
    {
        private readonly IMapper<DbSchool,CreateSchoolRequest> _mapper;
        public CreateSchoolConsumer(IMapper<DbSchool, CreateSchoolRequest> mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<CreateSchoolRequest> context)
        {
            using (DataBaseContext con = new())
            {
                SchoolRepository repository = new(con);
                await repository.CreateAsync(_mapper.ToDb(context.Message));
            }

            var response = new CreateSchoolResponse()
            {
                IsSuccess = true,
                Errors = new()
            };
            await context.RespondAsync<CreateSchoolResponse>(response);
        }
    } 
}
