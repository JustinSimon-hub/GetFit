namespace GetFit_Application.Models
{
    public class Workout
    {

        //These models reflect the exercise portion of the project, differing from the Diet dashboard.
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Exercise { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int PR { get; set; }

    }
}
