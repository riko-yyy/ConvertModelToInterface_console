using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ConvertModelToInterface_console.Context
{
    public class JsonContext:IContext
    {
        private string dataPath = @"..\..\Data\jsonData.json";

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

        /// <summary>
        /// jsonModelマッピング
        /// </summary>
        /// <param name="jsonDictionary"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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

        //private IEnumerable<T> AsEnumerableEntity<T>(SqlDataReader reader) where T : new()
        //{
        //    // DBカラムとEntityプロパティをマッピング
        //    IDictionary<string, PropertyInfo> mapping = MappingJsonModel(reader, typeof(T));

        //    // SqlDataReaderのデータを取得
        //    IList<T> list = new List<T>();
        //    while (reader.Read())
        //    {
        //        T r = ToEntity<T>(reader, mapping);
        //        list.Add(r);
        //    }

        //    return list;
        //}

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

        //public IEnumerable<T> Select<T>(string commandText, params SqlParameter[] parameters) where T : new()
        //{
        //    // SQLコマンド作成
        //    using (var command = CreateSelectCommand(commandText, parameters))
        //    {
        //        // SQLの実行
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            IEnumerable<T> items = AsEnumerableEntity<T>(reader);
        //            // デバッグ用出力
        //            if (logger.IsDebugEnabled)
        //            {
        //                logger.Debug($"取得データ ==> {items.EnumerableToString()}");
        //            }
        //            return items;
        //        }
        //    }
        //}
    }
}
