
using NUnit.Framework;
using System;
using System.Linq;
using FibonacciGenerator;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableExtensionsTests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-50)]
       
        public static void Generator_ShouldReturn_ArgumentException_MaxItemsIsLessThanZeroItems(int n)
        {

            //var result = Fibonacci.Generate(n);
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));
        }
        
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(20)]
        [TestCase(37)]
        [TestCase(46)]
        public static void Generator_ShouldNotReturn_ArgumentException_MaxItemsIsWithInRange1_46(int n)
        {

            string message = "NumberOfItems_betweenValidRange1_46_in_parameter_were_1_11_20_37_46. Should not give ArgumentException";

            Assert.DoesNotThrow(() => Fibonacci.Generate(n), message );
        }

        [TestCase(3, new[] {0,1,1})]
        [TestCase(5, new[] {0,1,1,2,3})]
        [TestCase(10, new[] {0,1,1,2,3,5,8,13,21,34})]
        public static void Generator_ShouldReturn_ValidFibonacciSequenceCollection_For_parameter_10(int n, int[] expected)
        {
            var result = Fibonacci.Generate(n);
            Assert.AreEqual(expected, result);
        }
        
        public static void _ShallProduceSequenceWith_0_ForEqualTo1()
        {
            var result = Fibonacci.Generate(1);
            Assert.AreEqual(new int[] { 0 }, result);
        }

        public static void _ShallProduceSequenceWithLastNumberOf_1134903170ForN_46()
        {
            int expected = 1134903170;
            var result = Fibonacci.Generate(46).Last();
            Assert.Equals(expected, result);
        }
        [Test]
        public static void Zero_ShouldProduceEmptySequence()
        {
            var result = Fibonacci.Generate(0);
            Assert.IsEmpty(result);

        }
    }
}
            