using System;
namespace ConvertModelToInterface_console.Model
{
    public class DuplicateKVInterface : IModel
    {
        public string Result { get; }

        public DuplicateKVInterface(string kvString)
        {
            this.Result = kvString;
        }
    }
}
