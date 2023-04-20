using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public int enabled { get; set; }
        public int gateway { get; set; }

    }
}
