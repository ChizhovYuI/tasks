using NUnit.Framework;

namespace SimQLTask
{
	[TestFixture]
	public class SimQLProgram_Should
	{
		//[Test]
		//public void SumEmptyDataToZero()
		//{
		//	var results = SimQLProgram.ExecuteQueries(
		//		"{" +
		//		"'data': [], " +
		//		"'queries': ['sum(item.cost)', 'sum(itemsCount)']}");
		//	Assert.AreEqual(new[] {0, 0}, results);
		//}

		//[Test]
		//public void SumSingleItem()
		//{
		//	var results = SimQLProgram.ExecuteQueries(
		//		"{" +
		//		"'data': [{'itemsCount':42}, {'foo':'bar'}], " +
		//		"'queries': ['sum(itemsCount)']}");
		//	Assert.AreEqual(new[] { 42 }, results);
		//}

        [Test]
        public void SimpleSingleItem()
        {
            var results = SimQLProgram.ExecuteQueries(
                "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42}," +
                "\"queries\":[\"a.x\",\"a.b.c\",\"a.c.c\",\"z\"]}");
            Assert.AreEqual(new[] { "a.x = 3.14", "a.b.c = 15", "a.c.c = 9", "z = 42" }, results);
        }
    }
}