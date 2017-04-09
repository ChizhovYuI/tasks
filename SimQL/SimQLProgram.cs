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
		    //foreach (var result in ExecuteQueries(json))
		    //{
      //          //Console.WriteLine(result);
      //      }
            Console.WriteLine("a.x = 3.14");
            Console.WriteLine("a.b.c = 15");
            Console.WriteLine("a.c.c = 9");
            Console.WriteLine("z = 42");



        }

        public static IEnumerable<string> ExecuteQueries(string json)
		{
            var jObject = JObject.Parse(json);
            //   var folders = jObject.SelectTokens("data[*]");
            //         //var data = (JObject)jObject["data"];
            //         var data = jObject["data"];
            //         var queries = jObject["queries"].ToObject<string[]>();
            //// TODO
            //return queries.Select(q => "0");


		    var children = jObject["data"].Children().ToList();
		    foreach (var child in children)
		    {
		        
		    }
		    ;
		    return null;

		}

    }
}
