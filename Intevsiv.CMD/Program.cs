using Intencive.BL.Controller;

using System;

namespace Intevsiv.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellow people. You in test intensive APP");
            var user = UserController.TakeOrCreate();
            Console.WriteLine(user.User.Name);

        }
    }
}
