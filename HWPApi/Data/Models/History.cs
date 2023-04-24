using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TemplateName { get; set; }
        public string Duration { get; set; }
    }
}
