using Newtonsoft.Json.Linq;
using System;
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

	    static string SerializeJson(string inputString)
	    {
            var v2 = JsonConvert.SerializeObject(inputString);
	        return "";

	    }
	}

    [TestFixture]
    public class JsonProgram_Should
    {
        [Test]
        public void GetStringFromConsole()
        {
            var p=new JsonProgram();

        }
    }
}
