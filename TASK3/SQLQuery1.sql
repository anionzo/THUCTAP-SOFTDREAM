select *  from TBL_EnrolledCourses where IDSemester = 4

select * from TBL_EnrolledCourses_Student_Register  c where c.IDEnrolledCourses = 4


SELECT dbo.GetNumberOfCoursesRegistered(4, 'sv001') AS SoMH;

    SELECT se.*
    FROM TBL_Semester se
    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
    JOIN TBL_Student st ON st.MSSV = esr.MSSV
    WHERE se.IDSemester = 1 AND esr.MSSV = 'sv001';


	select * from TBL_Subject


	select se.*, su.* from TBL_Semester se
		join TBL_EnrolledCourses ec on se.IDSemester = ec.IDSemester
		join TBL_EnrolledCourses_Student_Register esr on esr.IDEnrolledCourses = ec.IDEnrolledCourses
		join TBL_Subject su on su.IDSubject = ec.IDSubject
		join TBL_Student st on st.MSSV = esr.MSSV
		where  esr.MSSV	= 'sv001' and se.IDSemester = 1


CREATE FUNCTION dbo.GetCoursesRegistered
(
    @SemesterID INT,
    @StudentID VARCHAR(50)
)
RETURNS TABLE 
AS
RETURN (
		select se.*, st,MSSV,su.NameSubject, su.Credits,su.CourseworkWeight,su.CourseType from TBL_Semester se
		join TBL_EnrolledCourses ec on se.IDSemester = ec.IDSemester
		join TBL_EnrolledCourses_Student_Register esr on esr.IDEnrolledCourses = ec.IDEnrolledCourses
		join TBL_Subject su on su.IDSubject = ec.IDSubject
		join TBL_Student st on st.MSSV = esr.MSSV
		where  esr.MSSV	= @StudentID and se.IDSemester =@SemesterID
)
GO

SELECT * FROM dbo.GetCoursesRegistered(1, 'sv001')
SELECT * FROM dbo.GetCoursesRegistered(2, 'sv001')
SELECT * FROM dbo.GetCoursesRegistered(3, 'sv001')
SELECT * FROM dbo.GetCoursesRegistered(4, 'sv001')
SELECT * FROM dbo.GetCoursesRegistered(5, 'sv001')


---- Câu 4


