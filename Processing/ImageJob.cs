using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Processing
{
    public class ImageJob
    {
        public ImageData ImageData { get; set; }
        public List<EffectInstance> Effects { get; set; } = new List<EffectInstance>();
        public ImageJob(ImageData imageData) => ImageData = imageData;
    }
}
