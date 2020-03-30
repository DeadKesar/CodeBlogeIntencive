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
            var userController = new UserController(name);
            if (userController.isNewUser == true)
            {
                Console.WriteLine("Chose your gender");
                string genderName = Console.ReadLine();
                DateTime birthDate = PArseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.SetNewUserData(genderName, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurentUser);
            Console.ReadLine();
        }

        private static DateTime PArseDateTime()
        {
 
            while (true)
            {
                Console.WriteLine("Ener your Birth date:");
                if (DateTime.TryParse(Console.ReadLine(), out var birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Incorrect date formate");
                }
            }
        }

        private static double ParseDouble(string name)
        {
                while (true)
                {
                    Console.WriteLine($"Ener your {name}:");
                    if(double.TryParse(Console.ReadLine(), out double value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect {name}");
                    }
                }
        }
    }
}













//Console.WriteLine("Chose your gender");
//string genderName = Console.ReadLine();
//Console.WriteLine("Your Birth date");
//var birth = (DateTime.Parse(Console.ReadLine())); //TODO: TryParse
//Console.WriteLine("Enter uour weight");
//var weight = double.Parse(Console.ReadLine());
//Console.WriteLine("Enter your height");
//var height = double.Parse(Console.ReadLine());

//var user = new UserController(name, genderName, birth, weight, height);
//user.Save();