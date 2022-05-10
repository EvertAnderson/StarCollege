﻿using StarCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.DataAccess.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void Update(Teacher obj);
    }
}
