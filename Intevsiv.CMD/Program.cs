using Intencive.BL.Controller;
using Intencive.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Intevsiv.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resoursesManeger = new ResourceManager("Intevsiv.CMD.Lang.Messages", typeof(Program).Assembly);
            Console.WriteLine(resoursesManeger.GetString("Hellow",culture));
            Console.WriteLine(resoursesManeger.GetString("EnterName",culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.isNewUser == true)
            {
                Console.WriteLine(resoursesManeger.GetString("EnterGender", culture));
                string genderName = Console.ReadLine();
                DateTime birthDate = PArseDateTime("date of birth");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.SetNewUserData(genderName, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurentUser);
            var eatingController = new EatingController(userController.CurentUser);

            var exerciseController = new ExerciseController(userController.CurentUser);


            while (true)
            {
                Console.WriteLine("what you want to do\n" +
                                  "E - enter eating(Ввести прием пищи)\n" +
                                  "A - Enter the exrcise \n" +
                                  "Q - exit \n");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {

                            var value = EnterEating();
                            eatingController.Add(value.Food, value.weight);
                            foreach (var item in eatingController.Eating.Foods)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            var cart = EnterExercise();
                            exerciseController.Add(cart.activity, cart.start, cart.stop);
                            foreach (var item in exerciseController.Exercises)
                            {
                                Console.WriteLine(item.User.Name + " " + item.start+" " + item.Activity+"\n"+item.Finish);
                            }
                            break;


                        }
                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }


                Console.ReadLine();
            }
        }

        private static (DateTime start,DateTime stop, Activity activity) EnterExercise()
        {
            Console.WriteLine("Enter exercise name:");
            var name = Console.ReadLine();
            var cal = ParseDouble("CAlories");
            var activity = new Activity(name, cal);
            var begin = PArseDateTime("exercise start");
            var end = PArseDateTime("exercise stop");
            return (begin, end, activity);


            throw new NotImplementedException();
        }

        private static (Food Food,double weight) EnterEating()
        {
            Console.Write("Enter product name");
            var name = Console.ReadLine();
            var weight = ParseDouble("weight");
            var callories = ParseDouble("Callories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            return (new Food(name, callories, proteins, fats, carbohydrates), weight);
        }

        private static DateTime PArseDateTime(string value)
        {
 
            while (true)
            {
                Console.WriteLine($"Ener your {value}:");
                if (DateTime.TryParse(Console.ReadLine(), out var Date))
                {
                    return Date;
                }
                else
                {
                    Console.WriteLine($"Incorrect date formate of {value}");
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