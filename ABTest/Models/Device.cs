namespace ABTest.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public ICollection<DeviceExperiment> DeviceExperiments { get; set; }
       
    }
}
