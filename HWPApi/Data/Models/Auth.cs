using System.ComponentModel.DataAnnotations;

namespace HWPApi.Data.Models
{
    public class Auth
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
