using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace InjectionDeDependance
{
    public class Program
    {
        static void Main(string[] args)
        {
            HelloSayer helloSayer = Mef.Container.GetExportedValue<HelloSayer>();
            helloSayer.SayHello();
        }
    }


    [Export]
    public class HelloSayer
    {
        public void SayHello()
        {
            Console.WriteLine("Bonjour");
        }
    }

    public static class Mef
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if(container == null)
                {
                    var catalog = new DirectoryCatalog(".", "InjectionDeDependance.*");
                    container = new CompositionContainer(catalog);
                }
                return container;
            }
        }
    }
}
