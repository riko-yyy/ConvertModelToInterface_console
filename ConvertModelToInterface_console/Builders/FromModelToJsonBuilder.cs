using System;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;
using Newtonsoft.Json;

namespace ConvertModelToInterface_console.Builders
{
    public class FromModelToJsonBuilder:IBuilder
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

            //Type t = fromObj.GetType();

            ////TODO BindingFlagsに記述追加
            //FieldInfo[] fields = t.GetFields(BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var field in fields)
            //{
            //    //TODO fieldがcollectionの場合、再帰呼び出しが必要
            //    var key = field.Name;
            //    var value = field.GetValue(fromObj);

            //    Console.WriteLine(key + ":" + value);


            //}
            return jsonInterface;
        }
    }
}
