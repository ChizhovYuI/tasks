using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using EvalTask;

namespace JsonConversion
{
    class JsonProgram
    {
        static void Main()
        {
            var json = Console.In.ReadToEnd();
            var v2 = DeserializeJson(json);
            var v3 = ConvertV2DataToV3Data(v2);
            var res = SerializeV3Data(v3);
            Console.Write(res);
        }

        public static V2Data DeserializeJson(string inputString)
        {
            return JsonConvert.DeserializeObject<V2Data>(inputString);
        }

        public static V3Data ConvertV2DataToV3Data(V2Data v2Data)
        {
            var eval = new ExpressionEvaluator();
            var exString = JsonConvert.SerializeObject(v2Data.constants);
            var e = v2Data.products.Select(x => x.Value.price).ToList();
            V3Data v3 = CreateProducts(v2Data, eval, exString, e);

            return v3;
        }

        private static V3Data CreateProducts(V2Data v2Data, ExpressionEvaluator eval, string exString, List<string> e)
        {
            List<ProductV3> products;
            if (v2Data.constants != null)
                products = v2Data.products
                    .Zip(e,
                        (p, s) => new ProductV3(p.Key, p.Value.name,
                            eval.Evaluate(s, exString) == "?" ? 0 : Convert.ToDouble(eval.Evaluate(s, exString)),
                            p.Value.count,GetDic(p.Value.size)
                            ))
                    .ToList();
            else
                products = v2Data.products
                    .Select(
                        p => new ProductV3(p.Key, p.Value.name, Convert.ToDouble(p.Value.price), p.Value.count, GetDic(p.Value.size)))
                    .ToList();
            var v3 = new V3Data("3", products);
            return v3;
        }

        private static Dictionary<char, int> GetDic(int[] size)
        {
            if(size==null)
                return new Dictionary<char, int>();
            return new Dictionary<char, int>
            {
                {'l', size[2]},
                {'w', size[0]},
                {'h', size[1]}
            };
        }


        public static string SerializeV3Data(V3Data data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}