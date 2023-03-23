using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
