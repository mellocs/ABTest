namespace ABTest.Models
{
    public class DeviceExperiment
    {
        public int DeviceId { get; set; }
        public int ExperimentId { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }
        public Device Device { get; set; }
        public Experiment Experiment { get; set; }
    }
}
