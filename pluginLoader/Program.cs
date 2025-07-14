using Plugins;
using System;
using System.IO;
using System.Reflection;

namespace PluginLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Загрузка плагинов...");

            string pluginsDirectory = Directory.GetCurrentDirectory();
            if (!Directory.Exists(pluginsDirectory))
            {
                Console.WriteLine("Папка с плагинами не найдена: "+ pluginsDirectory);
                return;
            }
            var loader = new Loader(pluginsDirectory);
            loader.SearchPluginAndExecute();
            Console.WriteLine("Все плагины загружены и выполнены");
        }
    }
    public class Loader
    {
        private string PluginsDirectory;
        public Loader(string pluginsDirectory)
        {
            PluginsDirectory = pluginsDirectory;
        }

        public void SearchPluginAndExecute()
        {
            var plugins = new List<(Type Type, string Name, string[] Dependencies)>();
            foreach (var dll in Directory.GetFiles(PluginsDirectory, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(dll);

                foreach (var type in assembly.GetTypes())
                {
                    var pluginAttr = type.GetCustomAttribute<PluginLoad>();
                    if (pluginAttr != null)
                    {
                        plugins.Add((type, type.Name, pluginAttr.Depends_On ?? Array.Empty<string>()));
                    }
                }
            }
            var loaded = new HashSet<string>();
            bool changed;

            do
            {
                changed = false;

                foreach (var (type, name, deps) in plugins)
                {
                    if (!loaded.Contains(name) && deps.All(loaded.Contains))
                    {
                        if (Activator.CreateInstance(type) is IPlugin plugin)
                        {
                            plugin.Execute();
                            loaded.Add(name);
                            changed = true;
                        }
                    }
                }
            }
            while (changed && loaded.Count < plugins.Count);
        }
    }
}