using NUnit.Framework;

namespace EvalTask
{
    [TestFixture]
    public class ExpressionEvaluator_Should
    {
        [TestCase("5+6","11")]
        [TestCase("5-6","-1")]
        [TestCase("10/4.0","2,5")]
        [TestCase("11*2","22")]
        [TestCase("11.0/0","error")]
        public void EvalSumExpression(string expr, string expected)
        {
            var result = new ExpressionEvaluator().Evaluate(expr, null);
            Assert.AreEqual(expected, result);
        }

        [TestCase("a","1")]
        [TestCase("a+b","3")]
        public void EvalWithConstants(string expr, string expected)
        {
            var json = "{ \"a\": 1, \"b\": 2, \"c_c\": 3, \"pi\": 4 }";
            var result = new ExpressionEvaluator().Evaluate(expr, json);
            Assert.AreEqual(expected, result);
        }

        [TestCase("12 12","")]
        public void ParseInput()
        {
            
        }
    }
}