using System;

namespace DynamicIOC.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = DynamicClassGenerator.GetDefaultService();
            service.OnLoad();
            service.OnStart();
            service.OnStop();
            Console.ReadKey();
        }
    }
}
