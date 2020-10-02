using System.Diagnostics;

namespace algorythms_lab_1 //love
{                          //kindness
    class TimeAnalyzer
    {
        public TestingStructure TestingStructure;

        public TimeAnalyzer(TestingStructure testingStructure)
        {
            TestingStructure = testingStructure;
        }

        public double Analyze()
        {         
            var stopwatch = new Stopwatch();
            var iterations = 10.0;

            for (var j = 0; j < iterations; j++)
                TestingStructure.Test();

            for (var i = 0; i < iterations; i++)
            {
                stopwatch.Start();
                TestingStructure.Test();
                stopwatch.Stop();
            }

            return stopwatch.Elapsed.TotalSeconds / iterations;          
        }
    }
}
