
namespace Classes_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new instance of class Person and call it p1
            Person p1 = new Person();
            p1.PrintInfo();
            int inputYears = int.Parse(System.Console.ReadLine());
            Person p2 = new Person(inputYears);
            p2.PrintInfo();

        }
    }
}
