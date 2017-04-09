﻿using System;
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
		    var expr = lines[0].Split(' ')[0];
		    var json = string.Join("", lines.Skip(1));
            string output = new ExpressionEvaluator().Evaluate(expr, json);
			Console.WriteLine(output);
		}
	}

}
