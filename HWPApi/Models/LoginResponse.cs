namespace HWPApi.Models
{
    public class LoginResponse
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int enabled { get; set; }
        public int gateway { get; set; }
    }
}
