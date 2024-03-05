﻿using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    internal class StudentService : IStudentService
    {

        private readonly IStudentData _studentData;
        public StudentService (IStudentData studentData)
        {
            _studentData = studentData;
        }
        public void Add(Student emmt)
        {
            throw new NotImplementedException();
        }

        public void ShowList(List<Student> listStudent)
        {

            List<string> listNameHeader = new List<string> {
                            //"Mssv","Họ Tên","Nhập Trường", "Ngày sinh", "Gioi Tinh", "Bằng Cấp","SDT","CCCD","Mã Bộ Môn","Dân Tộc","Tôn Giáo","Địa Chỉ", "Avatar","Trang Thái"
                            "Mssv","Họ Tên","Nhập Trường","Ngày Sinh", "Gioi Tinh","Trang Thái"
                        };
            HelperPrint.PrintTable(listStudent, listNameHeader);
        }

        public void ShowNumberSubjectRegister(double number)
        {
            HelperColor.WriteLineWithColor("Số môn học sinh viên đăng ký là: " +number, ConsoleColor.Blue);
        }

        public void ShowStudent(Student student)
        {
            List<string> listNameHeader = new List<string> {
                            "Mssv","Họ Tên","Nhập Trường", "Ngày sinh", "Gioi Tinh", "Bằng Cấp","SDT","CCCD","Mã Bộ Môn","Dân Tộc","Tôn Giáo","Địa Chỉ", "Avatar","Trang Thái"
                        };
            if (student != null)
            {
                HelperPrint.Print<Student>(student, listNameHeader);
            }
            else
            {
                HelperColor.WriteLineWithColor("Không tìm thấy sinh viên!", ConsoleColor.Red);
            }
        }
    }
}
