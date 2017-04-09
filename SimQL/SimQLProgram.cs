using System;
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
		    foreach (var parsedResult in ExecuteQueries(json))
		    {
		        try
		        {
		            var result = int.Parse(parsedResult);
		            Console.WriteLine(result);
		        }
		        catch
		        {
                    var result = double.Parse(parsedResult);
                    Console.WriteLine(result);
                }
		    }
		}

		public static IEnumerable<string> ExecuteQueries(string json)
		{
			var jObject = JObject.Parse(json);
            //var data = (JObject)jObject["data"];
            var data = (JArray)jObject["data"];
            var queries = jObject["queries"].ToObject<string[]>();
			// TODO
			return queries.Select(q => "0");
		}

	}
}
