using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace algorythms_lab_1
{
    class TimeAnalyzer
    { 
        public MethodInfo Algorythm;
        public ConstructorInfo Constructor;
        public List<int> Sizes;

        public TimeAnalyzer(MethodInfo algorythm, ConstructorInfo constructor, List<int> iterationNumbers)
        {
            Algorythm = algorythm;
            Constructor = constructor;
            Sizes = iterationNumbers;
        }

        public List<double> Analyze()
        {
            var result = new List<double>();
            var stopwatch = new Stopwatch();
            var iterations = 10.0;
            double timeInSeconds;
            var arr = new object[] { };          
            foreach (var num in Sizes)
            {
                var structure = Constructor.Invoke(new object[] { num });
                for(var i = 0; i < iterations; i++)
                    Algorythm.Invoke(structure, arr); // "разгоночные" прогоны алгоритма

                stopwatch.Restart();
                for(var i = 0; i < iterations; i++)
                    Algorythm.Invoke(structure, arr);
                stopwatch.Stop();

                timeInSeconds = stopwatch.Elapsed.TotalSeconds / iterations;
                result.Add(timeInSeconds);
            }
            return result;
        }
    }
}
