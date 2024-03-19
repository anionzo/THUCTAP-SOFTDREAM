use QUANLY_SINHVIEN
go
CREATE FUNCTION dbo.GetNumberOfCoursesRegistered
(
    @SemesterID INT,
    @StudentID VARCHAR(50)
)
RETURNS INT
AS
BEGIN
    DECLARE @CountCourses INT;

    SELECT @CountCourses = COUNT(*)
    FROM TBL_Semester se
    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
    JOIN TBL_Student st ON st.MSSV = esr.MSSV
    WHERE se.IDSemester = @SemesterID AND esr.MSSV = @StudentID;

    RETURN @CountCourses
END
GO
--SELECT dbo.GetNumberOfCoursesRegistered(4, 'sv001') AS SoMH;


CREATE FUNCTION GetEnrolledCourseInfoForStudent(@StudentID VARCHAR(50))
RETURNS TABLE 
AS
RETURN (
		select esr.* , se.NameSemester,su.CourseworkWeight ,su.NameSubject from TBL_Semester se
		join TBL_EnrolledCourses ec on se.IDSemester = ec.IDSemester
		join TBL_EnrolledCourses_Student_Register esr on esr.IDEnrolledCourses = ec.IDEnrolledCourses
		join TBL_Subject su on su.IDSubject = ec.IDSubject
		join TBL_Student st on st.MSSV = esr.MSSV
		where  esr.MSSV	= @StudentID
)
GO
--SELECT * FROM GetEnrolledCourseInfoForStudent('SV001')

CREATE FUNCTION GetSubjectFailPass(@StudentID int)
RETURNS TABLE 
AS
RETURN (
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
        esr.MSSV = @StudentID 
)
go

--DROP FUNCTION GetSubjectFailPass;

--cŨ 

--CREATE FUNCTION dbo.GetCoursesRegistered
--(
--    @SemesterID INT,
--    @StudentID VARCHAR(50)
--)
--RETURNS TABLE 
--AS
--RETURN (
--    SELECT se.*, su.NameSubject, su.Credits, su.CourseworkWeight, su.CourseType, esr.*
--    FROM TBL_Semester se
--    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
--    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
--    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject
--    JOIN TBL_Student st ON st.MSSV = esr.MSSV
--    WHERE esr.MSSV = @StudentID AND se.IDSemester = @SemesterID
--)
--GO

----        DROP FUNCTION dbo.GetCoursesRegistered
--NEW 
CREATE FUNCTION dbo.GetCoursesRegistered
(
    @SemesterID INT,
    @StudentID VARCHAR(50)
)
RETURNS TABLE 
AS
RETURN (
  SELECT se.*,su.NameSubject,su.Credits, su.CourseType,ec.StartDate, ec.EndDate
    FROM TBL_Semester se
    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester
    JOIN TBL_EnrolledCourses_Student_Register esr ON esr.IDEnrolledCourses = ec.IDEnrolledCourses
    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject
    JOIN TBL_Student st ON st.MSSV = esr.MSSV
    WHERE esr.MSSV = @StudentID AND se.IDSemester = @SemesterID
)
GO

--        DROP FUNCTION dbo.GetCoursesRegistered




------------ TRIGER

CREATE TRIGGER CalculateTotalScore
ON TBL_EnrolledCourses_Student_Register
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @IDEnrolledCourses INT, @CourseWorkScore DECIMAL(4, 2), @ExamScore DECIMAL(4, 2), @CourseworkWeight DECIMAL(5, 2), @MSSV NVARCHAR(25);

    -- Lặp qua các dòng đã được chèn hoặc cập nhật
    DECLARE cursorCourses CURSOR FOR
        SELECT inserted.IDEnrolledCourses, inserted.CourseWorkScore, inserted.ExamScore, subjects.CourseworkWeight, inserted.MSSV
        FROM inserted
        JOIN TBL_EnrolledCourses courses ON inserted.IDEnrolledCourses = courses.IDEnrolledCourses
        JOIN TBL_Subject subjects ON courses.IDSubject = subjects.IDSubject;

    OPEN cursorCourses;

    FETCH NEXT FROM cursorCourses INTO @IDEnrolledCourses, @CourseWorkScore, @ExamScore, @CourseworkWeight, @MSSV;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @TotalScore DECIMAL(4, 2);
        SET @TotalScore = (@CourseworkWeight * @CourseWorkScore) + (@ExamScore * (1.0 - @CourseworkWeight));
        
        -- Cập nhật TotalScore cho dòng tương ứng
        UPDATE TBL_EnrolledCourses_Student_Register
        SET TotalScore = @TotalScore
        WHERE IDEnrolledCourses = @IDEnrolledCourses AND MSSV = @MSSV;

        FETCH NEXT FROM cursorCourses INTO @IDEnrolledCourses, @CourseWorkScore, @ExamScore, @CourseworkWeight, @MSSV;
    END

    CLOSE cursorCourses;
    DEALLOCATE cursorCourses;
END;


---- DROP TRIGGER IF EXISTS CalculateTotalScore;

GO

