using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins
{
    public class BlurPlugin : EffectPluginBase
    {
        public override string Id => "blur";
        public override string Name => "Blur";
        public override ParameterDefinition? ParameterDefinition => new ParameterDefinition
        {
            Name = "Radius",
            Kind = ParameterKind.Int,
            Min = 0,
            Max = 100
        };
        public override void Apply(ImageData image, object? parameter)
        {
            int radius = parameter == null ? 0 : Convert.ToInt32(parameter);
            //Plugin Logic
            Record(image, radius);
            Console.WriteLine($" BlurPlugin Simulated blur radius {radius} on image '{image.Name}'");
        }
    }
}
