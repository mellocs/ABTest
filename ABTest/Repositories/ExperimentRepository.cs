using ABTest.Database;
using ABTest.IRepositories;
using ABTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ABTest.Repositories
{
    public class ExperimentRepository : IExperimentRepository
    {
        private readonly ApplicationContext context;

        public ExperimentRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Experiment? GetExperimentByName(string experimentName)
        {
            return context.Experiments.Where(e => e.Name == experimentName).FirstOrDefault(); // Получаем эксперимент по его названию
        }

        public ICollection<Experiment> GetExperiments() // Получаем эксперименты и используем жадную загрузку для получения опций и девайсов связанных с этими экспериментами
        {
            return context.Experiments.Include(e => e.Options)
                .Include(e => e.DeviceExperiments)
                .ThenInclude(de => de.Device)
                .ToList();
        }
    }
}
