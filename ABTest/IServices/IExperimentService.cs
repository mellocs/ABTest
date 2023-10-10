using ABTest.Models;

namespace ABTest.IServices
{
    public interface IExperimentService
    {
        public Option? AddOptions(string experimentName);
    }
}
