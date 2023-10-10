namespace ABTest.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string OptionValue{ get; set; }
        public float Probability { get; set; }
        public Experiment Experiment { get; set; }
    }
}
