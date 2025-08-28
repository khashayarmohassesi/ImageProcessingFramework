using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins
{
    public class GrayscalePlugin : EffectPluginBase
    {
        public override string Id => "grayscale";
        public override string Name => "Grayscale";
        public override ParameterDefinition? ParameterDefinition => null;


        public override void Apply(ImageData image, object? parameter)
        {
            //Plugin Logic
            Record(image, null);
            Console.WriteLine($" -> [GrayscalePlugin] Simulated grayscale conversion for image '{image.Name}'");
        }
    }
}
