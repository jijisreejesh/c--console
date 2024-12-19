// using System.ComponentModel.Design;

// class Array1
// {
//     delegate Boolean Checking(Student stud);
//     static void Main()
//     {

//         String[] s = { "one", "two", "three" };
//         var a = s.Where(i => i.Contains('o'));
//         foreach (var i in a)
//             Console.WriteLine(i + " ");

//         IList<Student> std = new List<Student>{
//         new Student(){id=1,sname="Anu",age=23},
//         new Student(){id=2,sname="Veena",age=21},
//         new Student(){id=3,sname="Ganga",age=27},
//         new Student(){id=5,sname="Arun",age=24},
//        };
//         std.Add(new Student() { id = 4, sname = "Vinu", age = 22 });
//         //Multiple Where
//         var t = std.Where(i => i.age > 20 && i.age < 25).Where(i => i.sname == "Veena");
//         foreach (Student s1 in t)
//         {
//             Console.WriteLine(s1.sname);
//         }
//         Console.Write("Ascending Order names : ");
//         //AscendingOrder
//         var sOrder = std.OrderBy(i => i.sname);
//         foreach (Student s1 in sOrder)
//         {
//             Console.WriteLine(s1.sname);
//         }

//         //GroupBy
//         Console.Write("GroupBy Age : ");
//         var g = std.GroupBy(i => i.age);
//         foreach (var i in g)
//         {

//             Console.WriteLine($"Age: {i.Key}");

//         }
        
//         //Select
//         Console.Write("Select : ");
//         var sel=std.Select(i=> new {Name =i.sname,Age =i.age});
//         foreach(var i in sel){
//             Console.WriteLine(i);
//         }


//         //delegate Lambda expression
//         Checking c = s => s.age > 20 && s.age < 25;
//         Student stud = new Student() { age = 21 };
//         Console.WriteLine(c(stud));

//     }
// }

// public class Student
// {
//     public int id;
//     public int age;
//     public string sname;
// }