using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace JsonConversion
{
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
        [Test]
        public void DeserializeSecondJson()
        {
            inputString = File.ReadAllText("2.v2.json");
            var data = JsonProgram.DeserializeJson(inputString);
            Assert.IsTrue(data.constants.Any(x=>x.Key!=null));
        }

        [Test]
        public void ConvertSecondJson()
        {
            inputString = File.ReadAllText("test.json");
            var data = JsonProgram.DeserializeJson(inputString);
            var e = JsonProgram.ConvertV2DataToV3Data(data);
            Assert.IsTrue(e.products.Any(x=>x.price== 126.444));
        }
    }
}