using System.Text.Json.Serialization;

namespace ImageProcessingFramework.Models
{
    public class ParameterDefinition
    {
        public string Name { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParameterKind Kind { get; set; } = ParameterKind.None;
        public int? Min { get; set; }
        public int? Max { get; set; }
        public string[]? Options { get; set; }
    }
}
