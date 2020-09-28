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
            var iterations = 100.0;

            stopwatch.Reset();
            for (var i = 0; i < iterations; i++)
            {
                for(var j = 0; j < iterations; j++)
                    TestingStructure.Test();
                stopwatch.Start();
                TestingStructure.Test();
                stopwatch.Stop();
            }

            return stopwatch.Elapsed.TotalSeconds / iterations;          
        }
    }
}
