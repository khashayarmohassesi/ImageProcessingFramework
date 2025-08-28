namespace ImageProcessingFramework.Models
{
    public class AppliedEffect
    {
        public string PluginId { get; set; } = string.Empty;
        public string PluginName { get; set; } = string.Empty;
        public object? ParameterValue { get; set; }
        public DateTime AppliedAt { get; set; }
        public override string ToString()
        {
            //TODO: Complete Me
            return string.Empty;
        }
    }
}
