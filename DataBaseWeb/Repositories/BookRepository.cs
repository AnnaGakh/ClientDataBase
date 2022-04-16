using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseWeb.Repositories
{
    internal class BookRepository 
    {
        private readonly IRepository _context;
        public BookRepository(IRepository context)
        {
            _context = context;
        }
        public async Task CreateAsync(DbBook book)
        {
            await _context.AddAsync(book);
            await _context.Save();
        }

        public async Task<IEnumerable<DbBook>> ReadAsync()
        {
            return await _context.GetAll(); 
        }
    }
}
