using System.Globalization;
using DynamicExpresso;

namespace EvalTask
{
    public class ExpressionEvaluator
    {
        public string Evaluate(string s)
        {
            var interpreter= new Interpreter();
            return interpreter.Eval(s).ToString();
        }
    }
}