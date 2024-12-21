// using Microsoft.VisualBasic;
// using System.Collections.Generic;
// using System.Data.Common;
// using System.Globalization;
// namespace MyNamespace
// {

//     public class Projects
//     {
//         public string Name;
//         public int HoursWorked;
//     }
//     public class Employee
//     {
//         public int Id;
//         public string Name;
//         public int Age;
//         public string Email;
//         public int DepartmentId;
//         public List<Projects> Project;


//     }
//     public class Department
//     {
//         public int Id;
//         public string Name;
//     }
//     public class Emp
//     {
//         public List<Employee> Employees;
//         public List<Department> Departments;
//     }
//     class Task2Class
//     {
//         static void Main()
//         {
//             var e = new Emp
//             {
//                 Employees = new List<Employee>{

//             new Employee
//                 {
//                     Id = 1,
//                     Name = "Alice Johnson",
//                     Age = 35,
//                     Email = "alice.johnson@example.com",
//                     DepartmentId = 1,
//                     Project = new List<Projects>
//                     {
//                         new Projects { Name = "Project A", HoursWorked = 120 },
//                         new Projects { Name = "Project B", HoursWorked = 100 }
//                     }
//                 },
//                 new Employee
//                 {
//                     Id = 2,
//                     Name = "Bob Smith",
//                     Age = 42,
//                     Email = "bob.smith@example.com",
//                     DepartmentId = 2,
//                     Project = new List<Projects>
//                     {
//                         new Projects { Name = "Project A", HoursWorked = 200 },
//                         new Projects { Name = "Project C", HoursWorked = 150 }
//                     }
//                 },
//                 new Employee
//                 {
//                     Id = 3,
//                     Name = "Carol White",
//                     Age = 25,
//                     Email = "carol.white@example.com",
//                     DepartmentId = 1,
//                     Project= new List<Projects>
//                     {
//                         new Projects { Name = "Project B", HoursWorked = 90 },
//                         new Projects { Name = "Project C", HoursWorked = 110 }
//                     }
//                 }
//             },
//                 Departments = new List<Department>
//             {
//                 new Department { Id = 1, Name = "Development" },
//                 new Department { Id = 2, Name = "Marketing" }
//             }
//             };

//             //1.Find all employees who are older than 30 and work in the "Development" department.
//             Console.WriteLine("\n1.Find all employees who are older than 30 and work in the \"Development\" department.");
//             var first = e.Employees.Where(j => j.Age > 30 && e.Departments.Any(i => i.Name == "Development" && i.Id == j.DepartmentId));
//             foreach (var i in first)
//             {
//                 Console.WriteLine(i.Name);
//             }

//             //2. Retrieve the names of employees along with their department names.
//             Console.WriteLine("\n2.Retrieve the names of employees along with their department names.");
//             var selectNames = e.Employees.Join(
//              e.Departments,
//              empl => empl.DepartmentId,
//              depart => depart.Id,
//              (empl, depart) => new
//              {
//                  EmployeeName = empl.Name,
//                  DepartmentName = depart.Name
//              }
//             );
//             foreach (var i in selectNames)
//             {
//                 Console.WriteLine(i);
//             }


//             //3. List the names of employees and the total hours they have worked across all projects.
//             Console.WriteLine("\n3.List the names of employees and the total hours they have worked across all projects.");
//             var ans3 = e.Employees.Select(i => new { Name = i.Name, HoursWorked = i.Project.Sum(j => j.HoursWorked) });
//             foreach (var i in ans3)
//             {
//                 Console.WriteLine(i);
//             }

//             //4. Group employees by department and calculate the average age of employees in each department.
//             Console.WriteLine("\n 4.Group employees by department and calculate the average age of employees in each department.");
//             var ans4 = e.Employees.GroupBy(i => i.DepartmentId)
//             .Select(s => new
//             {
//                 DepartmentAverage = s.Average(j => j.Age),
//                 DepartmentName = e.Departments.FirstOrDefault(dept => dept.Id == s.Key)?.Name
//             });

//             foreach (var i in ans4)
//             {
//                 Console.WriteLine(i);
//             }


//             //5. Find the name of the employee who worked the most hours on "Project A"
//             // Console.WriteLine("\n5.Find the name of the employee who worked the most hours on \"Project A\"");
//             // var ans5 = e.Employees
//             //  .Where(i => i.Project.Any(p => p.Name == "Project A"))  
//             // .Select(i => new
//             // {
//             //     EmployeeName = i.Name,
//             //     MaxHoursWorked = i.Project.Max(p => p.HoursWorked)
//             // })
//             // .OrderByDescending(x => x.MaxHoursWorked) 
//             // .FirstOrDefault(); 

//             Console.WriteLine("\n5.Find the name of the employee who worked the most hours on \"Project A\"");
//             var ans5 = e.Employees
//              .Where(i => i.Project.Any(p => p.Name == "Project A"))
//             .Select(i => new
//             {
//                 EmployeeName = i.Name,
//                 MaxHoursWorked = i.Project.Max(p => p.HoursWorked)
//             })
//             .OrderByDescending(x => x.MaxHoursWorked) 
//             .FirstOrDefault(); 

//             if (ans5 != null)
//             {
//                 Console.WriteLine($"{ans5.EmployeeName} worked the most hours: {ans5.MaxHoursWorked} hours.");
//             }
//             else
//             {   
//                 Console.WriteLine("No employee found who worked on Project A.");
//             }


//             //6. Extract a list of employees with their names and the names of projects they have worked on.
//             Console.WriteLine("\n6.Extract a list of employees with their names and the names of projects they have worked on.");
//             var ans6=e.Employees.Select(i=>new {
//                 EmployeeName=i.Name,
//                 Projects=i.Project.Select(j=>j.Name)
//             });
//             foreach (var i in ans6)
//             {
//                 Console.WriteLine($"EmpName : {i.EmployeeName} , Projects : ");
//                 foreach(var j in i.Projects){
//                     Console.WriteLine(j);
//                 }
//             }
           
//             //7. List the names of employees who have worked more than 100 hours on any single project.
//             Console.WriteLine("\n7.List the names of employees who have worked more than 100 hours on any single project.");
//             var singleProject=e.Employees.Where(i=>i.Project.Any(j=>j.HoursWorked>100)).Select(i=>i.Name);
//             foreach(var i in singleProject)
//             {
//                 Console.WriteLine(i);
//             }



//             //8. Check if there is any employee who has worked on "Project D".
//             Console.WriteLine("\n8. Check if there is any employee who has worked on \"Project D\".");
//              var ans8 = e.Employees.Any(i => i.Project.Any(p => p.Name == "Project D")) ;
//              Console.WriteLine(ans8);


//             //9. List all unique project names across all employees.
//              Console.WriteLine("\n9. List all unique project names across all employees.");
//              var ans9=e.Employees.SelectMany(i=>i.Project.Select(j=>new {ProjectName=j.Name}))
//              .Distinct();
             
//              foreach(var i in ans9){
//                 Console.WriteLine(i);
//              }


//             //10. Calculate the total number of hours worked by all employees combined.
//             Console.WriteLine("\n10.Calculate the total number of hours worked by all employees combined.");
//             var ans10=e.Employees.Select(i=>new {Total=
//                 i.Project.Sum(j=>j.HoursWorked)
//             });
//             var finalAns=ans10.Sum(i=>i.Total);
//            Console.WriteLine($"Final Answer : {finalAns}");
//         }
//     }

// }
