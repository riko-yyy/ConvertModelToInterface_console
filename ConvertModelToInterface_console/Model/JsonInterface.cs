using System;
namespace ConvertModelToInterface_console.Model
{
    public class JsonInterface:IModel
    {
        public string Result { get; }

        public JsonInterface(string jsonString)
        {
            this.Result = jsonString;
        }
    }
}
