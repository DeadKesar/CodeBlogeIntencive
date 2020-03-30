using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Intencive.BL.Model;
using System.Linq;
using System.Collections.Generic;

namespace Intencive.BL.Controller
{
    public class UserController
    {
        public User User { get; }
        List<User> users = new List<User>();
        public UserController()
        {

        }
        /// <summary>
        /// Создать юзера для сериализации.
        /// </summary>
        /// <param name="userName">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birth">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public UserController(string userName, string gender, DateTime birth, double weight, double height)
        {
            var sex = new Gender(gender);
            User = new User(userName, sex, birth, weight, height);
            users.Add(User);
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save ()
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream ("user.dat",FileMode.OpenOrCreate))
            {
                bin.Serialize(file, users);
            }
        }
        /// <summary>
        /// Загрузить данные пользователя по имени.
        /// </summary>
        /// <returns>Пользователя из файла user.dat.</returns>
        public UserController(string userName)
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (file.Length > 0)
                {
                    users = bin.Deserialize(file) as List<User>;
                    User = users.FirstOrDefault(x => x.Name == userName);
                }
            }
            
        }
        public static UserController TakeOrCreate()
        {
            Console.WriteLine("Enter user name");

            var name = Console.ReadLine();
            while (name.Length <= 1)
            {
                Console.WriteLine("name is wrong try again(too litlle.");
                name = Console.ReadLine();
            }
            var user = new UserController(name);
            if (user.User==null)
                {
                Console.WriteLine("Chose your gender");
                string genderName = Console.ReadLine();
                Console.WriteLine("Your Birth date");
                var birth = (DateTime.Parse(Console.ReadLine())); //TODO: TryParse
                Console.WriteLine("Enter uour weight");
                var weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter your height");
                var height = double.Parse(Console.ReadLine());
                var us = user.users;
                user = new UserController(name, genderName, birth, weight, height);
                us.Add(user.User);
                user.users = us;
                user.Save();
                }
            return user;
        }
    }
}
