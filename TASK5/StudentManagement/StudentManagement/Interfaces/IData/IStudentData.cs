﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IData
{
    internal interface IStudentData: IReadData<Student>, ICUDData<Student>
    {
        double GetNumberSubjectRegister(string idSemester, string mssv);
        DataTable GetEnrolledCourseInfoForStudent(string mssv);

    }
}
