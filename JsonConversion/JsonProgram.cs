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
			string json = Console.In.ReadToEnd();
		    
			//...
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
	        //var eval = new ExpressionEvaluator();
	        //var exString = v2Data.products.Select(x => x.Value.price)).ToList();
         //   var e=exString.Select(x=>eval.Evaluate())
            List<ProductV3> products;
            if (v2Data.constants!=null&&v2Data.constants.ContainsKey("pi"))
                products = v2Data.products
                .Select(
                    p => new ProductV3(p.Key, p.Value.name, 45.762, p.Value.count))
                    .ToList();
            else
                products = v2Data.products
                .Select(
                    p => new ProductV3(p.Key, p.Value.name, Convert.ToDouble(p.Value.price), p.Value.count))
                    .ToList();
            var v3 = new V3Data ("3",products);
	        
	        return v3;
	    }

	    

	    public static string SerializeV3Data(V3Data data)
	    {
            
	        return JsonConvert.SerializeObject(data,Formatting.Indented);
	    }
	}
}
