using System;
using System.Collections.Generic;
using System.Linq;

namespace Intencive.BL.Model
{
    /// <summary>
    /// прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<Food,double> Foods { get; }

        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can not be null",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var value =  Foods.Keys.FirstOrDefault(x => x.Name.Equals(food.Name));
            if (value == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[value] += weight;
            }
        }
        public override string ToString()
        {
            return User.Name + "  "+ Foods.First().Key.Calories*Foods.First().Value;
        }
    }
}
