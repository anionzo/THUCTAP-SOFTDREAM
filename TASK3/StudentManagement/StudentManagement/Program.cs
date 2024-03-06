using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
            List<string> listNameHeader;
            string idSemester =  string.Empty;
            int idEnrolledCourses = 0;
            List<EnrolledCourses> enrolledCourses;
            Student student = new Student();
            //DATA  
            StudentDapperData studentDapper = new StudentDapperData(connectionString);
            SubjectDapperData subjectDapper = new SubjectDapperData(connectionString);
            SemesterDapperData semesterDapper = new SemesterDapperData(connectionString);
            EnrolledCoursesDapperData enrolledCoursesDapperData = new EnrolledCoursesDapperData(connectionString);
            EnrolledCoursesStudentRegisterDapperData enrolledCoursesStudentRegisterDapperData = new EnrolledCoursesStudentRegisterDapperData(connectionString);
            //SERVICE
            StudentService studentService = new StudentService(null);
            SubjectService subjectService = new SubjectService();
            SemesterService semesterService = new SemesterService();
            EnrolledCoursesService enrolledCoursesService = new EnrolledCoursesService();
            EnrolledCoursesStudentRegisterService enrolledCoursesStudentRegisterService = new EnrolledCoursesStudentRegisterService();
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
                HelperColor.WriteWithColor("Nhập vào chức năng thực hiện: ", HelperColor.Blue);
                string input = Console.ReadLine();
                string masv;
                if (!int.TryParse(input, out chucNang))
                {
                    HelperColor.WriteLineWithColor("Vui lòng nhập một số nguyên hợp lệ.", HelperColor.Yellow);
                    continue;
                }
                switch (chucNang)
                {
                    case 1:
                        {
                            // Thực hiện chức năng xem danh sách sinh viên
                            Console.WriteLine(new string('-', 30));
                            studentService.ShowList(studentDapper.GetAll());

                        }
                        break;
                    case 2:
                        {
                            // Thực hiện chức năng xem chi tiết sinh viên
                            Console.Write("Vui lòng nhập mssv để hiện chi tiết: ");
                            masv = Console.ReadLine();
                            student = studentDapper.Get(masv);
                            studentService.ShowStudent(student);
                            Console.WriteLine(new string('-', 15));
                        }
                        break;
                    case 3:
                        {
                            // Thực hiện chức năng xem số môn học sinh viên đăng ký
                            //List<Subject> subjects = subjectDapper.GetAll();
                            //subjectService.ShowList(subjects);

                            Console.Write("Nhập mssv cần kiêm tra số môn đăng ký: ");
                            masv = Console.ReadLine();
                            student = studentDapper.Get(masv);
                            if (student != null)
                            {
                                semesterService.ShowList(semesterDapper.GetAll());
                                Console.Write("Nhập số ID Học Kỳ cần kiêm tra số môn đăng ký: ");
                                idSemester = Console.ReadLine();
                                double numberRegister = studentDapper.GetNumberSubjectRegister(idSemester, masv);
                                studentService.ShowNumberSubjectRegister(numberRegister);

                            }
                            else
                            {
                                HelperColor.WriteLineWithColor("Không tìm thấy sinh viên!", ConsoleColor.Red);
                            }
                            Console.WriteLine(new string('-', 15));
                        }
                        break;
                    case 4:
                        {
                            // Thực hiện chức năng xem điểm môn học của sinh viên
                            studentService.ShowList(studentDapper.GetAll());
                            Console.Write("Nhập mssv cần xem điểm: ");
                            masv = Console.ReadLine();
                            student = studentDapper.Get(masv);
                            if (student != null)
                            {
                                DataTable dataTable = studentDapper.GetEnrolledCourseInfoForStudent(masv);
                                studentService.ShowEnrolledCourseInfoForStudent(dataTable);
                            }
                            else
                            {
                                HelperColor.WriteLineWithColor("Không tìm thấy sinh viên!", ConsoleColor.Red);
                            }
                            Console.WriteLine(new string('-', 15));
                        }
                        break;
                    case 5:
                        {
                            // Thực hiện chức năng nhập điểm của sinh viên
                            // Hiển thị môn cần nhập điểm
                            semesterService.ShowList(semesterDapper.GetAll());
                            Console.Write("Nhập số ID Học Kỳ cần nhập điển: ");
                            idSemester = Console.ReadLine();
                            // lấy TBL_EnrolledCourses
                            enrolledCourses = enrolledCoursesDapperData.GetAll().Where(x => x.IDSemester == idSemester).ToList();


                            if (enrolledCourses.Count > 0)
                            {
                                // danh sách môn học
                                enrolledCoursesService.ShowList(enrolledCourses);

                                //Hiển thị danh sách sinh viên và điểm
                                Console.Write("Nhập số ID môn cần nhập điển: ");
                                idEnrolledCourses = int.Parse(Console.ReadLine());
                                var dataESR = enrolledCoursesStudentRegisterDapperData.GetAll().Where(X => X.IDEnrolledCourses == idEnrolledCourses).ToList();
                                if (dataESR.Count > 0)
                                {
                                    enrolledCoursesStudentRegisterService.ShowListshowsubjectScoreboard(dataESR);
                                    // Nhập mssv để thêm điểm của môn học đó
                                    Console.Write("Nhập mssv cần nhập điểm: ");
                                    masv = Console.ReadLine();
                                    var eCSR = dataESR.Where(x => x.MSSV.Equals(masv, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                                    if (eCSR != null)
                                    {
                                        string courseWorkScore;
                                        string examScore;
                                        do
                                        {
                                            Console.Write("Nhập điểm quá trình: ");
                                            courseWorkScore = Console.ReadLine();
                                        } while (!Helper.IsInRange(decimal.Parse(courseWorkScore)) || !Helper.IsDecimal(courseWorkScore));

                                        do
                                        {
                                            Console.Write("Nhập điểm thi: "); examScore = Console.ReadLine();
                                        } while (!Helper.IsInRange(decimal.Parse(examScore)) || !Helper.IsDecimal(examScore));

                                        eCSR.CourseWorkScore = decimal.Parse(courseWorkScore);
                                        eCSR.ExamScore = decimal.Parse(examScore);
                                        enrolledCoursesStudentRegisterService.Add(eCSR);
                                        HelperColor.WriteLineWithColor("Chỉnh sửa thành công!", ConsoleColor.Green);

                                    }
                                    else
                                    {
                                        HelperColor.WriteLineWithColor("Không tìm thấy sinh viên!", ConsoleColor.Red);

                                    }
                                }
                                else
                                {
                                    HelperColor.WriteLineWithColor("Không có học phần được nhập !", ConsoleColor.DarkRed);

                                }
                            }
                            else
                            {
                                HelperColor.WriteLineWithColor("Không có  HK được nhập đó !", ConsoleColor.DarkRed);
                            }


                        }
                        break;
                    case 6:
                        // Thực hiện chức năng xem kết quả trượt đỗ của sinh viên
                        // Thực hiện chức năng nhập điểm của sinh viên
                        // Hiển thị môn cần nhập điểm
                        semesterService.ShowList(semesterDapper.GetAll());
                        Console.Write("Nhập số ID Học Kỳ cần nhập điển: ");
                        idSemester = Console.ReadLine();
                        // lấy TBL_EnrolledCourses
                        enrolledCourses = enrolledCoursesDapperData.GetAll().Where(x => x.IDSemester == idSemester).ToList();


                        if (enrolledCourses.Count > 0)
                        {
                            // danh sách môn học
                            enrolledCoursesService.ShowList(enrolledCourses);

                            //Hiển thị danh sách sinh viên và điểm
                            Console.Write("Nhập số ID môn cần xem điểm: ");
                            idEnrolledCourses = int.Parse(Console.ReadLine());
                            var dataTableESR = enrolledCoursesStudentRegisterDapperData.GetListStudent_Fail_Pass(idEnrolledCourses);
                           
                            if (dataTableESR.Rows.Count > 0)
                            {
                                enrolledCoursesStudentRegisterService.ShowListStudent_Fail_Pass(dataTableESR);
                            }
                            else
                            {
                                HelperColor.WriteLineWithColor("Không có học phần được nhập !", ConsoleColor.DarkRed);

                            }
                        }
                        else
                        {
                            HelperColor.WriteLineWithColor("Không có  HK được nhập đó !", ConsoleColor.DarkRed);
                        }

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
