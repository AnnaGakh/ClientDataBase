using System.Threading.Tasks;

namespace DataBaseWeb.Repositories
{
    internal class SchoolRepository
    {
        private readonly IRepository _context;
        public SchoolRepository(IRepository context) => _context = context;
        public async Task CreateAsync(DbSchool school)
        {
            await _context.AddAsync(school);
            await _context.Save();
        }
    }
}
