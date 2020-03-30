using System;

namespace Intencive.BL.Model
{


    /// <summary>
    /// Пользователь
    /// </summary>
     [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// пол.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birth { get; }
/// <summary>
/// Вес.
/// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birth">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name,
                    Gender gender,
                    DateTime birth,
                    double weight,
                    double height)
        {
            #region tryCode
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be NULL", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender must be setting", nameof(gender));
            }
            if (birth == null)
            {
                throw new ArgumentNullException("Need date of birth", nameof(birth));
            }
            if (birth < new DateTime(1900,01,01))
            {
                new ArgumentException("You are too old for this app",nameof(birth));
            }
            if (birth>DateTime.Now)
            {
                throw new ArgumentException("Hey, how future look?", nameof(birth));
            }
            if (Weight<0.0 || weight > 700)
            {
                throw new ArgumentException("your Weigh is wrong or too Anomaly",nameof(weight));
            }
            if (height<0 || height>400)
            {
                throw new ArgumentException("Your Height is wrong or anomaly",nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            Birth = birth;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return $"Name: {Name}; Gender: {Gender}; Birth: {Birth}; Weight: {Weight}; Height: {Height}.  ";
        }

    }
}
