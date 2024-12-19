using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data.Common;
namespace MyNamespace {

    public class Projects{
        public string Name;
        public int HoursWorked;
    }
 public class Employee{
        public int Id;
         public string Name;
         public int Age;
         public string Email;
         public int DepartmentId;
         public List<Projects> Project;
         

 }
 public class Department{
    public int Id;
    public string Name; 
 }
 public class Emp{
    public List<Employee> Employees;
    public List<Department> Departments;
 }
     public class Task2Class{
       public static void Main(){
        var e=new Emp{
            Employees =new List<Employee>{

            new Employee 
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Age = 30,
                    Email = "alice.johnson@example.com",
                    DepartmentId = 1,
                    Project = new List<Projects>
                    {
                        new Projects { Name = "Project A", HoursWorked = 120 },
                        new Projects { Name = "Project B", HoursWorked = 100 }
                    }
                },
                new Employee 
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Age = 42,
                    Email = "bob.smith@example.com",
                    DepartmentId = 2,
                    Project = new List<Projects>
                    {
                        new Projects { Name = "Project A", HoursWorked = 200 },
                        new Projects { Name = "Project C", HoursWorked = 150 }
                    }
                },
                new Employee 
                {
                    Id = 3,
                    Name = "Carol White",
                    Age = 25,
                    Email = "carol.white@example.com",
                    DepartmentId = 1,
                    Project= new List<Projects>
                    {
                        new Projects { Name = "Project B", HoursWorked = 90 },
                        new Projects { Name = "Project C", HoursWorked = 110 }
                    }
                }
            },
            Departments = new List<Department>
            {
                new Department { Id = 1, Name = "Development" },
                new Department { Id = 2, Name = "Marketing" }
            }
        };

       }
     }
    
    }
