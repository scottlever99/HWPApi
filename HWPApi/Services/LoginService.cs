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
            user = _dbContext.User.Where(w => w.Username ==  username && w.Password == password).FirstOrDefault();
            return user != null;
        }

    }
}
