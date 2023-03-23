using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
