using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Context;

namespace ConvertModelToInterface_console.Model
{
    [NameInInfra("JsonData")]
    public class TestModel : IModel
    {
        [NameInInfra("IntField")]
        public int IntField { get; private set; }
        [NameInInfra("StringField")]
        public string StringField { get; private set; }
        [NameInInfra("BooleanField")]
        public bool BooleanField { get; private set; }
        [NameInInfra("DateTimeField")]
        public DateTime DateTimeField { get; private set; }

    }
}
