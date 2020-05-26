namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person p = new Person(name, age);
            Console.WriteLine(p);
            
        }
    }
}