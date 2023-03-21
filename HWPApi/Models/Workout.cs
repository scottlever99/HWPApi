namespace HWPApi.Models
{
    public class Workout
    {
        public WorkoutPlan Plan { get; set; }
        public List<WorkoutTask> Tasks { get; set; }
    }
}
