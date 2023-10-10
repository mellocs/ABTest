using ABTest.Models;

namespace ABTest.IRepositories
{
    public interface IDeviceRepository
    {
        int GetDeviceCount();
        Device? GetDeviceByToken(string deviceToken);
        Device Add(string deviceToken, Experiment experiment, Option option);
        Device AddExperiment(Device device, Experiment experiment, Option option);
    }
}
