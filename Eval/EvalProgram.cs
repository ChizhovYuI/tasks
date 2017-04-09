using System;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
			string input = Console.In.ReadToEnd();
			string output = new ExpressionEvaluator().Evaluate(input);
			Console.WriteLine(output);
		}
	}

}
