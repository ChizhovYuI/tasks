using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
		    string input = Console.In.ReadToEnd();
		    var lines = input.Split(new[] {'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
		    var expr = lines[0];
		    var json = string.Join("", lines.Skip(1));
		    try
		    {
                string output = new ExpressionEvaluator().Evaluate(expr, json);
                Console.WriteLine(output);
            }
		    catch (Exception)
		    {
		        Console.WriteLine("error");
		    }
		}
	}

    //class InputParser
    //{
    //    public Tuple<string,string> 
    //}

}
