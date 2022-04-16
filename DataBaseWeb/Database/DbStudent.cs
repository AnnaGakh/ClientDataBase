using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbStudent
    {
        public const string TableName = "Student";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid SchoolId{ get; set; }

        public DbSchool School { get; set; }
        public ICollection<DbStudentBook> StudentBooks { get; set; }
        public DbStudent()
        {
            School = new DbSchool();
            StudentBooks = new HashSet<DbStudentBook>();
        }
    }
}
