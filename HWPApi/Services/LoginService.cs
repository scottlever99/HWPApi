using HWPApi.Data;
using HWPApi.Models;

namespace HWPApi.Services
{
    public class LoginService
    {
        private HWPDatabase _dbContext;

        public LoginService(HWPDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Login(string username, string password, out LoginResponse? user)
        {
            var res = _dbContext.User.Where(w => w.email == username && w.password == password).FirstOrDefault();

            if (res == null)
            {
                user = null;
                return false;
            }

            user = new LoginResponse()
            {
                id = res.id,
                firstname = res.firstname,
                lastname = res.lastname,
                email = res.email,
                age = res.age,
                enabled = res.enabled,
                gateway = res.gateway
            };

            return true;
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
