using HWPApi.Data.Models;

namespace HWPApi.Models
{
    public class TemplateModel
    {
        public TemplateModel(Template template, List<TemplateExerciseModel> exercises)
        {
            Id = template.Id;
            UserId = template.UserId;
            Name = template.Name;
            Note = template.Note;
            Exercies = exercises;            
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<TemplateExerciseModel> Exercies { get; set; }

    }
}
