using System;
using System.Reflection;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.ApplicationServiceLayer
{
    public class ConvertModeltoInterfaceApplicationService : IConvertApplicationService
    {
        public ConvertModeltoInterfaceApplicationService()
        {
        }

        public T Convert<T>(T fromObj) where T : IModel
        {
            Type t = fromObj.GetType();

            //TODO BindingFlagsに記述追加
            FieldInfo[] fields = t.GetFields(BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                //TODO fieldがcollectionの場合、再帰呼び出しが必要
                var key = field.Name;
                var value = field.GetValue(fromObj);

                Console.WriteLine(key + ":" + value);
            }


            return fromObj;



        }
    }
}
