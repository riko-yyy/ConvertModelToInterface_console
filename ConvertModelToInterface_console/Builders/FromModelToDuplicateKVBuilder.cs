using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Builders
{
    public class FromModelToDuplicateKVBuilder:IBuilder
    {
        private ModelInfoHolder ModelInfoHolder;

        public void SetHolder(ModelInfoHolder modelInfoHolder)
        {
            this.ModelInfoHolder = modelInfoHolder;
        }

        public void CreateToModel()
        {
            var toModel = ConvertFromModel(ModelInfoHolder.GetFromModel());
            ModelInfoHolder.SetToModel(toModel);
        }
        public T ConvertFromModel<T>(T fromObj) where T : IModel
        {
            FromModelToDuplicateKeyDictionaryBuilder builder = new FromModelToDuplicateKeyDictionaryBuilder();
            builder.SetHolder(ModelInfoHolder);
            Dictionary<string, IList<string>> dictionary = (Dictionary<string, IList<string>>)(object)builder.ConvertFromModel(fromObj);

            string ifValue = "";
            foreach (var kvPair in dictionary)
            {
                foreach (var vListValue in kvPair.Value)
                {
                    ifValue += kvPair.Key + ":" + vListValue + Environment.NewLine;
                }

            }
            return (T)(object)new DuplicateKVInterface(ifValue);
        }
    }
}
