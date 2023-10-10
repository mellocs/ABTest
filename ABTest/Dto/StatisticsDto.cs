namespace ABTest.Dto
{
    public class StatisticsDto
    {
        public ICollection<ExperimentStatisticsDto> Experiments { get; set; }
        public int TotalDeviceCount { get; set; }
    }
}
