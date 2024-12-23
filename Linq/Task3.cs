
// using System.Text.Json;
// public class datas
// {
// public string jsonString=""" 
// {
//   "employees": [
//     {
//       "id": 1,
//       "name": "Alice Johnson",
//       "age": 30,
//       "departmentId": 1,
//       "email": "alice.johnson@example.com",
//       "skills": ["C#", "SQL", "Azure"],
//       "empprojects": [
//         {"name": "Project A", "hoursWorked": 120, "role": "Lead"},
//         {"name": "Project B", "hoursWorked": 100, "role": "Developer"}
//       ],
//       "evaluations": [
//         {"year": 2023, "score": 4.5},
//         {"year": 2022, "score": 4.7}
//       ]
//     },
//     {
//       "id": 2,
//       "name": "Bob Smith",
//       "age": 42,
//       "departmentId": 2,
//       "email": "bob.smith@example.com",
//       "skills": ["Marketing", "SEO", "Content Strategy"],
//       "empprojects": [
//         {"name": "Project A", "hoursWorked": 200, "role": "Manager"},
//         {"name": "Project C", "hoursWorked": 150, "role": "Consultant"}
//       ],
//       "evaluations": [
//         {"year": 2023, "score": 4.2},
//         {"year": 2022, "score": 4.0}
//       ]
//     },
//     {
//       "id": 3,
//       "name": "Carol White",
//       "age": 25,
//       "departmentId": 1,
//       "email": "carol.white@example.com",
//       "skills": ["JavaScript", "Vue.js", "CSS"],
//       "empprojects": [
//         {"name": "Project B", "hoursWorked": 90, "role": "Developer"},
//         {"name": "Project C", "hoursWorked": 110, "role": "Frontend Lead"}
//       ],
//       "evaluations": [
//         {"year": 2023, "score": 4.8},
//         {"year": 2022, "score": 4.6}
//       ]
//     }
//   ],
//   "departments": [
//     {"id": 1, "name": "Development"},
//     {"id": 2, "name": "Marketing"}
//   ],
//   "projects": [
//     {"name": "Project A", "budget": 50000, "deadline": "2024-12-31"},
//     {"name": "Project B", "budget": 30000, "deadline": "2024-06-30"},
//     {"name": "Project C", "budget": 40000, "deadline": "2024-09-30"}
//   ]
// }
// """; 


// }


// public class Employee
// {
//     public int id { get; set; }
//     public string name { get; set; }
//     public int age { get; set; }
//     public int departmentId { get; set; }
//     public string email { get; set; }
//     public List<string> skills { get; set; }
//     public List<EmployeeProject> empprojects { get; set; }
//     public List<Evaluation> evaluations { get; set; }
// }

// public class Evaluation
// {
//     public int year { get; set; }
//     public double score { get; set; }
// }
// public class EmployeeProject
// {
//     public string name { get; set; }
//     public int hoursWorked { get; set; }
//     public string role { get; set; }
// }

// public class Department
// {
//     public int id { get; set; }
//     public string name { get; set; }
// }
// public class Project
// {
//     public string name { get; set; }
//     public int budget { get; set; }
//     public string deadline { get; set; }
// }

// public class EmployeesDetails
// {
//     public List<Employee> employees { get; set; }
//     public List<Department> departments { get; set; }
//     public List<Project> projects { get; set; }
// }
// class Task3 : datas
// {
//     public static void Main()
//     {
//         datas d = new datas();
//         EmployeesDetails? employeesDetails = JsonSerializer.Deserialize<EmployeesDetails>(d.jsonString);


//         Console.WriteLine("\n1.Find all employees who are proficient in \"SQL\" and sort them by age in descending order.");
//         var ans1 = employeesDetails.employees.Where(i => i.skills.Contains("SQL")).OrderByDescending(i => i.age);
//         foreach (var i in ans1)
//         {
//             Console.WriteLine(i.name);
//         }


//         Console.WriteLine("\n2.Retrieve a list of employees along with the names of their departments and the total budget of the projects they are working on.");
//         var ans2 = employeesDetails.employees
//         .Select(i => new
//         {
//             EmployeeName = i.name,
//             DepartmentName = employeesDetails.departments
//          .Where(j => j.id == i.departmentId)
//          .Select(j => j.name)
//          .FirstOrDefault(),
//             TotalBudget = employeesDetails.projects
//          .Where(p => i.empprojects.Any(empProject => empProject.name == p.name))
//             .Sum(p => p.budget)
//         });
//         foreach (var i in ans2)
//         {
//             Console.WriteLine(i);
//         }


//         Console.WriteLine("\n3.List the names of employees and the total number of hours they have worked on all projects.");
//         var ans3 = employeesDetails.employees.Select(i => new
//         {
//             EmpName = i.name,
//             TotalHours = i.empprojects.Sum(j => j.hoursWorked)
//         });
//         foreach (var i in ans3)
//         {
//             Console.WriteLine(i);
//         }

//         Console.WriteLine("\n4.Group employees by the department and list the average evaluation score for each department for the year 2023.");
//         var ans4 = employeesDetails.employees
//          .Select(i => new
//          {
//              EmployeeName = i.name,
//              DepartmentName = employeesDetails.departments
//           .Where(j => j.id == i.departmentId)
//           .Select(j => j.name)
//           .FirstOrDefault(),
//         //    EvaluationScore =  i.evaluations.Where(h=>h.year==2023).Average(r=>r.score)
//          EvaluationScore =  i.evaluations.Where(h=>h.year==2023)
//          })
//           .GroupBy(k => k.DepartmentName);
//         foreach (var i in ans4)
//         {
//             Console.WriteLine($"Department : {i.Key}");
//             foreach (var j in i)
//             {
//                 Console.WriteLine($"{j.EmployeeName}");
//             }
//             var averageScore = i.Average(j=>j.EvaluationScore.Average(k=>k.score));
//            Console.WriteLine($"Average Score of evaluation : {averageScore}");
//         }
        


//           Console.WriteLine("\n6. List employees who have worked on more than one project in a managerial role (e.g., \"Lead\" or \"Manager\").");
//         var ans6=employeesDetails.employees 
//         .Where(i=>i.empprojects.Count(j=>j.role.Contains("Manager"))>1).Select(p=>new{EmpName=p.name});
//         if(ans6.Any())
//         {
//             foreach (var i in ans6)
//         {
//                 Console.WriteLine(i);   
//         }
//         }
//         else
//         {
//             Console.WriteLine("No Employees worked on more than one project in a managerial role");
//         }




//          Console.WriteLine("\n7. List all unique skills possessed by employees, ordered alphabetically.");
//         var ans7=employeesDetails.employees.SelectMany(i=>i.skills).Distinct().Order();
//         foreach (var i in ans7)
//         {
//                 Console.WriteLine(i);   
//         }
//          Console.WriteLine("\n8. Calculate the total budget for all projects and the average project budget.");
//          var ans8=employeesDetails.projects.Sum(i=>i.budget);
//          var average=employeesDetails.projects.Average(j=>j.budget);
//          Console.WriteLine($"Sum of Project Budget :{ans8}\nAverage of Project budget : {average}");


//          Console.WriteLine("\n9. Check if there are any employees who have a perfect evaluation score (5.0) for any year.");
//         var ans9=employeesDetails.employees.Any(i=>i.evaluations.Any(j=>j.score==5));
//         Console.WriteLine(ans9);



//        Console.WriteLine("\n10. Create a summary report listing each department's name, total number of employees, total hours worked on projects, and average evaluation score."); 
//         var ans10=employeesDetails.departments.Select(i=>new {
//             DepartmentName=i.name ,
//             NumberOfEmployees=employeesDetails.employees.Count(k=>k.departmentId==i.id),
//             TotalHoursWorked=employeesDetails.employees
//             .Where(r=>r.departmentId==i.id).SelectMany(s=>s.empprojects).Sum(total=>total.hoursWorked),
//             AverageEvaluationScore=employeesDetails.employees
//             .Where(r=>r.departmentId==i.id).SelectMany(s=>s.evaluations).Average(j=>j.score)
//          }).GroupBy(i=>i.DepartmentName);
//         foreach(var i in ans10)
//         {
//             Console.WriteLine($"DepartmentName : {i.Key}");
//             foreach(var k in i)
//             {
//                 Console.WriteLine($"Number of Employees : {k.NumberOfEmployees} , TotalHoursWorked:{k.TotalHoursWorked} ,  AverageEvaluationScore : {k.AverageEvaluationScore} ");
//             }
//         }
 



//          Console.WriteLine("\n11. For each project, list the names of the employees involved, their roles, and the total hours worked on that project");
//         var ans11=employeesDetails.employees.SelectMany(i=>i.empprojects.Select(
//             j=>new{
//                 Name=i.name,
//                 ProjectName=j.name,
//                 HoursWorked=j.hoursWorked,
//                 Role=j.role
//             }
//         )).GroupBy(i=>i.ProjectName);
//          foreach(var i in ans11)
//          {
//             Console.WriteLine(i.Key);
//             foreach(var j in i)
//             {
//                  Console.WriteLine($"  Name: {j.Name}, Role: {j.Role}, Hours Worked: {j.HoursWorked}");
//             }
//          }
         

//          Console.WriteLine("\n12. Generate a flat list of employee-project pairs showing the employee's name, project name, role, and hours worked.");
//          var ans12=employeesDetails.employees
//          .SelectMany(i=> i.empprojects.Select(j=>new {
//             EmployeeName = i.name,
//             ProjectName = j.name,
//             Role = j.role,
//             HoursWorked = j.hoursWorked
//          }));
//           foreach (var i in ans12)
//         {
//                 Console.WriteLine(i);   
//         }
    
    
//       Console.WriteLine("\n5.Find all projects that have a deadline within the next 6 months and list the employees involved in those projects.");
//      DateTime newDate = DateTime.Now.AddMonths(6);

//      var ans5=employeesDetails.projects
//      .Where(i=>DateTime.TryParse(i.deadline,out DateTime deadlineDate)&&deadlineDate<newDate &&deadlineDate>DateTime.Now)
//      .Select(i=>i.name);

//      var finalAns5=employeesDetails.employees
//      .Where(i=>i.empprojects.Any(j=>ans5.Contains(j.name)))
//      .Select(k=>new {EmpName=k.name , ProjectName=k.empprojects.Where(j=>ans5.Contains(j.name)).Select(k=>k.name)});

//      foreach(var i  in finalAns5){
//         Console.WriteLine(i.EmpName);
//          foreach(var j in i.ProjectName){
//           Console.WriteLine(j);
//          }
//      }   
        
//     }
// }