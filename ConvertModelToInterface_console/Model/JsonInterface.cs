using System;
namespace ConvertModelToInterface_console.Model
{
    public class JsonInterface:IModel
    {
        public string JsonField { get; }

        public JsonInterface(string jsonString)
        {
            this.JsonField = jsonString;
        }
    }
}
