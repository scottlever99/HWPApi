using HWPApi.Data;
using HWPApi.Data.Models;

namespace HWPApi.Services
{
    public class ExerciseService
    {
        private readonly HWPDatabase _dbContext;

        public ExerciseService(HWPDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Exercise> GetAll()
        {
            return _dbContext.Exercise.ToList();
        }
    }
}
