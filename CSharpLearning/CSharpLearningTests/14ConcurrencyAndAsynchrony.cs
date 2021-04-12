using System;
using System.Threading;
using NUnit.Framework;

namespace CSharpLearningTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingAThreadUsingTheThreadStartDelegate()
        {
            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write('x');
                } 
            });
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
               Console.Write('y'); 
            }
            
            Assert.Pass();
        }

        [Test]
        public void WaitForAnotherThreadToEndByCallingJoin()
        {
            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine('y');
                }
            });
            t.Start();
            t.Join();
            Console.WriteLine("Thread t has ended");
            Assert.Pass();
        }
    }
}