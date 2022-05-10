﻿using StarCollege.DataAccess.Data;
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
        }
        public ISubjectRepository Subject { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
