using System;
using System.Linq;
using System.Reflection;

namespace algorythms_lab_1
{
    public class TestingStructure
    {
        private MethodInfo _testingAlgorythm;
        private object[] _methodArguments;
        private object _testingStructure;
        
        //tea
        //warmth
        public TestingStructure(
            Type testingStructure, 
            string testingAlgorythm, 
            object[] constructorArguments, 
            object[] methodArguments)
        {
            _testingAlgorythm = testingStructure.GetMethod(testingAlgorythm);
            _methodArguments = methodArguments;
            _testingStructure = testingStructure.GetConstructor(
                constructorArguments
                    .Select(x => x.GetType())
                    .ToArray())
                        .Invoke(constructorArguments);
        }

        public void Test()
        {
            _testingAlgorythm.Invoke(_testingStructure, _methodArguments);
        }
    }
}
