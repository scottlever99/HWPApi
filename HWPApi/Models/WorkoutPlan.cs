using System.ComponentModel.DataAnnotations;

namespace HWPApi.Models
{
    public class WorkoutPlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Duration { get; set; }
    }
}
