using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace JsonConversion
{
    [TestFixture]
    public class JsonProgram_Should
    {
        private string firstJsonString;
        private string testJsonString;
        private V3Data newData;
        [SetUp]
        public void Arrange()
        {
            firstJsonString = File.ReadAllText("1.v2.json");
            testJsonString = File.ReadAllText("test.json");
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
            var dataObject = PrepareV2data(firstJsonString);
            Assert.IsTrue(dataObject.products.Any(x=>x.Value.price!=null));
        }

        [Test]
        public void ConvertFirstJsonData()
        {
            V2Data data = PrepareV2data(firstJsonString);
            var newData = JsonProgram.ConvertV2DataToV3Data(data);
            Assert.IsTrue(newData.version=="3");
        }
        [Test]
        public void ConvertSecondJsonData()
        {
            V2Data data = PrepareV2data(testJsonString);
            var newData = JsonProgram.ConvertV2DataToV3Data(data);
            Assert.IsTrue(newData.products.Any(x => x.price == 45.762));
        }

        private V2Data PrepareV2data(string inputString)
        {
            return JsonProgram.DeserializeJson(inputString);
        }
        [Test]
        public void DeserializeSecondJson()
        {
            firstJsonString = File.ReadAllText("2.v2.json");
            var data = JsonProgram.DeserializeJson(firstJsonString);
            Assert.IsTrue(data.constants.Any(x=>x.Key!=null));
        }

        [Test]
        public void ConvertSecondJson()
        {
            var data = JsonProgram.DeserializeJson(testJsonString);
            var e = JsonProgram.ConvertV2DataToV3Data(data);
            Assert.IsTrue(e.products.Any(x=>x.price== 45.762));
        }
    }
}