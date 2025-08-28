using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins
{
    public class ResizePlugin : EffectPluginBase
    {
        public override string Id => "resize";
        public override string Name => "Resize";
        public override ParameterDefinition? ParameterDefinition => new ParameterDefinition
        {
            Name = "resize",
            Kind = ParameterKind.Int,
            Min = 1,
            Max = 1024,
        };
        public override void Apply(ImageData image, object? parameter)
        {
            int size = Convert.ToInt32(parameter);
            image.Width = size;
            image.Height = size;
            //plugin's logic
            Record(image, size);
            Console.WriteLine($" ResizePlugin Simulated resize to {size}x{size} for image '{image.Name}'");
        }

    }
}