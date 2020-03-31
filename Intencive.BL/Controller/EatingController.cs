using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Intencive.BL.Model;

namespace Intencive.BL.Controller
{
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController( User user)
        {
            this.user = user ?? throw new ArgumentNullException("User must be not null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }


        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

            private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }
        public void Save()
        {
            Save(FOODS_FILE_NAME, (object)Foods);
            Save(EATINGS_FILE_NAME, (object)Eating);
        }
    }
}












//public bool Add (string foodName, double weight)
//{
//    var food = Foods.SingleOrDefault(f => f.Name == foodName);
//    if (food != null)
//    {
//        Eating.Add(food, weight);
//        Save();
//        return true;
//    }
//    return false;
//}