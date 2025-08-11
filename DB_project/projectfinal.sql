CREATE DATABASE university;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Instructors (
    InstructorID INT PRIMARY KEY,
    InstructorName VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    InstructorID INT,
    FOREIGN KEY (InstructorID) REFERENCES Instructors(InstructorID)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(100),
    Email VARCHAR(100)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    Grade CHAR(2),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

INSERT INTO Departments VALUES 
(1, 'Computer Science'),
(2, 'IT');

INSERT INTO Instructors VALUES 
(1, 'Dr. Ahmed', 1),
(2, 'Dr. Mona', 2);

INSERT INTO Courses VALUES 
(101, 'Data Structures', 3, 1),
(102, 'Network', 4, 2);

INSERT INTO Students VALUES 
(1001, 'Salma Azoz', 'salma@gmail.com'),
(1002, 'Yossef Ahmed', 'yossef@gmail.com');

INSERT INTO Enrollments VALUES 
(1, 1001, 101, 'A'),
(2, 1002, 101, 'B'),
(3, 1001, 102, 'C');
---Table1---
---Create---
CREATE PROCEDURE AddStudent (
    @StudentID INT,
    @StudentName VARCHAR(100),
    @Email VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Students (StudentID, StudentName, Email)
        VALUES (@StudentID, @StudentName, @Email);
        PRINT 'Student added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding student: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Read---
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Students;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving students: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Update---
CREATE PROCEDURE UpdateStudentEmail (
    @StudentID INT,
    @NewEmail VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        UPDATE Students
        SET Email = @NewEmail
        WHERE StudentID = @StudentID;
        PRINT 'Email updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating student email: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Delete
CREATE PROCEDURE DeleteStudent (
    @StudentID INT
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Students
        WHERE StudentID = @StudentID;
        PRINT 'Student deleted successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error deleting student: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Table2---
---Create--
CREATE PROCEDURE AddDepartment (
    @DepartmentID INT,
    @DepartmentName VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Departments (DepartmentID, DepartmentName)
        VALUES (@DepartmentID, @DepartmentName);
        PRINT 'Department added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding department: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Read---
CREATE PROCEDURE GetAllDepartments
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Departments;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving departments: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Update---
CREATE PROCEDURE UpdateDepartmentName (
    @DepartmentID INT,
    @NewName VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        UPDATE Departments
        SET DepartmentName = @NewName
        WHERE DepartmentID = @DepartmentID;
        PRINT 'Department name updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating department: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Delete---
CREATE PROCEDURE DeleteDepartment (
    @DepartmentID INT
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Departments
        WHERE DepartmentID = @DepartmentID;
        PRINT 'Department deleted successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error deleting department: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Table 3---
---Create--
CREATE PROCEDURE AddInstructor (
    @InstructorID INT,
    @InstructorName VARCHAR(100),
    @DepartmentID INT
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Instructors (InstructorID, InstructorName, DepartmentID)
        VALUES (@InstructorID, @InstructorName, @DepartmentID);
        PRINT 'Instructor added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding instructor: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Read--
CREATE PROCEDURE GetAllInstructors
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Instructors;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving instructors: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Update---
CREATE PROCEDURE UpdateInstructorName (
    @InstructorID INT,
    @NewName VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        UPDATE Instructors
        SET InstructorName = @NewName
        WHERE InstructorID = @InstructorID;
        PRINT 'Instructor name updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating instructor: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Delete
CREATE PROCEDURE DeleteInstructor (
    @InstructorID INT
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Instructors
        WHERE InstructorID = @InstructorID;
        PRINT 'Instructor deleted successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error deleting instructor: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Table4---
---Create---
CREATE PROCEDURE AddCourse (
    @CourseID INT,
    @CourseName VARCHAR(100),
    @Credits INT,
    @InstructorID INT
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Courses (CourseID, CourseName, Credits, InstructorID)
        VALUES (@CourseID, @CourseName, @Credits, @InstructorID);
        PRINT 'Course added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding course: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Read--
CREATE PROCEDURE GetAllCourses
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Courses;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving courses: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Update---
CREATE PROCEDURE UpdateCourseName (
    @CourseID INT,
    @NewName VARCHAR(100)
)
AS
BEGIN
    BEGIN TRY
        UPDATE Courses
        SET CourseName = @NewName
        WHERE CourseID = @CourseID;
        PRINT 'Course name updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating course: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

---Delete---
CREATE PROCEDURE DeleteCourse (
    @CourseID INT
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Courses
        WHERE CourseID = @CourseID;
        PRINT 'Course deleted successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error deleting course: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Table5---
---Create--
CREATE PROCEDURE AddEnrollment (
    @EnrollmentID INT,
    @StudentID INT,
    @CourseID INT,
    @Grade CHAR(2)
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Enrollments (EnrollmentID, StudentID, CourseID, Grade)
        VALUES (@EnrollmentID, @StudentID, @CourseID, @Grade);
        PRINT 'Enrollment added successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error adding enrollment: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Read---
CREATE PROCEDURE GetAllEnrollments
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Enrollments;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving enrollments: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Update--
CREATE PROCEDURE UpdateGrade (
    @EnrollmentID INT,
    @NewGrade CHAR(2)
)
AS
BEGIN
    BEGIN TRY
        UPDATE Enrollments
        SET Grade = @NewGrade
        WHERE EnrollmentID = @EnrollmentID;
        PRINT 'Grade updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating grade: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Delete---

CREATE PROCEDURE DeleteEnrollment (
    @EnrollmentID INT
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Enrollments
        WHERE EnrollmentID = @EnrollmentID;
        PRINT 'Enrollment deleted successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error deleting enrollment: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
---Buissnes---
CREATE PROCEDURE ListStudentsInCourse
    @CourseID INT
AS
BEGIN
    BEGIN TRY
        SELECT S.StudentID, S.StudentName, E.Grade
        FROM Enrollments E
        INNER JOIN Students S ON E.StudentID = S.StudentID
        WHERE E.CourseID = @CourseID;
    END TRY
    BEGIN CATCH
        PRINT 'Error listing students in course: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;
CREATE PROCEDURE GetStudentTranscript
    @StudentID INT
AS
BEGIN
    BEGIN TRY
        SELECT C.CourseID, C.CourseName, E.Grade
        FROM Enrollments E
        INNER JOIN Courses C ON E.CourseID = C.CourseID
        WHERE E.StudentID = @StudentID;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving student transcript: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

CREATE PROCEDURE GetCoursesByInstructor
    @InstructorID INT
AS
BEGIN
    BEGIN TRY
        SELECT C.CourseID, C.CourseName, C.Credits,
               COUNT(E.EnrollmentID) AS NumberOfStudents
        FROM Courses C
        LEFT JOIN Enrollments E ON C.CourseID = E.CourseID
        WHERE C.InstructorID = @InstructorID
        GROUP BY C.CourseID, C.CourseName, C.Credits;
    END TRY
    BEGIN CATCH
        PRINT 'Error retrieving courses by instructor: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
	End;
	CREATE PROCEDURE GetCourseAverageGrade
    @CourseID INT
AS
BEGIN
    BEGIN TRY
        SELECT CourseID,
               AVG(CASE Grade
                     WHEN 'A' THEN 4.0
                     WHEN 'B' THEN 3.0
                     WHEN 'C' THEN 2.0
                     WHEN 'D' THEN 1.0
                     WHEN 'F' THEN 0.0
                     ELSE NULL
                   END) AS AverageGPA
        FROM Enrollments
        WHERE CourseID = @CourseID
        GROUP BY CourseID;
    END TRY
    BEGIN CATCH
        PRINT 'Error calculating course average grade: ' + ERROR_MESSAGE();
        THROW;
    END CATCH
END;

-- CREATE
EXEC AddStudent @StudentID = 1003, @StudentName = 'Laila Nabil', @Email = 'laila@gmail.com';

-- READ
EXEC GetAllStudents;

-- UPDATE
EXEC UpdateStudentEmail @StudentID = 1003, @NewEmail = 'laila.nabil@helwan.edu';

-- DELETE
EXEC DeleteStudent @StudentID = 1003;

-- CREATE
EXEC AddDepartment @DepartmentID = 3, @DepartmentName = 'Business';

-- READ
EXEC GetAllDepartments;

-- UPDATE
EXEC UpdateDepartmentName @DepartmentID = 3, @NewName = 'Business Administration';

-- DELETE
EXEC DeleteDepartment @DepartmentID = 3;

-- CREATE
EXEC AddInstructor @InstructorID = 3, @InstructorName = 'Dr. Hany', @DepartmentID = 1;

-- READ
EXEC GetAllInstructors;

-- UPDATE
EXEC UpdateInstructorName @InstructorID = 3, @NewName = 'Dr. Hany Saad';

-- DELETE
EXEC DeleteInstructor @InstructorID = 3;

-- CREATE
EXEC AddCourse @CourseID = 103, @CourseName = 'AI Basics', @Credits = 3, @InstructorID = 1;

-- READ
EXEC GetAllCourses;

-- UPDATE
EXEC UpdateCourseName @CourseID = 103, @NewName = 'AI Fundamentals';

-- DELETE
EXEC DeleteCourse @CourseID = 103;

-- CREATE
EXEC AddEnrollment @EnrollmentID = 4, @StudentID = 1001, @CourseID = 102, @Grade = 'A';

-- READ
EXEC GetAllEnrollments;

-- UPDATE
EXEC UpdateGrade @EnrollmentID = 4, @NewGrade = 'B';

-- DELETE
EXEC DeleteEnrollment @EnrollmentID = 4;

-- List all students in a course
EXEC ListStudentsInCourse @CourseID = 101;

-- Get a student's transcript
EXEC GetStudentTranscript @StudentID = 1001;

-- Get all courses taught by a specific instructor
EXEC GetCoursesByInstructor @InstructorID = 1;

EXEC AddDepartment @DepartmentID = 1, @DepartmentName = 'Duplicate Department';

-- Get the average GPA for a course
EXEC GetCourseAverageGrade @CourseID = 101;






