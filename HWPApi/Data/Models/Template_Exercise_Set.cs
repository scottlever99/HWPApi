using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class Template_Exercise_Set
    {
        [Key]
        public int Id { get; set; }
        public int TempExId { get; set; }
        public int SeqNo { get; set; }
        public string Previous { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
    }
}
