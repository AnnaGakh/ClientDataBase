using DataBaseWeb.Mappers;
using DataBaseWeb.Repositories;
using MassTransit;
using Models;
using System.Threading.Tasks;

namespace DataBaseWeb.Consumer
{
    internal class CreateStudentConsumer : IConsumer<CreateStudentRequest>
    {
        private readonly IMapper<DbStudent, CreateStudentRequest> _mapper;
        public CreateStudentConsumer(IMapper<DbStudent, CreateStudentRequest> mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<CreateStudentRequest> context)
        {
            using (DataBaseContext con = new())
            {
                StudentRepository repository = new(con);
                await repository.CreateAsync(_mapper.ToDb(context.Message));
            }
            var response = new CreateStudentResponse()
            {
                IsSuccess = true,
                Errors = new()
            };
            await context.RespondAsync <CreateStudentResponse> (response);
        }
    } 
}
