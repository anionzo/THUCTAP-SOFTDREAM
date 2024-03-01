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
	TotalScore DECIMAL(4,2) ---- điểm tổng
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


use QUANLY_SINHVIEN
-- Trường
INSERT INTO TBL_University (IDUniversity, NameUniversity, Address, PhoneNumber, Email)
VALUES ('UNI001', N'Đại học ABC', N'123 Đường ABC, Thành phố XYZ', '123456789', 'info@universityabc.com')
GO
 
-- Khoa
INSERT INTO TBL_Department (IDDepartment, NameDepartment, PhoneNumber, IDUniversity, Email)
VALUES ('DEP001', N'Khoa Khoa học Máy tính', '111222333', 'UNI001', 'cs@universityabc.com'),
       ('DEP002', N'Khoa Toán học', '444555666', 'UNI001', 'math@universityabc.com');
GO

-- Bộ môn
INSERT INTO TBL_Discipline (IDDiscipline, NameDiscipline, IDDepartment)
VALUES ('DIS001', N'Kỹ thuật Phần mềm', 'DEP001'),
       ('DIS002', N'Khoa học Dữ liệu', 'DEP001'),
	   ('DIS003', N'Mạng máy tính', 'DEP001'),
		('DIS004', 'Trí Tuệ Nhân Tạo', 'DEP001'),
		('DIS005', 'Tương Tác Người-Máy', 'DEP001'),
		('DIS006', 'An Toàn Thông Tin', 'DEP001'),
		('DIS007', 'Quản Trị Cơ Sở Dữ Liệu', 'DEP001');
GO


-- Giảng viên
INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES ('LEC001', N'John Doe', '2020-01-15', '1980-05-10', N'Nam', N'Tiến sĩ Khoa học Máy tính', '999888777', '123456789012', 'DIS001', N'Kinh', N'Không', N'456 Đường Main, Thành phố ABC',null, N'Đang làm');

INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status)
VALUES ('LEC002', N'Jane Smith', '2019-08-20', '1985-11-25', N'Nữ', N'Thạc sĩ Phân tích Dữ liệu', '666777888', '987654321098', 'DIS002', N'Kinh', N'Không', N'789 Đại lộ Oak, Thành phố XYZ', null, N'Đang làm');
 
INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES('LEC003', N'David Johnson', '2020-03-20', '1982-08-15', N'Nam', N'Tiến sĩ Kỹ thuật Máy tính', '333444555', '234567890123', 'DIS003', N'Kinh', N'Không', N'321 Đường Elm, Thành phố ABC', null, N'Đang làm');
	
INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES ('LEC004', N'Emily Brown', '2018-10-10', '1980-04-05', N'Nữ', N'Thạc sĩ Trí tuệ nhân tạo', '777888999', '345678901234', 'DIS004', N'Kinh', N'Không', N'456 Đại lộ Maple, Thành phố XYZ', null, N'Đang làm');

INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES('LEC005', N'Michael Wilson', '2019-05-15', '1975-12-20', N'Nam', N'Tiến sĩ Tương tác Người-máy', '111222333', '456789012345', 'DIS005', N'Kinh', N'Không', '789 Đại lộ Oak, Thành phố XYZ', null, N'Đang làm');

INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES ('LEC006', N'Sarah Martinez', '2021-01-10', '1988-03-25', N'Nữ', N'Thạc sĩ An ninh Mạng', '444555666', '567890123456', 'DIS006', N'Kinh', N'Không', N'123 Đường Pine, Thành phố ABC', null, N'Đang làm');
	
INSERT INTO TBL_Lecturers (IDLecturer, NameLecturer, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) 
VALUES ('LEC007', N'Daniel Thompson', '2020-09-05', '1983-06-10', N'Nam', N'Tiến sĩ Quản trị Cơ sở dữ liệu', '888999000', '678901234567', 'DIS007', N'Kinh', N'Không', N'987 Đại lộ Cedar, Thành phố XYZ', null, N'Đang làm');

-- Sinh viên
 
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV001', N'Alice Johnson', '2020-09-01', '2000-03-15', N'Nữ', N'Cử nhân Khoa học Máy tính', '111222333', '234567890123', 'DIS001', N'Kinh', N'Không', N'123 Đường Pine, Thành phố ABC', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV002', N'Bob Smith', '2019-08-15', '2001-01-20', N'Nam', N'Cử nhân Khoa học Dữ liệu', '444555666', '345678901234', 'DIS002', N'Kinh', N'Không', N'456 Đại lộ Maple, Thành phố XYZ', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV003', N'Trần Văn A', '2020-09-05', '2000-02-10', N'Nam', N'Cử nhân Khoa học Máy tính', '111222334', '234567890124', 'DIS001', N'Kinh', N'Không', N'456 Đường ABC, Thành phố XYZ', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV004', N'Nguyễn Thị B', '2019-08-20', '2001-03-20', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '444555667', '345678901235', 'DIS002', N'Kinh', N'Không', N'789 Đường XYZ, Thành phố ABC', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV005', N'Lê Văn C', '2020-01-15', '2000-01-15', N'Nam', N'Cử nhân Khoa học Máy tính', '333444555', '456789012345', 'DIS001', N'Kinh', N'Không', N'321 Đường DEF, Thành phố LMN', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV006', N'Phạm Thị D', '2019-08-10', '2001-05-05', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '777888999', '567890123456', 'DIS002', N'Kinh', N'Không', N'654 Đường GHI, Thành phố QRS', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV007', N'Hồ Văn E', '2020-03-20', '2000-07-25', N'Nam', N'Cử nhân Khoa học Máy tính', '222333444', '678901234567', 'DIS001', N'Kinh', N'Không', N'789 Đường JKL, Thành phố TUV', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV008', N'Đặng Thị F', '2018-10-10', '2001-09-30', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '555666777', '789012345678', 'DIS002', N'Kinh', N'Không', N'987 Đường MNO, Thành phố XYZ', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV009', N'Vũ Văn G', '2019-05-15', '2000-11-11', N'Nam', N'Cử nhân Khoa học Máy tính', '888999000', '890123456789', 'DIS001', N'Kinh', N'Không', N'654 Đường PQR, Thành phố STU', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV010', N'Hoàng Thị H', '2021-01-10', '2001-12-01', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '999000111', '901234567890', 'DIS002', N'Kinh', N'Không', N'321 Đường VWX, Thành phố YZA', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV011', N'Trần Văn I', '2020-09-01', '2000-08-02', N'Nam', N'Cử nhân Khoa học Máy tính', '123456789', '012345678901', 'DIS001', N'Kinh', N'Không', N'789 Đường BCD, Thành phố EFG', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV012', N'Nguyễn Thị K', '2019-08-15', '2001-10-03', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '234567890', '123456789012', 'DIS002', N'Kinh', N'Không', N'456 Đường HIJ, Thành phố KLM', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV013', N'Lê Văn L', '2020-09-05', '2000-09-04', N'Nam', N'Cử nhân Khoa học Máy tính', '345678901', '234555890123', 'DIS001', N'Kinh', N'Không', N'123 Đường NOP, Thành phố QRS', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV014', N'Phạm Thị M', '2019-08-20', '2001-11-05', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '456789012', '309078901234', 'DIS002', N'Kinh', N'Không', N'789 Đường TUV, Thành phố WXY', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV015', N'Hồ Văn N', '2020-01-15', '2000-12-06', N'Nam', N'Cử nhân Khoa học Máy tính', '567890123', '456769017745', 'DIS001', N'Kinh', N'Không', N'321 Đường XYZ, Thành phố ABC', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV016', N'Đặng Thị O', '2018-10-10', '2001-01-07', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '678901234', '566890129456', 'DIS002', N'Kinh', N'Không', N'654 Đường DEF, Thành phố GHI', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV017', N'Vũ Văn P', '2019-05-15', '2000-02-08', N'Nam', N'Cử nhân Khoa học Máy tính', '789012345', '678901000567', 'DIS001', N'Kinh', N'Không', N'987 Đường JKL, Thành phố MNO', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV018', N'Hoàng Thị Q', '2021-01-10', '2001-03-09', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '890123456', '789012311178', 'DIS002', N'Kinh', N'Không', N'123 Đường PQR, Thành phố STU', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV019', N'Trần Văn R', '2020-09-01', '2000-04-10', N'Nam', N'Cử nhân Khoa học Máy tính', '901234567', '890123456089', 'DIS001', N'Kinh', N'Không', N'456 Đường STU, Thành phố VWX', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV020', N'Nguyễn Thị S', '2019-08-15', '2001-05-11', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '012345678', '901234567891', 'DIS002', N'Kinh', N'Không', N'789 Đường YZA, Thành phố BCD', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV021', N'Lê Văn T', '2020-09-05', '2000-06-12', N'Nam', N'Cử nhân Khoa học Máy tính', '123345349', '012345678999', 'DIS001', N'Kinh', N'Không', N'321 Đường CDE, Thành phố FGH', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV022', N'Phạm Thị U', '2019-08-20', '2001-07-13', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '777777890', '111156789012', 'DIS002', N'Kinh', N'Không', N'654 Đường GHI, Thành phố JKL', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV023', N'Hồ Văn V', '2020-01-15', '2000-08-14', N'Nam', N'Cử nhân Khoa học Máy tính', '654678901', '234561110123', 'DIS001', N'Kinh', N'Không', N'123 Đường KLM, Thành phố NOP', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV024', N'Đặng Thị X', '2018-10-10', '2001-09-15', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '411189012', '345678966664', 'DIS002', N'Kinh', N'Không', N'456 Đường PQR, Thành phố STU', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV025', N'Vũ Văn Y', '2019-05-15', '2000-10-16', N'Nam', N'Cử nhân Khoa học Máy tính', '567822223', '456789098985', 'DIS001', N'Kinh', N'Không', N'789 Đường VWX, Thành phố YZA', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV026', N'Hoàng Thị Z', '2021-01-10', '2001-11-17', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '678902234', '567845453456', 'DIS002', N'Kinh', N'Không', N'987 Đường BCD, Thành phố EFG', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV027', N'Trần Văn 1', '2020-09-01', '2000-12-18', N'Nam', N'Cử nhân Khoa học Máy tính', '789222345', '678901234000', 'DIS001', N'Kinh', N'Không', N'654 Đường DEF, Thành phố GHI', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV028', N'Nguyễn Thị 2', '2019-08-15', '2001-01-19', N'Nữ', N'Cử nhân Khoa học Dữ liệu', '220123456', '789098785678', 'DIS002', N'Kinh', N'Không', N'321 Đường JKL, Thành phố MNO', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV029', N'Lê Văn 3', '2020-09-05', '2000-02-20', N'Nam', N'Cử nhân Khoa học Máy tính', '901232267', '890123456559', 'DIS001', N'Kinh', N'Không', N'987 Đường PQR, Thành phố STU', null, N'Đang học');
INSERT INTO TBL_Student (MSSV, NameStudenr, DayAdmission, DateOfBirth, Gender, Education, PhoneNumber, CCCD, IDDiscipline, Ethnicity, Religion, PermanentAddress, ImageAvatar, Status) VALUES('SV030', N'Lê Văn Bốn', '2020-09-05', '2000-02-20', N'Nam', N'Cử nhân Khoa học Máy tính', '901111267', '896868656559', 'DIS001', N'Kinh', N'Không', N'987 Đường PQR, Thành phố STU', null, N'Đang học');


-- Môn học
INSERT INTO TBL_Subject (IDSubject, NameSubject, IDDepartment, Credits, CourseworkWeight, CourseType) VALUES ('SUB001', N'Giới thiệu Lập trình', 'DEP001', 3, 0.3, N'Lý thuyết');
INSERT INTO TBL_Subject (IDSubject, NameSubject, IDDepartment, Credits, CourseworkWeight, CourseType) VALUES    ('SUB002', N'Hệ quản trị Cơ sở dữ liệu', 'DEP001', 4, 0.4, N'Lý thuyết');
INSERT INTO TBL_Subject (IDSubject, NameSubject, IDDepartment, Credits, CourseworkWeight, CourseType) VALUES     ('SUB003', N'Cấu trúc Dữ liệu và Giải thuật', 'DEP001', 3, 0.3, N'Lý thuyết');
INSERT INTO TBL_Subject (IDSubject, NameSubject, IDDepartment, Credits, CourseworkWeight, CourseType) VALUES   ('SUB004', N'Học máy', 'DEP001', 4, 0.4, N'Lý thuyết');
INSERT INTO TBL_Subject (IDSubject, NameSubject, IDDepartment, Credits, CourseworkWeight, CourseType) VALUES    ('SUB005', N'Dự án Kỹ thuật Phần mềm', 'DEP001', 6, 0.5, N'Thực hành');


-- Học kỳ
INSERT INTO TBL_Semester (NameSemester, YearStart, YearEnd)
VALUES ('HK1', 2020, 2021),
       ('HK2', 2020, 2021),
       ('HK1', 2021, 2022),
       ('HK2', 2021, 2022);
GO

-- Chi tiết môn học đăng ký
INSERT INTO TBL_EnrolledCourses (IDSubject, IDLecturer, IDSemester, StartDate, EndDate, ExpectedClass, Capacity)
VALUES ('SUB001', 'LEC001', 1, '2020-09-01', '2021-01-15', '11DHTH1', 50),
       ('SUB002', 'LEC002', 2, '2020-09-01', '2021-01-15', '11DHTH2', 60),
       ('SUB003', 'LEC001', 3, '2020-09-01', '2021-01-15', '11DHTH3', 45),
       ('SUB004', 'LEC002', 4, '2020-09-01', '2021-01-15', '11DHTH4', 55),
       ('SUB005', 'LEC001', 1, '2020-09-01', '2021-01-15', '11DHTH5', 40);

INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES ('SV001', 1, 8.5, 9.0, 8.75);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES ('SV002', 1, 7.8, 8.9, 8.35);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES ('SV001', 2, 8.9, 9.5, 9.2);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV002', 2, 7.5, 8.0, 7.75);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV001', 3, 9.0, 9.8, 9.4);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV002', 3, 8.2, 8.7, 8.45);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV001', 4, 8.7, 9.2, 8.95);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV002', 4, 7.1, 7.5, 7.3);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV001', 5, 8.4, 8.8, 8.6);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV002', 5, 8.0, 8.5, 8.25);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV003', 1, 8.0, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV004', 1, 7.2, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV005', 1, 8.7, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV006', 1, 6.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV007', 1, 9.2, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV008', 1, 7.8, 7.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV009', 1, 8.4, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV010', 1, 8.9, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV011', 1, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV012', 1, 8.1, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV013', 1, 8.3, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV014', 1, 7.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV015', 1, 9.0, 9.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV016', 1, 6.8, 7.4, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV017', 1, 8.7, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV018', 1, 7.9, 8.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV019', 1, 8.5, 9.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV020', 1, 7.3, 8.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV021', 1, 8.8, 9.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV022', 1, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV023', 1, 8.3, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV024', 1, 7.2, 7.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV025', 1, 8.6, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV026', 1, 7.4, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV027', 1, 8.2, 8.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV028', 1, 7.1, 7.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV029', 1, 8.9, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV030', 1, 7.8, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV003', 2, 8.0, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV004', 2, 7.2, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV005', 2, 8.7, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV006', 2, 6.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV007', 2, 9.2, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV008', 2, 7.8, 7.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV009', 2, 8.4, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV010', 2, 8.9, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV011', 2, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV012', 2, 8.1, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV013', 2, 8.3, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV014', 2, 7.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV015', 2, 9.0, 9.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV016', 2, 6.8, 7.4, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV017', 2, 8.7, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV018', 2, 7.9, 8.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV019', 2, 8.5, 9.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV020', 2, 7.3, 8.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV021', 2, 8.8, 9.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV022', 2, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV023', 2, 8.3, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV024', 2, 7.2, 7.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV025', 2, 8.6, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV026', 2, 7.4, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV027', 2, 8.2, 8.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV028', 2, 7.1, 7.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV029', 2, 8.9, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV030', 2, 7.8, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV003', 3, 8.0, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV004', 3, 7.2, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV005', 3, 8.7, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV006', 3, 6.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV007', 3, 9.2, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV008', 3, 7.8, 7.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV009', 3, 8.4, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV010', 3, 8.9, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV011', 3, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV012', 3, 8.1, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV013', 3, 8.3, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV014', 3, 7.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV015', 3, 9.0, 9.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV016', 3, 6.8, 7.4, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV017', 3, 8.7, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV018', 3, 7.9, 8.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV019', 3, 8.5, 9.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV020', 3, 7.3, 8.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV021', 3, 8.8, 9.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV022', 3, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV023', 3, 8.3, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV024', 3, 7.2, 7.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV025', 3, 8.6, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV026', 3, 7.4, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV027', 3, 8.2, 8.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV028', 3, 7.1, 7.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV029', 3, 8.9, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV030', 3, 7.8, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV003', 4, 8.0, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV004', 4, 7.2, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV005', 4, 8.7, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV006', 4, 6.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV007', 4, 9.2, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV008', 4, 7.8, 7.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV009', 4, 8.4, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV010', 4, 8.9, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV011', 4, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV012', 4, 8.1, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV013', 4, 8.3, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV014', 4, 7.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV015', 4, 9.0, 9.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV016', 4, 6.8, 7.4, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV017', 4, 8.7, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV018', 4, 7.9, 8.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV019', 4, 8.5, 9.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV020', 4, 7.3, 8.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV021', 4, 8.8, 9.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV022', 4, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV023', 4, 8.3, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV024', 4, 7.2, 7.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV025', 4, 8.6, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV026', 4, 7.4, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV027', 4, 8.2, 8.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV028', 4, 7.1, 7.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV029', 4, 8.9, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV030', 4, 7.8, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV003', 5, 8.0, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV004', 5, 7.2, 8.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV005', 5, 8.7, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV006', 5, 6.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV007', 5, 9.2, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV008', 5, 7.8, 7.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV009', 5, 8.4, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV010', 5, 8.9, 8.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV011', 5, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV012', 5, 8.1, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV013', 5, 8.3, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV014', 5, 7.5, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV015', 5, 9.0, 9.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV016', 5, 6.8, 7.4, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV017', 5, 8.7, 8.9, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV018', 5, 7.9, 8.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV019', 5, 8.5, 9.1, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV020', 5, 7.3, 8.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV021', 5, 8.8, 9.2, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV022', 5, 7.6, 8.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV023', 5, 8.3, 8.7, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV024', 5, 7.2, 7.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV025', 5, 8.6, 9.0, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV026', 5, 7.4, 7.8, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV027', 5, 8.2, 8.6, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV028', 5, 7.1, 7.5, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV029', 5, 8.9, 9.3, NULL);
INSERT INTO TBL_EnrolledCourses_Student_Register (MSSV, IDEnrolledCourses, CourseWorkScore, ExamScore, TotalScore) VALUES('SV030', 5, 7.8, 8.1, NULL);






