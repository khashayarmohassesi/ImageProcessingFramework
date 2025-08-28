namespace ImageProcessingFramework.Models
{
    public class PluginConfigEntry
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public string? AssemblyPath { get; set; }
        public ParameterDefinition? Parameter { get; set; }
    }
}
