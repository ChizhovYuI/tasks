using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DynamicExpresso;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EvalTask
{
    public class ExpressionEvaluator
    {
        public string Evaluate(string s, string param)
        {
            var interpreter= new Interpreter();
            if (param != null)
            {
                var jObject = JObject.Parse(param);
                var p = new List<Parameter>();
                foreach (var kvp in jObject)
                {
                    p.Add(new Parameter(kvp.Key, ((JValue)kvp.Value).Value));
                }
                return interpreter.Eval(s, p.ToArray()).ToString();
            }
            return interpreter.Eval(s).ToString();
        }
    }
}