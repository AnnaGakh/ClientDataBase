using Models;
using System;

namespace DataBaseWeb.Mappers
{
    internal class SchoolMapper : IMapper<DbSchool,CreateSchoolRequest>
    {
        public DbSchool ToDb(CreateSchoolRequest school)
        {
            DbSchool dbSchool = new()
            {
                Id = Guid.NewGuid(),
                Name = school.Name,
                Number = school.Number,
                Headmaster = school.Headmaster
            };
            return dbSchool;
        }

        public CreateSchoolRequest FromDb(DbSchool dbSchool)
        {
            CreateSchoolRequest schoolRequest = new()
            {
                Name = dbSchool.Name,
                Number = dbSchool.Number,
                Headmaster = dbSchool.Headmaster
            };
            return schoolRequest;
        }
    }
}
