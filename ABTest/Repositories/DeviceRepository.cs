using ABTest.Database;
using ABTest.IRepositories;
using ABTest.Models;

namespace ABTest.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationContext context;

        public DeviceRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Device Add(string deviceToken, Experiment experiment, Option option)
        {
            var device = new Device() // Создаем новый девайс
            {
                DeviceToken = deviceToken
            };

            context.Add(device);

            context.SaveChanges();

            var deviceExperiment = new DeviceExperiment() // Добавляем девайс, эксперимент и значение эксперимента в таблицу DeviceExperiment
            {
                DeviceId = device.Id,
                ExperimentId = experiment.Id,
                OptionId = option.Id
            };
            context.Add(deviceExperiment);

            context.SaveChanges();

            return device;
        }

        public Device AddExperiment(Device device, Experiment experiment, Option option) // Добавляем новое значение эксперимента для девайса который уже учавствует в 1 эксперименте
        {
            var deviceExperiment = new DeviceExperiment() // Добавляем девайс, эксперимент и значение эксперимента в таблицу DeviceExperiment
            {
                DeviceId = device.Id,
                ExperimentId = experiment.Id,
                OptionId = option.Id
            };
            context.Add(deviceExperiment);

            context.SaveChanges();

            return device;
        }

        public Device? GetDeviceByToken(string deviceToken)
        {
            return context.Devices.Where(d => d.DeviceToken == deviceToken).FirstOrDefault(); // Получаем девайс по его токену
        }

        public int GetDeviceCount()
        {
            return context.Devices.Count(); // Получаем количесвто девайсов
        }
    }
}
