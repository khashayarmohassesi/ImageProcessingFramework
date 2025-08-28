using ImageProcessingFramework.Models;
using ImageProcessingFramework.Plugins;

namespace ImageProcessingFramework.Processing
{
    public class ProcessingEngine
    {
        private readonly PluginRegistry _plugins;
        private readonly Dictionary<Guid, ImageJob> _jobs = new Dictionary<Guid, ImageJob>();
        public ProcessingEngine(PluginRegistry plugins) => _plugins = plugins;
        public Guid AddImage(ImageData imageData)
        {
            _jobs[imageData.Id] = new ImageJob(imageData);
            Console.WriteLine($"Added Image : {imageData}");
            return imageData.Id;
        }
        public void AddEffectToImage(Guid imageId, string pluginId, object? parameterValue = null)
        {
            if (!_jobs.TryGetValue(imageId, out var job)) throw new KeyNotFoundException(); //Add more info
            Console.WriteLine(pluginId);
            if(!_plugins.TryGet(pluginId,out var plugin)) throw new KeyNotFoundException(); //Add more info

            job.Effects.Add(new EffectInstance { PluginId = pluginId, ParameterValue = parameterValue });
            Console.WriteLine($"Queued effect {pluginId} (param = {parameterValue ?? "<none>"} on image {job.ImageData.Name}");
        }
        public void ProcessAll()
        {
            Console.WriteLine("Processing all jobs");
            foreach (var job in _jobs.Values)
            {
                ProcessJob(job);
            }
            Console.WriteLine("Process of all jobs complete");
        }
        private void ProcessJob(ImageJob imageJob)
        {
            Console.WriteLine($"Processing Image {imageJob.ImageData.Name} with {imageJob.Effects.Count} Effect(s)");
            for (int i = 0; i < imageJob.Effects.Count; i++)
            {
                var effect = imageJob.Effects[i];
                if (_plugins.TryGet(effect.PluginId, out var plugin))
                {
                    Console.WriteLine($"Applying Effect");
                    plugin.Apply(imageJob.ImageData, effect.ParameterValue);
                }
            }
        }
        public IEnumerable<ImageData> ListImages() => _jobs.Values.Select(j => j.ImageData);
    }
}
