using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseWeb.Repositories
{
    internal interface IRepository
    {
        DbSet<DbBook> Book { get; set; }
        DbSet<DbSchool> School { get; set; }
        DbSet<DbStudent> Student { get; set; }
        DbSet<DbStudentBook> StudentBook { get; set; }
        Task AddAsync(DbBook book);
        Task AddAsync(DbSchool school);
        Task AddAsync(DbStudent student);
        Task<IEnumerable<DbBook>> GetAll();

        Task Save();
    }
}
