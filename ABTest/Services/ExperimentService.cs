using ABTest.IRepositories;
using ABTest.IServices;
using ABTest.Models;

namespace ABTest.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IExperimentRepository experimentRepository;
        private readonly IOptionRepository optionRepository;

        public ExperimentService(IExperimentRepository experimentRepository, IOptionRepository optionRepository)
        {
            this.experimentRepository = experimentRepository;
            this.optionRepository = optionRepository;
        }
        public Option? AddOptions(string experimentName)
        {
            double randomNumber = new Random().NextDouble() * 100; // Генерируем число от 1 до 100
            double probability = 0;

            var experiment = experimentRepository.GetExperimentByName(experimentName); // Получаем текущий эксперимент по имени

            var options = optionRepository.GetOptionsForAExperiment(experiment.Id); // Получаем возможные значения для текущего эксперимента 


            foreach (var option in options) // Перебираем значения эксперимента
            {
                probability += option.Probability;  // Прибавляем вероятность значения к общей вероятности
                if (randomNumber < probability) // Если генерируемое число попадает в промежуток вероятности то возращаем значение
                {
                    return option;
                }
            }

            return null;
        }
    }
}
