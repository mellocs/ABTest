namespace ABTest.Models
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<DeviceExperiment> DeviceExperiments { get; set; }
    }
}
