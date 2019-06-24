using System;
using System.Collections.Generic;

namespace ConvertModelToInterface_console.Model
{
    public class TestModel:IModel
    {
        public int IntField { get; }
        public string StringField { get; }
        public bool BooleanField { get; }
        public List<string> StringListField { get; }

        public TestModel()
        {
            this.IntField = 11111;
            this.StringField = "aaaaa";
            this.BooleanField = true;
            this.StringListField = new List<string>();
            StringListField.Add("あああああ");
            StringListField.Add("かかかかか");
        }
    }
}
