using System;

namespace ClassLibrary
{
    public class Display
    {
        public void Show()
        {
            Title title = new Title();
            title.Show();
            ConsoleLine cl = new ConsoleLine();
            cl.Show();

        }
    }
    public class Title
    {
        string name = "ConsoleCommander";
        string version = "1.0.1";

        public string Name
        {
            get { return name; }
        }
        public string Version
        {
            get { return version; }
        }

        public void Show()
        {
            Console.Write($"{Name} v.{Version}");
        }
    }
    public class ConsoleLine
    {
        string prefix = ":>";

        public string Prefix
        {
            get { return prefix; }
        }

        public void Show()
        {
            Console.Write($"\n{Prefix}");
            Console.Read();
        }
    }
}
