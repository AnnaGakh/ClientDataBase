using System.Threading.Tasks;

namespace DataBaseWeb.Repositories
{
    internal class StudentRepository
    {
        private readonly IRepository _context;
        public StudentRepository(IRepository context) => _context = context;
        public async Task CreateAsync(DbStudent student)
        {
            await _context.AddAsync(student);
            await _context.Save();
        }
    }
}
