using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISubjectRepository Subject { get; }
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        IClassroomRepository Classroom { get; }
        IEnrollmentRepository Enrollment { get; }
        void Save();
    }
}
