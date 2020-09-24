using System;
using System.Collections.Generic;
using System.Linq;

namespace algorythms_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterationNumbers = new List<int> { 1, 2, 5, 10, 20, 50, 100, 150, 500, 1000, 5000, 10000, 50000, 200000 };

            var result = Analyze(typeof(Structure), "Algorythm", iterationNumbers);
            for(var i = 0; i < iterationNumbers.Count; i++)
                Console.WriteLine($"Iterations count \t{iterationNumbers[i]} \t: \t{result[i]} \tseconds");
        }

        static List<double> Analyze(Type type, string method, List<int> iterationNumbers)
        {
            var analyzer = new TimeAnalyzer(
                type.GetMethod(method),
                type.GetConstructors().FirstOrDefault(),
                iterationNumbers);
            return analyzer.Analyze();
        }
    }
}
