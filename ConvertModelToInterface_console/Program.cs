using System;
using System.Collections;
using System.Collections.Generic;
using ConvertModelToInterface_console.Builders;
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

            //データ取得
            TestModel testModel = new TestModel();
            //メタデータ取得
            IEnumerable<MetaDataModel> metaData = null;

            //変換用ホルダー作成
            ModelInfoHolder holder = new ModelInfoHolder(testModel, metaData);

            //変換処理の実行
            //FromModelToJsonBuilder builder = new FromModelToJsonBuilder();
            //FromModelToDuplicateKeyDictionaryBuilder builder = new FromModelToDuplicateKeyDictionaryBuilder();
            FromModelToDuplicateKVBuilder builder = new FromModelToDuplicateKVBuilder();
            Director director = new Director(builder,holder);
            director.ConvertModel();

            IModel toModel = holder.GetToModel();

            Console.WriteLine(toModel);
        }





    }
}
