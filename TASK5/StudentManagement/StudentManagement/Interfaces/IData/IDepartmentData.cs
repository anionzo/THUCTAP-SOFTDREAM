﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IData
{
    internal interface IDepartmentData: IReadData<Department>, ICUDData<Department>
    {
    }
}
