using System;
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
            var toModel = ConvertFromModel(ModelInfoHolder.GetFromModel());
            ModelInfoHolder.SetToModel(toModel);
        }

        public T ConvertFromModel<T>(T fromObj) where T : IModel
        {
            //modelのfield名変更

            //jsonへparse
            //Tへキャストするには1度objectへキャスト
            T jsonInterface = (T)(object)new JsonInterface(JsonConvert.SerializeObject(fromObj));

            return jsonInterface;
        }
    }
}
