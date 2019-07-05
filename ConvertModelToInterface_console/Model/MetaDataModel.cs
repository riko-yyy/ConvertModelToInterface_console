using System;
using System.Runtime.Serialization;
using ConvertModelToInterface_console.Context;

namespace ConvertModelToInterface_console.Model
{
    [NameInInfra("JsonMetaData")]
    public class MetaDataModel
    {
        [NameInInfra("ID")]
        public int Id { get; private set; }
        [NameInInfra("FromModelName")]
        public string FromModelName { get; private set; }
        [NameInInfra("FromModelField")]
        public string FromModelField { get; private set; }
        [NameInInfra("ToModelName")]
        public string ToModelName { get; private set; }
        [NameInInfra("ToModelField")]
        public string ToModelField { get; private set; }
    }

}
