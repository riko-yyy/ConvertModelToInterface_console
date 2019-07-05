using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            //modelのpropetyに対してJsonKeyが存在しているかマッピング
            foreach (var property in type.GetProperties())
            {
                //propetyのattributeを取得
                string nameInInfra = ((NameInInfraAttribute)Attribute.GetCustomAttribute(property, typeof(NameInInfraAttribute))).Name;

                if (jsonDictionary.ContainsKey(nameInInfra))
                {
                    string keyName = jsonDictionary.Keys.First(x => x == nameInInfra);
                    resultData.Add(keyName, property);
                }
            }
            return resultData;
        }

        private IEnumerable<T> AsEnumerableModel<T>(IEnumerable<IDictionary<string, string>> readJsonData) where T : new()
        {

            // JsonのKeyとModelプロパティをマッピング
            IDictionary<string, PropertyInfo> mapping = MappingJsonModel(readJsonData.First(), typeof(T));

            // JsonDataをModelへパースのデー
            IList<T> list = new List<T>();
            foreach (var row in readJsonData)
            {
                T r = ToEntity<T>(row, mapping);
                list.Add(r);
            }

            return list;
        }

        private T ToEntity<T>(IDictionary<string, string> row, IDictionary<string, PropertyInfo> mapping) where T : new()
        {
            var resultData = new T();
            foreach (var col in mapping)
            {
                string name = col.Key;
                PropertyInfo property = col.Value;

                var data = row[name];
                if (data is null)
                {
                    // NULLの場合はスキップ
                    continue;
                }

                //Jsonのためstring
                //propetyに応じてパース
                var parsedData = Convert.ChangeType(data, property.PropertyType);

                // Class の Property に値を設定
                property.SetValue(resultData, parsedData);
            }

            return resultData;
        }

        public IEnumerable<T> Select<T>(string jsonFileName) where T : new()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), dataPath));

            // JSON読み込みの実行
            using (StreamReader r = new StreamReader(Path.Combine(path, jsonFileName)))
            {
                string json = r.ReadToEnd();
                //DBテーブル形式を想定しているためDictionary<string,string>へパース
                var readJsonData = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, string>>>(json);

                //ModelのIEnumableへ変換
                IEnumerable<T> items = AsEnumerableModel<T>(readJsonData);
                return items;
            }
        }
    }
}
