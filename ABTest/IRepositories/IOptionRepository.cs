using ABTest.Models;

namespace ABTest.IRepositories
{
    public interface IOptionRepository
    {
        ICollection<Option> GetOptionsForAExperiment(int experimentId);
        Option? GetOption(int deviceId, int experimentId); 
    }
}
