using System.ComponentModel.DataAnnotations;

namespace HWPApi.Models
{
    public class WorkoutTask
    {
        [Key]
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
