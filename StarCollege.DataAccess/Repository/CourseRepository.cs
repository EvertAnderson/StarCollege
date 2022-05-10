using StarCollege.DataAccess.Data;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.DataAccess.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Course obj)
        {
            _db.Course.Update(obj);
        }
    }
}
