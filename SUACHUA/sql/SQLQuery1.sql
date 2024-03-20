CREATE FUNCTION GetSubjectFailPass(@IDEnrolledCourses int)
RETURNS TABLE 
AS
RETURN (
    SELECT 
        *,
        CASE 
            WHEN TotalScore >= 4 THEN N'Đậu'
            WHEN TotalScore < 4 THEN N'Rớt'
            ELSE N'Chưa có kết quả'
        END AS Result
    FROM 
        TBL_EnrolledCourses_Student_Register 
    WHERE 
        IDEnrolledCourses = @IDEnrolledCourses
)
go

select * from GetSubjectFailPass('sv001')

 SELECT 
        ROW_NUMBER() OVER (ORDER BY se.IDSemester) AS [STT],
		*,
        CASE 
            WHEN TotalScore >= 4 THEN N'Đậu'
            WHEN TotalScore < 4 THEN N'Rớt'
            ELSE N'Chưa có kết quả'
        END AS Result
    FROM 
	TBL_Semester se
	JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject
    WHERE  esr.MSSV = 'sv001'  
go 
select * from TBL_Subject

go
 SELECT 
        ROW_NUMBER() OVER (ORDER BY se.IDSemester) AS [STT],
		ec.IDEnrolledCourses, su.NameSubject, su.Credits, su.CourseType,esr.CourseWorkScore, esr.ExamScore,esr.TotalScore,
		CASE 
            WHEN TotalScore >= 4 THEN N'Đậu'
            WHEN TotalScore < 4 THEN N'Rớt'
            ELSE N'Chưa có kết quả'
        END AS Result
    FROM 
	TBL_Semester se
	JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject
    WHERE 
        esr.MSSV = 'sv001'    @IDEnrolledCourses