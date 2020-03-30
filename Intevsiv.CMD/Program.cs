using Intencive.BL.Controller;

using System;

namespace Intevsiv.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow people. You in test intensive APP");
            Console.WriteLine("Enter user name");

            var name = Console.ReadLine();
            //if (name.Length<=1)
            //{

            //}
            Console.WriteLine("Chose your gender");
            string genderName = Console.ReadLine();
            Console.WriteLine("Your Birth date");
            var birth = (DateTime.Parse(Console.ReadLine())); //TODO: TryParse
            Console.WriteLine("Enter uour weight");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());

            var user = new UserController(name, genderName, birth, weight, height);
            user.Save();
        }
    }
}
