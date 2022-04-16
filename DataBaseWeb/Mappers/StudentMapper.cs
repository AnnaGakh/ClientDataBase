using DataBaseWeb.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseWeb.Mappers
{
    internal class StudentMapper : IMapper<DbStudent, CreateStudentRequest>
    {
        private readonly IMapper<DbSchool,CreateSchoolRequest> _schoolMapper;
        private readonly IMapper<DbBook, CreateBookRequest> _bookMapper;
        public StudentMapper(IMapper<DbSchool, CreateSchoolRequest> schoolMapper, IMapper<DbBook, CreateBookRequest> bookMapper)
        {
            _schoolMapper = schoolMapper;
            _bookMapper = bookMapper;
        }
        public DbStudent ToDb(CreateStudentRequest student)
        {
            Guid schoolId = Guid.NewGuid();
            Guid studentId = Guid.NewGuid();
            Guid bookId = Guid.NewGuid();
            DbStudent dbStudent = new()
            {
                Id = studentId,
                Name = student.Name,
                Age = student.Age,
                SchoolId = schoolId,
                School = new()
                {
                    Id = schoolId,
                    Name = student.SchoolRequest.Name,
                    Number = student.SchoolRequest.Number,
                    Headmaster = student.SchoolRequest.Headmaster
                },
                StudentBooks = new HashSet<DbStudentBook>()
                {
                    new DbStudentBook()
                    { 
                        Id = Guid.NewGuid(), 
                        StudentId = studentId,
                        BookId = bookId,
                        Book = new()
                        {
                            Id = bookId,
                            Name = student.BookRequest.Name,
                            Author = student.BookRequest.Author,
                            Year = student.BookRequest.Year
                        }
                    }
                }
            };

            return dbStudent;
        }

        public CreateStudentRequest FromDb(DbStudent dbStudent)
        {
            DbSchool currentSchool;
            DbBook currentBook;
            using (DataBaseContext con = new())
            {
                currentSchool = con.School.Where(x => x.Id == dbStudent.SchoolId).FirstOrDefault();
               // INCLUDE???? currentBook = con.Book.Where(x => x.IdBook == dbStudent.StudentBooks.)
            }
            CreateStudentRequest studentRequest = new()
            {
                Name = dbStudent.Name,
                Age = dbStudent.Age,
                SchoolRequest = _schoolMapper.FromDb(currentSchool),
                //BookRequest = _bookMapper.FromDb(currentBook)
            };
            return studentRequest;
        }
    }
}
