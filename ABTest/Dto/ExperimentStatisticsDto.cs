using ABTest.Models;

namespace ABTest.Dto
{
    public class ExperimentStatisticsDto
    {
        public string ExperimentName { get; set; }
        public Dictionary<string, int> OptionsDistribution { get; set; }
        public int TotalDevices { get; set; }
    }
}
