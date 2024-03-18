﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IData
{
    public interface IDisciplineData : ICUDData<Discipline>, IReadData<Discipline>
    {
    }
}
