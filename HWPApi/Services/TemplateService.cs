using HWPApi.Data;
using HWPApi.Models;

namespace HWPApi.Services
{
    public class TemplateService
    {
        private readonly HWPDatabase dbContext;

        public TemplateService(HWPDatabase dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TemplateModel> GetTemplates()
        {
            var res = new List<TemplateModel>();

            var temps = dbContext.Template.ToList();

            foreach (var temp in temps)
            {
                var join = (from et in dbContext.Template_Exercise
                            join e in dbContext.Exercise on et.ExerciseId equals e.Id into ete
                            from e in ete.DefaultIfEmpty()
                            where et.TemplateId == temp.Id
                            select new { et, e }).ToList();

                List<TemplateExerciseModel> exModel = new();

                foreach (var exercise in join)
                {
                    var sets = dbContext.Template_Exercise_Set.Where(w => w.TempExId == exercise.et.Id).ToList();
                    exModel.Add(new TemplateExerciseModel(exercise.e, sets));
                }

                res.Add(new TemplateModel(temp, exModel));
            }

            return res;
        }

        public List<TemplateModel> GetTemplatesForUser(int userId)
        {
            var res = new List<TemplateModel>();

            var temps = dbContext.Template.Where(w => w.UserId == userId).ToList();

            foreach (var temp in temps)
            {
                var join = (from et in dbContext.Template_Exercise
                            join e in dbContext.Exercise on et.ExerciseId equals e.Id into ete
                            from e in ete.DefaultIfEmpty()
                            where et.TemplateId == temp.Id
                            select new { et, e }).ToList();

                List<TemplateExerciseModel> exModel = new();

                foreach (var exercise in join)
                {
                    var sets = dbContext.Template_Exercise_Set.Where(w => w.TempExId == exercise.et.Id).ToList();
                    exModel.Add(new TemplateExerciseModel(exercise.e, sets));
                }

                res.Add(new TemplateModel(temp, exModel));
            }

            return res;
        }
    }
}
