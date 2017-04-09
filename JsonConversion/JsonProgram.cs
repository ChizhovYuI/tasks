using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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
            var products = v2Data.products
                .Select(
                    p => new ProductV3(p.Key, p.Value.name, Convert.ToDouble(p.Value.price), p.Value.count))
                    .ToList();
            var v3 = new V3Data (v2Data.version,products);
	        
	        return v3;
	    }

	    public static string SerializeV3Data(V3Data data)
	    {
            
	        return JsonConvert.SerializeObject(data,Formatting.Indented);
	    }
	}
}
