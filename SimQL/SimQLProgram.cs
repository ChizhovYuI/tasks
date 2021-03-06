﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimQLTask
{
    class SimQLProgram
    {
        static void Main(string[] args)
        {
            var json = Console.In.ReadToEnd();
            foreach (var result in ExecuteQueries(json))
            {
                Console.WriteLine(result);
            }
        }

        public static IEnumerable<string> ExecuteQueries(string json)
        {
            var jObject = JObject.Parse(json);

            var data = jObject["data"];
            var queries = jObject["queries"].ToObject<string[]>();
            foreach (var query in queries)
            {
                var localData = data;
                var splittedQuery = query.Split('.').ToList();
                foreach (var symbol in splittedQuery)
                {
                    localData = GetToken(localData, symbol);
                    if (localData == null) break;
                }
                if (localData == null) yield return query;
                else if ((localData.Count() == 0 && localData.Type == JTokenType.Object)) yield return query;
                else
                    yield return query + " = " + localData.Value<double>().ToString(CultureInfo.InvariantCulture);
            }
        }

        public static JToken GetToken(JToken token, string tokenName)
        {
            if (token.Count() == 0)
            {
                return null;
            }
            return token.SelectTokens($"{tokenName}").FirstOrDefault();
        }

        //public static Dictionary<string, double>(JToken )
    }
}