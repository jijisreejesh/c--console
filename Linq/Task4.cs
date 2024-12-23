
using System.Text.Json;

public class Students{
    public int Id{get;set;}
    public string Name{get;set;}
    public int Age{get;set;}
    public string Major{get;set;}
    public string Email{get;set;}
    public List<string> Skills{get;set;}
    public List<StudentCourses> StudentCourses{get;set;}
    public List<Awards> Awards{get;set;}
}
public class StudentCourses
{
    public string Name{get;set;}
    public int Credits{get;set;}
    public string Grade{get;set;}
}
public class Awards{
    public string Name{get;set;}
    public int Year{get;set;}
}
public class Majors{
    public int Id{get;set;}
    public string Name{get;set;}
}

public class Courses{
    public string Name{get;set;}
    public string Department{get;set;}
    public int MaxCredits{get;set;}
    public string Semester{get;set;}
}

public class AllStudents
{
    public List<Students> Students { get; set; }
    public List<Majors> Majors { get; set; }
    public List<Courses> Courses { get; set; }
}

class Task4{
    public static void Main(){
          string jsonString="""
{
  "Students": [
    {
      "Id": 1,
      "Name": "Emma Stone",
      "Age": 20,
      "Major": "Computer Science",
      "Email": "emma.stone@example.com",
      "Skills": ["Python", "Machine Learning", "Data Analysis"],
      "StudentCourses": [
        {"Name": "AI Foundations", "Credits": 3, "Grade": "A"},
        {"Name": "Data Structures", "Credits": 4, "Grade": "A-"}
      ],
      "Awards": [
        {"Name": "Dean's List", "Year": 2023},
        {"Name": "Coding Excellence", "Year": 2022}
      ]
    },
    {
      "Id": 2,
      "Name": "Liam Johnson",
      "Age": 23,
      "Major": "Electrical Engineering",
      "Email": "liam.johnson@example.com",
      "Skills": ["Circuit Design", "Embedded Systems", "Mathematics"],
      "StudentCourses": [
        {"Name": "Control Systems", "Credits": 3, "Grade": "B+"},
        {"Name": "Signal Processing", "Credits": 4, "Grade": "A"}
      ],
      "Awards": [
        {"Name": "Research Grant", "Year": 2023}
      ]
    },
    {
      "Id": 3,
      "Name": "Sophia Brown",
      "Age": 21,
      "Major": "Mathematics",
      "Email": "sophia.brown@example.com",
      "Skills": ["Statistics", "R", "Machine Learning"],
      "StudentCourses": [
        {"Name": "Probability Theory", "Credits": 3, "Grade": "A+"},
        {"Name": "Data Analysis", "Credits": 3, "Grade": "A"}
      ],
      "Awards": []
    }
  ],
  "Majors": [
    {"Id": 1, "Name": "Computer Science"},
    {"Id": 2, "Name": "Electrical Engineering"},
    {"Id": 3, "Name": "Mathematics"}
  ],
  "Courses": [
    {"Name": "AI Foundations", "Department": "CS", "MaxCredits": 4, "Semester": "Fall"},
    {"Name": "Control Systems", "Department": "EE", "MaxCredits": 4, "Semester": "Spring"},
    {"Name": "Probability Theory", "Department": "Math", "MaxCredits": 3, "Semester": "Fall"}
  ]
}
""";


 AllStudents? StudentDetails = JsonSerializer.Deserialize<AllStudents>(jsonString);

  // Grade mapping
        var gradeMap = new Dictionary<string, double>
        {
            { "A+", 4.3 }, { "A", 4.0 }, { "A-", 3.7 },
            { "B+", 3.3 }, { "B", 3.0 }, { "B-", 2.7 },
            { "C+", 2.3 }, { "C", 2.0 }, { "C-", 1.7 },
            { "D+", 1.3 }, { "D", 1.0 }, { "F", 0.0 }
        };


//  1. List all students proficient in "Machine Learning" who are below 22 years old and sort them by their grade point average (GPA) in descending order.



Console.WriteLine("2. Retrieve a list of students along with their major names, total credits completed, and the average grade they achieved.\n");
var ans2=StudentDetails.Students.Select(i=>new {
     StudentName=i.Name,
     Major=StudentDetails.Majors.Where(j=>j.Name==i.Major).Select(k=>k.Name),
     TotalCredits=i.StudentCourses.Sum(k=>k.Credits),
      AverageGrade = i.StudentCourses
                .Where(c => gradeMap.ContainsKey(c.Grade))
                .Select(d=> gradeMap[d.Grade])
                .Average()
});

foreach(var i in ans2)
{
  Console.Write($"StudentName : {i.StudentName} , TotalCredits : {i.TotalCredits} , AverageGrade : {i.AverageGrade}");
  foreach(var j in i.Major)
  {
    Console.WriteLine($" Major : {j}");
  }
  
}


//3. Find all students who have received more than one award and list their names along with the names of the awards.


//4. Group students by their major and calculate the total number of credits completed and the average GPA for each major.
//5. Find all courses offered in the "Fall" semester that have a maximum of 4 credits and list the students enrolled in those courses.





    }
}