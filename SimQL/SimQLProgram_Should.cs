using System;
using System.Linq;
using NUnit.Framework;

namespace SimQLTask
{
    [TestFixture]
    public class SimQLProgram_Should
    {
        //[Test]
        //public void SumEmptyDataToZero()
        //{
        //    var results = SimQLProgram.ExecuteQueries(
        //        "{" +
        //        "'data': [], " +
        //        "'queries': ['sum(item.cost)', 'sum(itemsCount)']}");
        //    Assert.AreEqual(new[] { "0", "0" }, results.ToArray());
        //}

        //[Test]
        //public void SumSingleItem()
        //{
        //    var results = SimQLProgram.ExecuteQueries(
        //        "{" +
        //        "'data': [{'itemsCount':42}, {'foo':'bar'}], " +
        //        "'queries': ['sum(itemsCount)']}");
        //    Assert.AreEqual(new[] { 42 }, results);
        //}

        [Test]
        public void SimpleSingleItem()
        {
            var results = SimQLProgram.ExecuteQueries(
                "{\"data\":{\"a\":{\"x\":3.14,\"b\":{\"c\":15},\"c\":{\"c\":9}},\"z\":42}," +
                "\"queries\":[\"a.x\",\"a.b.c\",\"a.c.c\",\"z\"]}");
            Assert.AreEqual(
                new[] {"a.x = 3.14", "a.b.c = 15", "a.c.c = 9", "z = 42"},
                results);
        }

        [Test]
        [Ignore()]
        public void NotSimpleSingleItem()
        {
            var results = SimQLProgram.ExecuteQueries(
                "{\"data\":{\"empty\":[],\"x\":[0.1,0.2,0.3],\"a\":[{\"b\":10," +
                "\"c\":[1,2,3]},{\"b\":30,\"c\":[4]},{\"d\":500}]},\"queries\"" +
                ":[\"sum(empty)\",\"sum(a.b)\",\"sum(a.c)\",\"sum(a.d)\",\"sum(x)\"]}");
            Assert.AreEqual(
                new[] {"a.x = 3.14", "a.b.c = 15", "a.c.c = 9", "z = 42"},
                results);
        }

        [Test]
        public void TestSingleItem()
        {
            var results = SimQLProgram.ExecuteQueries(
                "{\"data\":{\"empty\":{},\"ab\":0,\"x1\":1,\"x2\":2,\"y1\":{\"y2\":" +
                "{\"y3\":3}}},\"queries\":[\"empty\",\"xyz\",\"x1.x2\",\"y1.y2.z\",\"empty.foobar\"]}");
            Assert.AreEqual(
                new[] {"empty", "xyz", "x1.x2", "y1.y2.z", "empty.foobar"},
                results);
        }
    }
}