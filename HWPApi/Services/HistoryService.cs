using HWPApi.Data;
using HWPApi.Data.Models;
using System.Net;

namespace HWPApi.Services
{
    public class HistoryService
    {
        private readonly HWPDatabase _dbContext;

        public HistoryService(HWPDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public List<History> GetHistoryForUser(int id) => _dbContext.History.Where(w => w.UserId == id).ToList();

        public bool Create(History history)
        {
            _dbContext.History.Add(history);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
