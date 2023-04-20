using HWPApi.Data;
using HWPApi.Data.Models;

namespace HWPApi.Services
{
    public class LoginService
    {
        private HWPDatabase _dbContext;

        public LoginService(HWPDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Login(string username, string password, out User? user)
        {
            user = _dbContext.User.Where(w => w.email ==  username && w.password == password).FirstOrDefault();
            return user != null;
        }

        public bool IsEnabled(int id)
        {
            var enabled = _dbContext.User.Where(w => w.id == id).Select(s => s.enabled).FirstOrDefault();
            return enabled == 1;
        }

        public bool IsEnabled(string email)
        {
            var enabled = _dbContext.User.Where(w => w.email == email).Select(s => s.enabled).FirstOrDefault();
            return enabled == 1;
        }
    }
}
