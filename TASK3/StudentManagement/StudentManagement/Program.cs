using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Menu();
        }
        public static void Menu()
        {
            int chucNang = -1;
            //string connectionString = "Data Source=.;Initial Catalog=QUANLY_SINHVIEN;Integrated Security=True;Trust Server Certificate=True";
            string connectionString = "Data Source=.;Initial Catalog=QUANLY_SINHVIEN;Integrated Security=True";
            List< string> listNameHeader;
            StudentDapperData dapperData = new StudentDapperData(connectionString);
            SubjectDapperData subjectDapper = new SubjectDapperData(connectionString);
            StudentService studentService = new StudentService(null);
            SubjectService subjectService = new SubjectService();

            Console.WriteLine("0.Thoát khỏi chương trình!");
            Console.WriteLine("1.Xem danh sách sinh viên");
            Console.WriteLine("2.Xem chi tiết sinh viên");
            Console.WriteLine("3.Xem số môn học sinh viên đăng ký");
            Console.WriteLine("4.Xem điểm môn học của sinh viên");
            Console.WriteLine("5.Nhập điểm của sinh viên");
            Console.WriteLine("6.Xem kết quả trượt đỗ của sinh viên.");
            Console.WriteLine(new string('-', 15));

            do
            {
                HelperColor.WriteWithColor("Nhập vào chức năng thực hiện: ",HelperColor.Blue);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out chucNang))
                {
                    HelperColor.WriteLineWithColor("Vui lòng nhập một số nguyên hợp lệ.",HelperColor.Yellow);
                    continue;
                }
                switch (chucNang)
                {
                    case 1:
                        // Thực hiện chức năng xem danh sách sinh viên
                        Console.WriteLine(new string('-', 30));
                        studentService.ShowList(dapperData.GetAll());

                        break;
                    case 2:
                        // Thực hiện chức năng xem chi tiết sinh viên
                        string masv;
                        Console.Write("Vui lòng nhập mssv để hiện chi tiết: ");
                        masv = Console.ReadLine();
                        Student student = dapperData.Get(masv);
                        studentService.ShowStudent(student);
                        Console.WriteLine(new string('-', 15));
                        break;
                    case 3:
                        // Thực hiện chức năng xem số môn học sinh viên đăng ký

                        subjectService.ShowList(subjectDapper.GetAll());
                        Console.WriteLine(new string('-', 15));
                        break;
                    case 4:
                        // Thực hiện chức năng xem điểm môn học của sinh viên
            
                        Console.WriteLine(new string('-', 15));
                        break;
                    case 5:
                        // Thực hiện chức năng nhập điểm của sinh viên
     
                        break;
                    case 6:
                        // Thực hiện chức năng xem kết quả trượt đỗ của sinh viên
        
                        // XemKetQuaTruotDoCuaSinhVien();
                        break;
                    case 0:
                        // Thoát khỏi ứng dụng
                        Console.WriteLine("Chương trình đã thoát.");
                        break;
                    default:
                        // Nếu lựa chọn không hợp lệ, thông báo cho người dùng và yêu cầu nhập lại
                        HelperColor.WriteLineWithColor("Lựa chọn không hợp lệ. Vui lòng nhập lại.", HelperColor.Yellow);

                        break;
                }
            } while (chucNang != 0);
        }
    }
}
