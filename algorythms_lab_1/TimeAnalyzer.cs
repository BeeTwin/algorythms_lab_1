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

        public double Analyze(object[] args, bool refreshNeeded)
        {         
            var stopwatch = new Stopwatch();

            TestingStructure.Test(args);
            TestingStructure.Test(args);
            TestingStructure.Test(args);
            TestingStructure.Test(args);

            stopwatch.Start();
            TestingStructure.Test(args);
            stopwatch.Stop();

            if (refreshNeeded)
                TestingStructure.Refresh();

            return stopwatch.Elapsed.TotalMilliseconds;          
        }
    }
}
