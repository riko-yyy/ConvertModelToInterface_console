using System;
namespace ConvertModelToInterface_console.Model
{
    public class DuplicateKVInterface : IModel
    {
        public string KVField { get; }

        public DuplicateKVInterface(string kvString)
        {
            this.KVField = kvString;
        }
    }
}
