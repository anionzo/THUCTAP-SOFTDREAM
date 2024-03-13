--- DATABASE
--USE master
CREATE DATABASE QUANLY_SINHVIEN
GO
USE QUANLY_SINHVIEN
GO

---- trường
CREATE TABLE TBL_University(
    IDUniversity NVARCHAR(25) PRIMARY KEY,
    NameUniversity NVARCHAR(150) NOT NULL,
    Address NVARCHAR(150),
    PhoneNumber NVARCHAR(20), 
    Email NVARCHAR(100) 
);

--- khoa
CREATE TABLE TBL_Department(
	IDDepartment NVARCHAR(25) PRIMARY KEY,
	NameDepartment NVARCHAR(150) NOT NULL,
	PhoneNumber NVARCHAR(11),
	IDUniversity NVARCHAR(25) NOT NULL, 
	Email NVARCHAR(100)
)
GO
-- bộ môn
CREATE TABLE TBL_Discipline(
	IDDiscipline NVARCHAR(25) PRIMARY KEY,
	NameDiscipline NVARCHAR(150) NOT NULL,
	IDDepartment NVARCHAR(25)
)
GO
--- giảng viên
CREATE TABLE TBL_Lecturers(
	IDLecturer NVARCHAR(25) PRIMARY KEY,
	NameLecturer NVARCHAR(150) NOT NULL,
	DayAdmission DATE , ---- ngày vào trường
	DateOfBirth DATE NOT NULL,
	Gender NVARCHAR(10) CHECK (Gender IN (N'Nam',N'Nữ',N'Không')),
	Education NVARCHAR(50), -- học vấn
	PhoneNumber NVARCHAR(11) UNIQUE,
	CCCD NVARCHAR(12) UNIQUE,
	IDDiscipline NVARCHAR(25),
	Ethnicity NVARCHAR(30), -- daan toc
	Religion NVARCHAR(30), --- tông giáo
	PermanentAddress NVARCHAR(150) , --- địa chỉ thường trú
	ImageAvatar NVARCHAR(200),
	Status NVARCHAR(30) CHECK (Status IN (N'Đang làm',N'Nghỉ làm')) ---- trạng thái
)
GO

-- sinh viên
CREATE TABLE TBL_Student(
	MSSV NVARCHAR(25) PRIMARY KEY,
	NameStudenr NVARCHAR(150) NOT NULL,
	DayAdmission DATE ,
	DateOfBirth DATE NOT NULL,
	Gender NVARCHAR(10) CHECK (Gender IN (N'Nam',N'Nữ',N'Không')),
	Education NVARCHAR(50),
	PhoneNumber NVARCHAR(11) UNIQUE,
	CCCD NVARCHAR(12) UNIQUE,
	IDDiscipline NVARCHAR(25),
	Ethnicity NVARCHAR(30), -- dân tộc
	Religion NVARCHAR(30),
	PermanentAddress NVARCHAR(150) ,
	ImageAvatar NVARCHAR(200),
	Status NVARCHAR(30) CONSTRAINT CK_TBL_Student_Status CHECK  (Status IN (N'Đang học',N'Nghỉ học',N'Đã tốt nghiệp')) -- trạng thái
	)
GO

----- Môn Hoc
CREATE TABLE TBL_Subject(
	IDSubject NVARCHAR(25) PRIMARY KEY,
	NameSubject NVARCHAR(150) NOT NULL,
	IDDepartment NVARCHAR(25),
	Credits INT CONSTRAINT CK_Credits CHECK (Credits >= 0),
	CourseworkWeight decimal(5,2), --- tỉ lệ điểm của điểm quá trình 0.3, 0.5, 0.4 .... 
	CourseType  NVARCHAR(30) CONSTRAINT CK_CourseType  CHECK (CourseType  IN (N'Lý thuyết',N'Thực hành')) -- loại khoa học
)
GO

------------ Học Kỳ
CREATE TABLE TBL_Semester(
    IDSemester INT IDENTITY(1,1) PRIMARY KEY,
    NameSemester NVARCHAR(50),
    YearStart INT check (YearStart >= 0),
    YearEnd INT check (YearEnd >= 0)
		--- THỂ HIỆN: HK1 -2020 -2021

)
GO

--- khóa học đăng ký
CREATE TABLE TBL_EnrolledCourses(
	IDEnrolledCourses INT IDENTITY(1,1) PRIMARY KEY,
	IDSubject NVARCHAR(25) NOT NULL,
	IDLecturer NVARCHAR(25),
	IDSemester INT NOT NULL,
	StartDate  DATE,
	EndDate DATE,
	ExpectedClass NVARCHAR(10) NOT NULL, -- 11DHTH4
	Capacity INT
)
GO

CREATE TABLE TBL_EnrolledCourses_Student_Register(
	MSSV NVARCHAR(25) NOT NULL,
	IDEnrolledCourses INT,
	CourseWorkScore DECIMAL(4,2), -- điểm quá trình 
	ExamScore DECIMAL(4,2), ----diểm thi
	TotalScore DECIMAL(4,2), ---- điểm tổng,
	primary key (MSSV,IDEnrolledCourses)
)
GO



CREATE TABLE TBL_Account(
	IDAcount INT IDENTITY(1,1) PRIMARY KEY,
	UserName NVARCHAR(25) NOT NULL UNIQUE, --- LÀ MSSV HOẶC MAGV
	Password NVARCHAR(150) DEFAULT '@HUIT140'
)
GO

---- TẠO RÀNG BUỘC KHÓA NGOẠI
---- TBL_Department
ALTER TABLE TBL_Department 
	ADD CONSTRAINT FK_KHOA_TRUONG 
		FOREIGN KEY (IDUniversity) REFERENCES TBL_University (IDUniversity)
GO
----- TBL_Discipline
ALTER TABLE TBL_Discipline 
	ADD CONSTRAINT FK_TBL_BOMON_TBL_KHOA 
		FOREIGN KEY (IDDepartment) REFERENCES TBL_Department(IDDepartment)
GO
---- TBL_Lecturers
ALTER TABLE TBL_Lecturers ADD CONSTRAINT FK_TBL_GIANGVIEN_MABOMON
	FOREIGN KEY (IDDiscipline) REFERENCES TBL_Discipline(IDDiscipline)
GO

----TBL_Student
ALTER TABLE TBL_Student ADD CONSTRAINT FK_TBL_Student_TBL_BOMON
	FOREIGN KEY (IDDiscipline) REFERENCES TBL_Discipline(IDDiscipline)
GO

---- TBL_Subject
ALTER TABLE TBL_Subject ADD CONSTRAINT FK_TBL_Subject_TBL_KHOA 
		FOREIGN KEY (IDDepartment) REFERENCES TBL_Department(IDDepartment)
GO

----- TBL_EnrolledCourses
ALTER TABLE TBL_EnrolledCourses ADD CONSTRAINT FK_TBL_EnrolledCourses_TBL_Lecturers
	FOREIGN KEY (IDLecturer) REFERENCES TBL_Lecturers(IDLecturer)
GO
ALTER TABLE TBL_EnrolledCourses ADD CONSTRAINT FK_TBL_EnrolledCourses_TBL_Subject
	FOREIGN KEY (IDSubject) REFERENCES TBL_Subject(IDSubject)
GO
ALTER TABLE TBL_EnrolledCourses ADD CONSTRAINT FK_TBL_EnrolledCourses_TBL_Semester
	FOREIGN KEY (IDSemester) REFERENCES TBL_Semester(IDSemester)
GO

----- TBL_EnrolledCourses_Student_Register
ALTER TABLE  TBL_EnrolledCourses_Student_Register ADD CONSTRAINT FK_TBL_EnrolledCourses_Student_Register_TBL_EnrolledCourses
	FOREIGN KEY (IDEnrolledCourses) REFERENCES TBL_EnrolledCourses(IDEnrolledCourses)
GO
ALTER TABLE  TBL_EnrolledCourses_Student_Register ADD CONSTRAINT FK_TBL_EnrolledCourses_Student_Register_TBL_Student
	FOREIGN KEY (MSSV) REFERENCES TBL_Student(MSSV)
GO
---- TBL_Account
ALTER TABLE TBL_Account ADD CONSTRAINT FK_TBL_Account_TBL_Student
	FOREIGN KEY (UserName) REFERENCES TBL_Student(MSSV)
GO

ALTER TABLE TBL_Account ADD CONSTRAINT FK_TBL_Account_TBL_Lecturers
	FOREIGN KEY (UserName) REFERENCES TBL_Lecturers(IDLecturer)
GO


