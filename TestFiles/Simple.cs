using System;

namespace RoslynExploration
{
    class TestClass
    {
        public void MethodOne()
        {
            Console.WriteLine(""One"");
            MethodOneA();
            MethodOneB();
        }

        public void MethodTwo()
        {
            Console.WriteLine(""Two"");
            MethodTwoA();
            MethodTwoB();
        }

        private void MethodOneA()
        {
            Console.WriteLine(""One A"");
        }

        private void MethodOneB()
        {
            Console.WriteLine(""One B"");
        }

        private void MethodTwoA()
        {
            Console.WriteLine(""Two A"");
        }

        private void MethodTwoB()
        {
            Console.WriteLine(""Two B"");
        }
    }
}
