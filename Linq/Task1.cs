public class Person
{
    public string name;
    public int age;
    public string email;
    public List<String> hobbies;
}
class Task
{
    static void Main()
    {

        var p = new List<Person>
     {
       new Person(){
        name="John Doe",
        age=28,
        email="john.doe@example.com",
        hobbies=new List<string> {"Reading", "Swimming", "Coding"}
        },
       new Person(){
        name= "Jane Smith",
        age= 34,
        email= "jane.smith@example.com",
        hobbies=new List<string>{"Painting", "Running", "Cycling"}
        },
       new Person(){
         name= "Sam Brown",
        age=22,
        email="sam.brown@example.com",
        hobbies=new List<string> {"Gaming", "Music", "Cooking"}
        },
       new Person(){
         name= "Emily White",
        age= 45,
        email= "emily.white@example.com",
        hobbies=new List<string>{"Gardening", "Photography", "Traveling"}
        },
       new Person(){
         name= "Michael Green",
         age=29,
         email= "michael.green@example.com",
         hobbies=new List<string>{"Hiking", "Writing", "Swimming"}
        }
     };
     // Find all people who are older than 30.
     Console.WriteLine("\nFind all people who are older than 30.");
     var details=p.Where(i=>i.age>30);
     foreach(Person i in details){
        Console.Write($"Name : {i.name} , Age : {i.age} , Email : {i.email} , Hobbies : ");
        foreach(string h in i.hobbies){
            Console.Write(h+",");
        }
         Console.WriteLine();
        }
 

    // Extract only the names and email addresses of all people.
    Console.WriteLine("\nExtract only the names and email addresses of all people.");
    var selection=p.Select (i=>new {i.name,i.email});
     foreach(var i in selection){
       Console.WriteLine($"Name : {i.name} , Email : {i.email}");
     }
      
      //Sort the list of people by age in ascending order.
      Console.WriteLine("\nSort the list of people by age in ascending order.");
      var sortedList=p.OrderBy(i=>i.age);
      foreach(Person i in sortedList){
       Console.Write($"Name : {i.name} , Age : {i.age} , Email : {i.email} , Hobbies : ");
        foreach(string h in i.hobbies){
            Console.Write(h+",");
        }
         Console.WriteLine();
        }
      
      //Group people by the first letter of their name.
      Console.WriteLine("\nGroup people by the first letter of their name.");
      var firstLetter=p.GroupBy(i=>i.name[0]);
       foreach(var i in firstLetter){
       Console.Write($"FirstLetter Of Name {i.Key} : ");
        foreach(Person h in i){
            Console.Write(h.name+ " ");
        }
         Console.WriteLine();
        }

        // Find the average age of all people in the dataset.
        Console.WriteLine("\n Find the average age of all people in the dataset.");
        var avg=p.Average(i=>i.age);
        Console.WriteLine(avg);

        //Find the first person who has "Swimming" as a hobby.
        Console.WriteLine("\nFind the first person who has \"Swimming\" as a hobby");
        var checking=p.Find(i=>i.hobbies.Contains("Swimming"));
        Console.WriteLine($"First Person : {checking.name}");


        //List the names of people who are older than 25 and have "Cycling" as a hobby.
        Console.WriteLine("\nList the names of people who are older than 25 and have \"Cycling\" as a hobby.");
        var ans7=p.Where(i=>i.age>25).Where(i=>i.hobbies.Contains("Cycling"));
        foreach(var i in ans7){
            Console.WriteLine($"Name : {i.name}");
        }
        
        //Count the number of people who have more than two hobbies.
        Console.WriteLine("\nCount the number of people who have more than two hobbies.");
        var ans8=p.Count(i=>i.hobbies.Count>2);
        Console.WriteLine(ans8);

        //Check if there is any person whose name starts with 'E'
        Console.WriteLine("\nCheck if there is any person whose name starts with 'E'");
        var ans9=p.Any(i=>i.name[0]=='E');
        Console.WriteLine(ans9);

        //List all unique hobbies in the dataset.
        Console.WriteLine("\nList all unique hobbies in the dataset.");
        var ans10=p.SelectMany(i=>i.hobbies).Distinct();
        foreach(var i in ans10){
            Console.WriteLine(i);
        }
        }
     }
 
   