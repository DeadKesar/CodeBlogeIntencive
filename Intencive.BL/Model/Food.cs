using System;


namespace Intencive.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }

        private double CaloriesOneGram { get { return Calories / 100.0; } }
        private double ProteinOneGram { get { return Proteins / 100.0; } }
        private double FatsOneGram { get { return Fats / 100.0; } }
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }

        public Food (string name) :this (name,0,0,0,0)
        {        }
        public Food(string name,double calories, double proteins, double fats, double carbohydrates)
        {
            #region проверка аргументов
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            if (proteins<0)
            {
                throw new ArgumentException("Proteins must be 0 or more", nameof(proteins));
            }
            if (fats<0)
            {
                throw new ArgumentException("fats must be 0 or more", nameof(fats));
            }
            if (carbohydrates<0)
            {
                throw new ArgumentException("Carbohydrates must be 0 or more", nameof(carbohydrates));
            }
            #endregion
            Name = name;
            Calories = calories/100.0;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            this.Carbohydrates = carbohydrates/100.0;
        }
        public override string ToString()
        {
            return Name + " - Callories:  " + Calories;
        }
    }
}
