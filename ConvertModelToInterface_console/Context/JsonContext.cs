using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ConvertModelToInterface_console.Context
{
    public class JsonContext : IContext
    {
        private readonly string dataPath = "../../../Data";

        public T SelectOne<T>() where T : new()
        {
            T result = new T();

            //データ検索
            using (StreamReader r = new StreamReader(dataPath))
            {
                string json = r.ReadToEnd();
                var sadf = JsonConvert.DeserializeObject(json);

            }

            return result;
        }

        public IEnumerable<T> Select<T>() where T : new()
        {
            throw new NotImplementedException();
        }

        private IDictionary<string, PropertyInfo> MappingJsonModel(IDictionary<string, string> jsonDictionary, Type type)
        {

            IDictionary<string, PropertyInfo> resultData = new Dictionary<string, PropertyInfo>();
            foreach (var jsonKVPair in jsonDictionary)
            {
                string keyName = jsonKVPair.Key;
                PropertyInfo property = type.GetProperty(keyName);
                if (property is null)
                {
                    continue;
                }

                resultData.Add(keyName, property);
            }

            return resultData;
        }

        private IEnumerable<T> AsEnumerableModel<T>(IDictionary<string,string> readJsonData) where T : new()
        {
            // JsonのKeyとModelプロパティをマッピング
            IDictionary<string, PropertyInfo> mapping = MappingJsonModel(readJsonData, typeof(T));

            // SqlDataReaderのデータを取得
            IList<T> list = new List<T>();
            //while (readJsonData.Read())
            //{
            //    T r = ToEntity<T>(reader, mapping);
            //    list.Add(r);
            //}

            return list;
        }

        //private T ToEntity<T>(SqlDataReader row, IDictionary<string, PropertyInfo> mapping) where T : new()
        //{
        //    var resultData = new T();
        //    foreach (var col in mapping)
        //    {
        //        string name = col.Key;
        //        PropertyInfo property = col.Value;

        //        var data = row[name];
        //        if (data is DBNull)
        //        {
        //            // DBNULLの場合はスキップ
        //            continue;
        //        }

        //        // Class の Property に値を設定
        //        property.SetValue(resultData, data);
        //    }

        //    return resultData;
        //}

        public IEnumerable<T> Select<T>(string jsonFileName) where T : new()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), dataPath));
            //string path = dataPath;//+jsonFileName;
            //path = Path.GetFullPath(path);
            // JSON読み込みの実行
            using (StreamReader r = new StreamReader(Path.Combine(path, jsonFileName)))
            {
                string json = r.ReadToEnd();
                //DBテーブル形式を想定
                //IDictionary<string, string> readJsonData = (IDictionary<string, string>)JsonConvert.DeserializeObject(json);

                var readJsonData = JsonConvert.DeserializeObject(json);

                //ModelのIEnumableへ変換
                IEnumerable<T> items = null;//= AsEnumerableModel<T>(readJsonData);
                return items;
            }
           

                


        }
    }
}
