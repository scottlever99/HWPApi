using HWPApi.Data.Models;

namespace HWPApi.Models
{
    public class TemplateExerciseModel
    {
        public TemplateExerciseModel(Exercise exercise, List<Template_Exercise_Set> sets)
        {
            Id = exercise.Id;
            Name = exercise.Name;
            Description = exercise.Description;
            Sets = sets;            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Template_Exercise_Set> Sets { get; set; }
    }
}
