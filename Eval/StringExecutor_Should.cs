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
        public void EvalSumExpression(string expr, string expected)
        {
            var result = new ExpressionEvaluator().Evaluate(expr);
            Assert.AreEqual(expected, result);
        }
    }
}