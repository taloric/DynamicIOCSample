using DynamicIOC.Interface;
using System;

namespace DynamicIOC
{
    public class DefaultService : IService
    {
        public void OnLoad()
        {
            Console.WriteLine("OnLoad");
        }

        public void OnStart()
        {
            Console.WriteLine("OnStart");
        }

        public void OnStop()
        {
            Console.WriteLine("OnStop");
        }
    }
}
