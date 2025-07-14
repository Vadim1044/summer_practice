namespace Plugins
{
    public interface IPlugin
    {
        void Execute() { Console.WriteLine("Plugin used");}
    }
    public class PluginLoad : Attribute
    {
        public string[] Depends_On { get; }

        public PluginLoad(params string[] depends_On)
        {
            Depends_On = depends_On;
        }
    }
}