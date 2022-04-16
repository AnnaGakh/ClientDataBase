using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbStudentBook
    {
        public const string TableName = "StudentBook";
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid BookId { get; set; }
        public DbStudent Student { get; set; }
        public DbBook Book { get; set; }

        public DbStudentBook()
        {
            Book = new DbBook();
        }
    }
}
