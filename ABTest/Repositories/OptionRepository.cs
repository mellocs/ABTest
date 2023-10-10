using ABTest.Database;
using ABTest.IRepositories;
using ABTest.Models;

namespace ABTest.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        private readonly ApplicationContext context;

        public OptionRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Option? GetOption(int deviceId, int experimentId) // Получаем результаты эксперимента для текущего девайса
        {
            return context.DeviceExperiments.Where(de => de.DeviceId == deviceId &&  de.ExperimentId == experimentId)
                .Select(o => o.Option).FirstOrDefault();
        }

        public ICollection<Option> GetOptionsForAExperiment(int experimentId)
        {
            return context.Options.Where(o => o.Experiment.Id == experimentId).ToList(); // Получаем возможные значения для текущего эксперимента
        }
    }
}
