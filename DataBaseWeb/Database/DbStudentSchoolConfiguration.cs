using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    internal class DbStudentSchoolConfiguration : IEntityTypeConfiguration<DbStudent>
    {
        public void Configure(EntityTypeBuilder<DbStudent> builder)
        {
            builder.ToTable(DbStudent.TableName);
            builder.HasKey(x => x.Id);
            builder.HasOne(s => s.School).WithMany(s => s.Students);
        }
    }
}
