using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class Template_Exercise
    {
        [Key]
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int ExerciseId { get; set; }
    }
}
