using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console.Builders
{
    public class FromModelToDictionaryBuilder : IBuilder
    {
        private ModelInfoHolder ModelInfoHolder;

        public void SetHolder(ModelInfoHolder modelInfoHolder)
        {
            this.ModelInfoHolder = modelInfoHolder;
        }

        public void CreateToModel()
        {
            var toModel = ConvertFromModel(ModelInfoHolder.GetFromModelCollection());
            ModelInfoHolder.SetToModel(toModel);
        }

        public IEnumerable<T> ConvertFromModel<T>(IEnumerable<T> fromObj) where T : IModel
        {
            //modelのfield名変更
            IList<T> list = new List<T>();
            foreach (var fromModel in fromObj)
            {
                list.Add((T)ConvertFromModel(fromModel));
            }
            return list;
        }

        public T ConvertFromModel<T>(T fromObj) where T : IModel
        {
            Dictionary dictionary = new Dictionary();

            Type t = fromObj.GetType();

            var fields = t.GetProperties();
            foreach (var field in fields)
            {
                var key = field.Name;
                var value = field.GetValue(fromObj);
                dictionary.Add(key, value.ToString());
            }

            return (T)(object)dictionary;
        }

    }
}
