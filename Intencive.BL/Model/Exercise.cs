using System;


namespace Intencive.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime start { get; set; }
        public DateTime Finish { get; set; }

        public Activity Activity { get; set; }

        public User User { get; set; }

        public Exercise(DateTime start,DateTime finish, Activity activity, User user)
        {

            // Проверить
            this.start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
