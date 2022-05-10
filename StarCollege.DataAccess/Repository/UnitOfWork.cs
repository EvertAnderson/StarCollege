using StarCollege.DataAccess.Data;
using StarCollege.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Subject = new SubjectRepository(_db);
            Course = new CourseRepository(_db);
            Student = new StudentRepository(_db);
            Teacher = new TeacherRepository(_db);
            Classroom = new ClassroomRepository(_db);
            Enrollment = new EnrollmentRepository(_db);
        }
        public ISubjectRepository Subject { get; private set; }
        public ICourseRepository Course { get; private set; }
        public IStudentRepository Student { get; private set; }
        public ITeacherRepository Teacher { get; private set; }
        public IClassroomRepository Classroom { get; private set; }
        public IEnrollmentRepository Enrollment { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
