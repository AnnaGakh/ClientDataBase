using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataBaseWeb.Repositories;
using Microsoft.EntityFrameworkCore;


namespace DataBaseWeb
{
    internal class DataBaseContext : DbContext, IRepository
    {
        public DbSet<DbBook> Book { get; set; }
        public DbSet<DbStudent> Student { get; set; }
        public DbSet<DbSchool> School { get; set; }
        public DbSet<DbStudentBook> StudentBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=SchoolDB;Trusted_Connection=True");
        }

        public async Task AddAsync(DbBook book)
        {
            await Book.AddAsync(book);
        }

        public async Task AddAsync(DbSchool school)
        {
            await School.AddAsync(school);
        }

        public async Task AddAsync(DbStudent student)
        {
            await Student.AddAsync(student);
        }

        public async Task<IEnumerable<DbBook>> GetAll()
        {
            return await Book.ToListAsync();
        }
        public async Task Save()
        {
            await SaveChangesAsync();
        }

    }
}
