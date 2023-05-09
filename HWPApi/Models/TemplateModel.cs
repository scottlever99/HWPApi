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
            
            if (exercises.Count > 2) 
            {
                Exercise1 = $"{exercises[0].Sets.Count} x {exercises[0].Name}";
                Exercise2 = $"{exercises[1].Sets.Count} x {exercises[1].Name}";
                Exercise3 = $"{exercises[2].Sets.Count} x {exercises[2].Name}";
            }
            else
            {
                for(int i = 0; i < exercises.Count; i++)
                {
                    if (i == 0) Exercise1 = $"{exercises[i].Sets.Count} x {exercises[i].Name}";
                    if (i == 1) Exercise2 = $"{exercises[i].Sets.Count} x {exercises[i].Name}";
                    if (i == 2) Exercise3 = $"{exercises[i].Sets.Count} x {exercises[i].Name}";
                }
            }
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Exercise1 { get; set; } = "";
        public string Exercise2 { get; set; } = "";
        public string Exercise3 { get; set; } = "";
        public List<TemplateExerciseModel> Exercies { get; set; }

    }
}
