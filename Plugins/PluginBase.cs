using ImageProcessingFramework.Models;

namespace ImageProcessingFramework.Plugins
{
    public interface IEffectPlugin
    {
        string Id { get; }
        string Name { get; }
        ParameterDefinition? ParameterDefinition { get; }
        void Apply(ImageData image, object? parameter);
    }

    public abstract class EffectPluginBase : IEffectPlugin
    {
        public abstract string Id { get; }
        public abstract string Name { get; }
        public virtual ParameterDefinition? ParameterDefinition => null;
        public abstract void Apply( ImageData image, object? parameter);
        protected void Record(ImageData image, object? parameter)
        {
            image.AppliedEffects.Add(new AppliedEffect
            {
                PluginId = Id,
                PluginName = Name,
                ParameterValue = parameter,
                AppliedAt = DateTime.Now,
            });
        }
    }
}
