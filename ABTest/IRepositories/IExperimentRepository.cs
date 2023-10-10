using ABTest.Models;

namespace ABTest.IRepositories
{
    public interface IExperimentRepository
    {
        ICollection<Experiment> GetExperiments(); 
        Experiment? GetExperimentByName(string experimentName);
    }
}
