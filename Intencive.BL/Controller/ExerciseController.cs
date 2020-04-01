using Intencive.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intencive.BL.Controller
{
    public class ExerciseController : BaseController
    {
        private const string EXERCISES_FILE_NAME = "exercise.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime stop)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act==null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, stop, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, stop, act, user);
                Exercises.Add(exercise);
            }
            Save();

        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
