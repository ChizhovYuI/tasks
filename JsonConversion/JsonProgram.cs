using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JsonConversion
{
	class JsonProgram
	{
		static void Main()
		{
			string json = Console.In.ReadToEnd();
		    
			//...
			var v3 = "{ 'version':'3', 'products': 'TODO' }";
			Console.Write(v3);
		}

	    public static V2Data DeserializeJson(string inputString)
	    {
            return JsonConvert.DeserializeObject<V2Data>(inputString);
	    }

	    public static V3Data ConvertV2DataToV3Data(V2Data v2Data)
	    {
	        var v3 = new V3Data (v2Data.version,new List<ProductV3>());
	        v3.products=v2Data.products
	            .Select(
	                p => new ProductV3 (p.Key, p.Value.name, p.Value.price, p.Value.count))
                    .ToList();
	        return v3;
	    }

	    public static string SerializeV3Data(V3Data data)
	    {
            
	        return JsonConvert.SerializeObject(data,Formatting.Indented);
	    }
	}

    [TestFixture]
    public class JsonProgram_Should
    {
        private string inputString;
        private V3Data newData;
        [SetUp]
        public void Arrange()
        {
            inputString = File.ReadAllText("1.v2.json");
            newData = new V3Data ("3",
                new List<ProductV3> {
                    new ProductV3 (1,"Pen",12,100),
                    new ProductV3 (2,"Pencil",8,1000),
                    new ProductV3 (3,"Box",12.1,50)}
                    );
        }
        [Test]
        public void DeserializeGoodJson()
        {
            var dataObject = JsonProgram.DeserializeJson(inputString);
            Assert.IsTrue(dataObject is V2Data);
        }

        [Test]
        public void ConvertData()
        {
            var data= JsonProgram.DeserializeJson(inputString);
            var newData = JsonProgram.ConvertV2DataToV3Data(data);
            Assert.IsTrue(newData is V3Data);
        }

        //[Test]
        //public void SerializeGoodObject()
        //{
        //    var str= JsonProgram.SerializeV3Data(newData);
        //    var fileStr = File.ReadAllText("1.v3.json");
        //    Assert.AreEqual(fileStr,str);
        //}
    }
}
