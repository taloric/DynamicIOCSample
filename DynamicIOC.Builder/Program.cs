using DynamicIOC.Interface;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicIOC.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicClass");
            AssemblyBuilder builder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mBuilder = builder.DefineDynamicModule("DynamicClassModule", "DynamicClass.dll");
            TypeBuilder typeBuilder = mBuilder.DefineType("DynamicClassGenerator", TypeAttributes.Public);
            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod("GetDefaultService", MethodAttributes.Public | MethodAttributes.Static, typeof(IService), null);

            ILGenerator generator = methodBuilder.GetILGenerator();
            generator.Emit(OpCodes.Newobj, typeof(DefaultService).GetConstructor(new Type[0]));
            var obj = generator.DeclareLocal(typeof(DefaultService));
            generator.Emit(OpCodes.Stloc, obj);
            generator.Emit(OpCodes.Ldloc, obj);
            generator.Emit(OpCodes.Ret);

            typeBuilder.CreateType();
            builder.Save("DynamicClass.dll");
        }
    }
}
