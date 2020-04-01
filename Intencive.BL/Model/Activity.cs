using System;


namespace Intencive.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }

        public double CaloriesPerMinute { get; set; }

        public double Time { get; set; }

        public Activity(string name,double cal)
        {

            Name = name;
            CaloriesPerMinute = cal;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
