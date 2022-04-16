using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbSchool
    {
        public const string TableName = "School";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Headmaster { get; set; }
        public ICollection<DbStudent> Students { get; set; }

        public DbSchool()
        {
            Students = new HashSet<DbStudent>();
        }
    }
}
