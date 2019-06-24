using System;
using ConvertModelToInterface_console.ApplicationServiceLayer;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");





            TestModel testModel = new TestModel();

            ConvertModeltoInterfaceApplicationService convertMtoIapl = new ConvertModeltoInterfaceApplicationService();
            convertMtoIapl.Convert(testModel);

        }





    }
}
