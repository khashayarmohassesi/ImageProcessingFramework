namespace ImageProcessingFramework.Models
{
    public class ImageData
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public int Width { get; set; }
        public int Height { get; set; }
        //I'm missing something here?

        public List<AppliedEffect> AppliedEffects { get; } = new List<AppliedEffect>();
        public ImageData(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;

        }
    }
}
