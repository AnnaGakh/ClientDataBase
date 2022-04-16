using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbBook
    {
        public const string TableName = "Book";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public ICollection<DbStudentBook> StudentBooks { get; set; }

        public DbBook()
        {
            StudentBooks = new HashSet<DbStudentBook>();
        }


    }
}
