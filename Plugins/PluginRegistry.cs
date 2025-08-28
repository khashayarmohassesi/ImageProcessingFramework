using ImageProcessingFramework.Models;
using System.Reflection;//using reflection to load in other plugins
using System.Text.Json;

namespace ImageProcessingFramework.Plugins
{
    public class PluginRegistry
    {
        private readonly Dictionary<string, IEffectPlugin> _byId = new(StringComparer.OrdinalIgnoreCase);
        public IEnumerable<IEffectPlugin> RegisteredPlugins => _byId.Values;
        public void Register(IEffectPlugin plugin)
        {
            if (_byId.ContainsKey(plugin.Id))
            {
                throw new InvalidOperationException($"Plugin with Id {plugin.Id} already registered");
            }
            _byId[plugin.Id] = plugin;
            Console.WriteLine($"[PluginRegistry] Registered plugin: {plugin.Id} {plugin.Name}");
        }
        public bool TryGet(string id, out IEffectPlugin? plugin)
        {
            return _byId.TryGetValue(id, out plugin);
        }

        public void LoadFromConfigFile(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var entries = JsonSerializer.Deserialize<List<PluginConfigEntry>>(json);
            if (entries == null) return;

            for (int i = 0; i < entries.Count; i++)
            {
                try
                {
                    IEffectPlugin? instance = null;
                    if (!string.IsNullOrWhiteSpace(entries[i].AssemblyPath) && File.Exists(entries[i].AssemblyPath))
                    {
                        var asm = Assembly.LoadFrom(entries[i].AssemblyPath);
                        var type = asm.GetType(entries[i].TypeName);
                        instance = (IEffectPlugin?)Activator.CreateInstance(type!);
                    }
                    else
                    {
                        var type = Type.GetType(entries[i].TypeName);
                        if (type != null)
                        {
                            instance = (IEffectPlugin?)Activator.CreateInstance(type);
                        }
                    }
                    if (instance != null)
                        Register(instance);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"PluginRegistry failed to load plugin {entries[i].Id} :{exception.Message} ");
                }
            }
            
        }
        //in house fake plugins
        public void RegisterBuiltInDemoPlugins()
        {
            Register(new ResizePlugin());
            Register(new BlurPlugin());
            Register(new GrayscalePlugin());
        }

    }
}
