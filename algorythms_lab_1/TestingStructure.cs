using System;
using System.Linq;
using System.Reflection;

namespace algorythms_lab_1
{
    public class TestingStructure
    {
        private MethodInfo _testingAlgorythm;
        private object _testingStructure;
        private object _tSCopy;
        private Type _type;
        
        //tea
        //warmth

        public TestingStructure(
            Type type,
            object testingStructure,
            string testingAlgorythm)
        {
            _type = type;
            _testingStructure = Copy(testingStructure);
            _testingAlgorythm = type.GetMethod(testingAlgorythm);
            _tSCopy = Copy(_testingStructure);
        }

        public void Test(object[] args) 
            => _testingAlgorythm.Invoke(_testingStructure, args);

        public void Refresh() 
            => _testingStructure = Copy(_tSCopy);

        private object Copy(object obj) 
            => _type.GetConstructor(new Type[] { _type }).Invoke(new object[] { obj });
    }
}
