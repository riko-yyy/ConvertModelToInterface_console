using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConvertModelToInterface_console.Builders;
using ConvertModelToInterface_console.Context;
using ConvertModelToInterface_console.Directors;
using ConvertModelToInterface_console.Holders;
using ConvertModelToInterface_console.Model;

namespace ConvertModelToInterface_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //メタデータ取得
            JsonContext context = new JsonContext();
            IEnumerable<MetaDataModel> metaData = context.Select<MetaDataModel>("JsonMetaData.json");

            //データ取得
            IEnumerable<TestModel> testModel = context.Select<TestModel>("JsonData.json");

            //変換用ホルダー作成
            ModelInfoHolder holder = new ModelInfoHolder(testModel.First(), metaData);

            //変換処理の実行
            FromModelToJsonBuilder builder = new FromModelToJsonBuilder();
            //FromModelToDuplicateKeyDictionaryBuilder builder = new FromModelToDuplicateKeyDictionaryBuilder();
            //FromModelToDuplicateKVBuilder builder = new FromModelToDuplicateKVBuilder();
            Director director = new Director(builder,holder);
            director.ConvertModel();

            IModel toModel = holder.GetToModel();

            Console.WriteLine(toModel);
        }





    }
}
