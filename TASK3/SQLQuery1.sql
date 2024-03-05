select * from TBL_Semester where IDSemester = 1


select * from TBL_Discipline 

select * from TBL_Subject 
select * from TBL_Semester 
select * from TBL_Student st

select * from TBL_EnrolledCourses 
select * from TBL_EnrolledCourses_Student_Register

select * from TBL_Semester se, TBL_Student st


--- đến số môn học mà sinh viên đăng ký trong học kỳ
select COUNT(*) from TBL_Semester se
join TBL_EnrolledCourses ec on se.IDSemester = ec.IDSemester
join TBL_EnrolledCourses_Student_Register esr on esr.IDEnrolledCourses = ec.IDEnrolledCourses
join TBL_Student st on st.MSSV = esr.MSSV
where se.IDSemester =1 and esr.MSSV	= 'sv001'