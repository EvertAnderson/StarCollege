using StarCollege.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarCollege.DataAccess.Data;

namespace StarCollege.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            bool containsStudent = _db.Student.Any();
            bool containsTeacher = _db.Teacher.Any();
            bool cotainSubject = _db.Subject.Any();
            bool containsCourse = _db.Course.Any();
            bool containsEnrollment = _db.Enrollment.Any();
            bool containsClassroom = _db.Classroom.Any();
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                if (!containsStudent && !containsTeacher && !cotainSubject && !containsCourse && !containsEnrollment && !containsClassroom)
                {
                    if (_db.Student.Any())
                    {
                        return;   // DB has been seeded
                    }

                    var students = new Student[]
                    {
                        new Student { FirstMidName = "Carson",   LastName = "Alexanders" },
                        new Student { FirstMidName = "Meredith", LastName = "Alons" },
                        new Student { FirstMidName = "Arturo",   LastName = "Anander" },
                        new Student { FirstMidName = "Gytis",    LastName = "Barzdukas" },
                        new Student { FirstMidName = "Yan",      LastName = "Li" },
                        new Student { FirstMidName = "Peggy",    LastName = "Justice" },
                        new Student { FirstMidName = "Laura",    LastName = "Norman" },
                        new Student { FirstMidName = "Lovel",    LastName = "Olivetto" }
                    };

                    foreach (var item in students)
                    {
                        _db.Student.Add(item);
                    }
                    _db.SaveChanges();

                    var teachers = new Teacher[]
                    {
                        new Teacher { FirstMidName = "Karen",   LastName = "Reiner",    Title = "Software Engineer" },
                        new Teacher { FirstMidName = "Diana",   LastName = "Kazama",    Title = "Civil Engineer" },
                        new Teacher { FirstMidName = "Kevin",   LastName = "Mishima",   Title = "Industrial Engineer" },
                        new Teacher { FirstMidName = "Bryan",   LastName = "Orleans",   Title = "System Information Engineer" },
                        new Teacher { FirstMidName = "Paul",    LastName = "Li",        Title = "Electronic Engineer" },
                        new Teacher { FirstMidName = "Jim",     LastName = "Soto",      Title = "Communication Scientist" },
                        new Teacher { FirstMidName = "Ander",   LastName = "Helu",      Title = "Psicology" },
                        new Teacher { FirstMidName = "Geloovan",LastName = "Sun",       Title = "Computer Scientist" },
                        new Teacher { FirstMidName = "Jhonny",  LastName = "Bravo",     Title = "Lawyer" },
                        new Teacher { FirstMidName = "Courage", LastName = "Stone",     Title = "Medicine" }
                    };

                    foreach (var item in teachers)
                    {
                        _db.Teacher.Add(item);
                    }
                    _db.SaveChanges();

                    var subjects = new Subject[]
                    {
                        new Subject { Name = "Maths", Department = "Mathematics" },
                        new Subject { Name = "Programming", Department = "Engineering" },
                        new Subject { Name = "Administration", Department = "Business" },
                        new Subject { Name = "Sounds", Department = "Music" },
                        new Subject { Name = "Painting", Department = "Arts" },
                        new Subject { Name = "Penal Code", Department = "Laws" },
                        new Subject { Name = "Civil Rights", Department = "Laws" },
                        new Subject { Name = "General Medicine", Department = "Medicine" },
                        new Subject { Name = "Pediatry", Department = "Medicine" },
                    };

                    foreach (var item in subjects)
                    {
                        _db.Subject.Add(item);
                    }
                    _db.SaveChanges();

                    var courses = new Course[]
                    {
                        new Course { Name = "Calculus 1", Credits = 5, SubjectId = 1 },
                        new Course { Name = "Calculus 2", Credits = 4, SubjectId = 1 },
                        new Course { Name = "Calculus 3", Credits = 5, SubjectId = 1 },
                        new Course { Name = "Programming 1", Credits = 5, SubjectId = 2 },
                        new Course { Name = "Programming 2", Credits = 5, SubjectId = 2 },
                        new Course { Name = "Data Structures", Credits = 4, SubjectId = 2 },
                        new Course { Name = "International Business 1", Credits = 3, SubjectId = 2 },
                        new Course { Name = "International Business 2", Credits = 4, SubjectId = 2 },
                        new Course { Name = "International Business 3", Credits = 5, SubjectId = 2 },
                        new Course { Name = "Guitar", Credits = 3, SubjectId = 4 },
                        new Course { Name = "Battery", Credits = 3, SubjectId = 4 },
                        new Course { Name = "Trumpet", Credits = 4, SubjectId = 4 },
                        new Course { Name = "Contemporary Painting", Credits = 2, SubjectId = 5 },
                        new Course { Name = "Street Painting", Credits = 3, SubjectId = 5 },
                        new Course { Name = "Professional Painting", Credits = 4, SubjectId = 5 },
                        new Course { Name = "Crimes Codes", Credits = 3, SubjectId = 6 },
                        new Course { Name = "Politic Laws", Credits = 4, SubjectId = 7 },
                        new Course { Name = "Medical Care 1", Credits = 4, SubjectId = 8 },
                        new Course { Name = "Medical Care 2", Credits = 5, SubjectId = 8 },
                        new Course { Name = "Kids Health", Credits = 5, SubjectId = 9 },
                    };

                    foreach (var item in courses)
                    {
                        _db.Course.Add(item);
                    }
                    _db.SaveChanges();

                    var classrooms = new Classroom[]
                    {
                        new Classroom { ClassCode = "CAL1A", CourseId = 1, TeacherId = 1 },
                        new Classroom { ClassCode = "CAL1B", CourseId = 1, TeacherId = 2 },
                        new Classroom { ClassCode = "CAL1C", CourseId = 1, TeacherId = 3 },
                        new Classroom { ClassCode = "CAL1D", CourseId = 1, TeacherId = 4 },
                        new Classroom { ClassCode = "CAL2A", CourseId = 2, TeacherId = 1 },
                        new Classroom { ClassCode = "CAL2B", CourseId = 2, TeacherId = 2 },
                        new Classroom { ClassCode = "CAL2C", CourseId = 2, TeacherId = 3 },
                        new Classroom { ClassCode = "CAL2D", CourseId = 2, TeacherId = 4 },
                        new Classroom { ClassCode = "CAL3A", CourseId = 3, TeacherId = 1 },
                        new Classroom { ClassCode = "CAL3B", CourseId = 3, TeacherId = 2 },
                        new Classroom { ClassCode = "CAL3C", CourseId = 3, TeacherId = 3 },
                        new Classroom { ClassCode = "CAL3D", CourseId = 3, TeacherId = 4 },

                        new Classroom { ClassCode = "PRO1A", CourseId = 4, TeacherId = 1 },
                        new Classroom { ClassCode = "PRO1B", CourseId = 4, TeacherId = 2 },
                        new Classroom { ClassCode = "PRO1C", CourseId = 4, TeacherId = 3 },
                        new Classroom { ClassCode = "PRO1D", CourseId = 4, TeacherId = 4 },
                        new Classroom { ClassCode = "PRO2A", CourseId = 5, TeacherId = 1 },
                        new Classroom { ClassCode = "PRO2B", CourseId = 5, TeacherId = 2 },
                        new Classroom { ClassCode = "PRO2C", CourseId = 5, TeacherId = 3 },
                        new Classroom { ClassCode = "PRO2D", CourseId = 5, TeacherId = 4 },
                        new Classroom { ClassCode = "PRO3A", CourseId = 6, TeacherId = 1 },
                        new Classroom { ClassCode = "PRO3B", CourseId = 6, TeacherId = 2 },
                        new Classroom { ClassCode = "PRO3C", CourseId = 6, TeacherId = 3 },
                        new Classroom { ClassCode = "PRO3D", CourseId = 6, TeacherId = 4 },
                    };

                    foreach (var item in classrooms)
                    {
                        _db.Classroom.Add(item);
                    }
                    _db.SaveChanges();

                    var enrollments = new Enrollment[]
                    {
                        new Enrollment { StudentId = 1, ClassroomId = 1, Score = 19 },
                        new Enrollment { StudentId = 1, ClassroomId = 13, Score = 19 },
                        new Enrollment { StudentId = 2, ClassroomId = 2, Score = 19 },
                        new Enrollment { StudentId = 2, ClassroomId = 14, Score = 19 },
                        new Enrollment { StudentId = 3, ClassroomId = 3, Score = 19 },
                        new Enrollment { StudentId = 3, ClassroomId = 15, Score = 19 },
                        new Enrollment { StudentId = 4, ClassroomId = 4, Score = 19 },
                        new Enrollment { StudentId = 4, ClassroomId = 16, Score = 19 },
                        new Enrollment { StudentId = 5, ClassroomId = 5, Score = 19 },
                        new Enrollment { StudentId = 5, ClassroomId = 17, Score = 19 },
                        new Enrollment { StudentId = 6, ClassroomId = 6, Score = 19 },
                        new Enrollment { StudentId = 6, ClassroomId = 18, Score = 19 },
                    };

                    foreach (var item in enrollments)
                    {
                        _db.Enrollment.Add(item);
                    }
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return;
        }
    }
}
