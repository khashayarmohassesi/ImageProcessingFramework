using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;
using ImageProcessingFramework.Processing;

namespace ImageProcessingFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var registry = new PluginRegistry();
            try
            {
                registry.LoadFromConfigFile("third-party-plugins.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            registry.RegisterBuiltInDemoPlugins();
            var engine = new ProcessingEngine(registry);

            var img1 = new ImageData("Image1", 800, 600);
            var img2 = new ImageData("Image2", 800, 600);

            engine.AddImage(img1);
            engine.AddImage(img2);

            engine.AddEffectToImage(img1.Id, "resize", 100);
            engine.AddEffectToImage(img2.Id, "blur", 2);
            engine.AddEffectToImage(img2.Id, "resize", 150);

            engine.ProcessAll();

            foreach (var img in engine.ListImages())
            {
                Console.WriteLine(img);
                for (int i = 0; i < img.AppliedEffects.Count; i++)
                {
                    Console.WriteLine($"Applied Effect {i + 1} : {img.AppliedEffects[i].PluginName}");
                }
            }

        }
    }
}
