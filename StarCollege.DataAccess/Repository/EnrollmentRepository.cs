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
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private ApplicationDbContext _db;

        public EnrollmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Enrollment obj)
        {
            _db.Enrollment.Update(obj);
        }
    }
}
