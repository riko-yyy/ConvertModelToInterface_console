using System;
using System.Collections.Generic;
using System.Reflection;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Builders
{
    public class FromModelToDuplicateKeyDictionaryBuilder:IBuilder
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
            //modelのfield名変更

            //jsonへparse
            //Tへキャストするには1度objectへキャスト
            DuplicateKeyDictionary duplicateKeyDictionary = new DuplicateKeyDictionary();

            Type t = fromObj.GetType();

            var fields = t.GetProperties();
            foreach (var field in fields)
            {
                //TODO fieldがcollectionの場合、再帰呼び出しが必要
                var key = field.Name;
                var value = field.GetValue(fromObj);

                bool existKey = duplicateKeyDictionary.ContainsKey(key);

                if (existKey)
                {
                    duplicateKeyDictionary[key].Add(value.ToString());
                }
                else
                {
                    IList<string> list = new List<string>();
                    list.Add(value.ToString());
                    duplicateKeyDictionary.Add(key, list);
                }

            }
            return (T)(object)duplicateKeyDictionary;
        }
    }
}
