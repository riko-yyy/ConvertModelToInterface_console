using System;
using System.Collections.Generic;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;
using Newtonsoft.Json;

namespace ConvertModelToInterface_console.Builders
{
    public class FromModelToJsonBuilder : IBuilder
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

        public T ConvertFromModel<T>(IEnumerable<T> fromObj) where T : IModel
        {
            return (T)(object)JsonParse(JsonConvert.SerializeObject(fromObj));
        }

        public T ConvertFromModel<T>(T fromObj) where T : IModel
        {
            return (T)(object)JsonParse(JsonConvert.SerializeObject(fromObj));
        }

        public IModel JsonParse(string jsonString)
        {
            //modelのfield名変更
            //DBテーブル形式を想定しているためDictionary<string,string>へパース
            //var fromJsonData = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, string>>>(jsonString);
            //foreach (MetaDataModel metaData in ModelInfoHolder.GetModelMetaData())
            //{
                
            //}



            //jsonへparse
            //Tへキャストするには1度objectへキャスト
            return new JsonInterface(jsonString);
        }
    }
}
