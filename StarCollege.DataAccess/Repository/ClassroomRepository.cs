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
    public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {
        private ApplicationDbContext _db;

        public ClassroomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Classroom obj)
        {
            _db.Classroom.Update(obj);
        }
    }
}
