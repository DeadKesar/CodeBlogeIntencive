using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Intencive.BL.Model;
using System.Linq;

namespace Intencive.BL.Controller
{
    public class UserController
    {
        public List<User> Users { get; }
        public User CurentUser { get; }
        public bool isNewUser { get; } = false;
        public UserController( string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("Name is not exist.", nameof(userName));
            }
            Users = GetUsersList();
            CurentUser = Users.SingleOrDefault<User>(x => x.Name == userName);
            if(CurentUser == null)
            {
                CurentUser = new User(userName);
                Users.Add(CurentUser);
                isNewUser = true;
                Save();
            }
        }
        public void SetNewUserData(string genderName, DateTime birth, double weight =1, double height = 1)
        {
            #region tryCode
            if (genderName == null)
            {
                throw new ArgumentNullException("Gender must be setting", nameof(genderName));
            }
            if (birth == null)
            {
                throw new ArgumentNullException("Need date of birth", nameof(birth));
            }
            if (birth < new DateTime(1900, 01, 01))
            {
                new ArgumentException("You are too old for this app", nameof(birth));
            }
            if (birth > DateTime.Now)
            {
                throw new ArgumentException("Hey, how future look?", nameof(birth));
            }
            if (weight < 0.0 || weight > 700)
            {
                throw new ArgumentException("your Weigh is wrong or too Anomaly", nameof(weight));
            }
            if (height < 0 || height > 400)
            {
                throw new ArgumentException("Your Height is wrong or anomaly", nameof(height));
            }
            #endregion
            CurentUser.Gender = new Gender(genderName);
            CurentUser.Birth = birth;
            CurentUser.Weight = weight;
            CurentUser.Height = height;
            Save();
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
            CurentUser = new User(userName, sex, birth, weight, height);
            isNewUser = true;
            Users = GetUsersList();
            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save ()
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream ("user.dat",FileMode.OpenOrCreate))
            {
                bin.Serialize(file, Users);
            }
        }
        /// <summary>
        /// Получить список данных пользователей.
        /// </summary>
        /// <returns>Список из файла user.dat.</returns>
        private List<User> GetUsersList()
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (file.Length > 1 && bin.Deserialize(file) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public override bool Equals(object obj)
        {
            var temp = obj as UserController;
            if(this.CurentUser.Age==temp.CurentUser.Age && this.CurentUser.Birth == temp.CurentUser.Birth && this.CurentUser.Gender == temp.CurentUser.Gender
                && this.CurentUser.Height == temp.CurentUser.Height && this.CurentUser.Weight == temp.CurentUser.Weight)
            {
                return true;
            }
            return false;
        }
    }
}
