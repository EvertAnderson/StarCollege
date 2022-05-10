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
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private ApplicationDbContext _db;

        public SubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Subject obj)
        {
            _db.Subject.Update(obj);
        }
    }
}
