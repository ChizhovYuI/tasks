﻿using System;
using System.Linq;

namespace EvalTask
{
    class EvalProgram
    {
        static void Main(string[] args)
        {
            string input = Console.In.ReadToEnd();
            var lines = input.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var expr = lines[0].Replace(",", ".").Replace("'","");
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
}