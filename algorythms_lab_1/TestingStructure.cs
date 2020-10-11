using System;
using System.Linq;
using System.Reflection;

namespace algorythms_lab_1
{
    public class TestingStructure
    {
        private MethodInfo _testingAlgorythm;
        private object _testingStructure;

        private Type _type;
        object[] _constructorArguments;
        
        //tea
        //warmth
        public TestingStructure(
            Type testingStructure, 
            string testingAlgorythm, 
            object[] constructorArguments)
        {
            _testingAlgorythm = testingStructure.GetMethod(testingAlgorythm);
            _type = testingStructure;
            _constructorArguments = constructorArguments;
            Refresh();
        }

        public TestingStructure(
            Type type,
            object testingStructure,
            string testingAlgorythm)
        {
            _testingStructure = testingStructure;
            _testingAlgorythm = type.GetMethod(testingAlgorythm);
        }

        public void Test(object[] args)
        {
            _testingAlgorythm.Invoke(_testingStructure, args);
        }

        public void Refresh()
        {

        }
    }
}
