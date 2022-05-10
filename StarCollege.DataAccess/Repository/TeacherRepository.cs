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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher obj)
        {
            _db.Teacher.Update(obj);
        }
    }
}
