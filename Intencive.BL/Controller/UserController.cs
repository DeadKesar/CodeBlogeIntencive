using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Intencive.BL.Model;

namespace Intencive.BL.Controller
{
    public class UserController
    {
        public User User { get; }

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
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save ()
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream ("user.dat",FileMode.OpenOrCreate))
            {
                bin.Serialize(file, User);
            }
        }
        /// <summary>
        /// Загрузить данные пользователя.
        /// </summary>
        /// <returns>Пользователя из файла user.dat.</returns>
        public UserController()
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                User = bin.Deserialize(file) as User;
            }
            //TODO: Что делать если ползователя ещё нету.
        }
    }
}
