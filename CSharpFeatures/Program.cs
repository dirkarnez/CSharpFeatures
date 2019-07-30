using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CSharpFeatures
{
    class MyClass
    {
        public decimal C { get; set; }
    };

    class MyInterface
    {
        public string content { get; set; }
    }

    interface MyInterfaceWritable
    {
        MyInterface Write();
    }

    class MyInterfaceWritorA : MyInterfaceWritable
    {
        public MyInterface Write()
        {
            return new MyInterface { content = "A" };
        }
    }

    class MyInterfaceWritorB : MyInterfaceWritable
    {
        public MyInterface Write()
        {
            return new MyInterface { content = "B" };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Optional1();
            Optional2();
        }

        private static void Optional2()
        {
            MyInterfaceWritorA writerA = null;
            MyInterfaceWritorB writerB = new MyInterfaceWritorB();
            var list = new List<MyInterface> {
                writerA?.Write(), writerB.Write()
            }.Where(d => d != null).ToArray();


            Console.WriteLine(list.Count());
        }

        public static void Optional1()
        {
            MyClass c1 = null;
            MyClass c2 = new MyClass() { C = 100m };
            var sumNull = c1?.C + c2?.C;
            var sumOK = (c1?.C ?? 0) + (c2?.C ?? 0);
            Console.WriteLine(sumOK); // True
            Console.ReadLine();
        }
    }
}