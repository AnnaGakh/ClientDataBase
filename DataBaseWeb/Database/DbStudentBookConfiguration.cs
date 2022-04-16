using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbStudentBookConfiguration : IEntityTypeConfiguration<DbStudentBook>
    {
        public void Configure(EntityTypeBuilder<DbStudentBook> builder)
        {
            builder.ToTable(DbStudentBook.TableName);
            builder.HasKey(x => x.Id);
            builder.HasOne(s => s.Book).WithMany(s => s.StudentBooks);
            builder.HasOne(s => s.Student).WithMany(s => s.StudentBooks);
        }
    }
}
