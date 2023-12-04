using System;

namespace SimpleCalculator
{
    public class Calculator
    {
        private string _myoperator;
        public int a;
        public int b;
        public string Myoperator 
        {
            get{ return _myoperator; }
            set 
            {
                if (value == "+" || value == "-" || value == "*") 
                {
                    _myoperator = value;
                }
                else _myoperator = "unvalid operator";
            } 
        }
        //public int Sum(int a, int b) { Myoperator = "+"; this.a = a; this.b = b;  return a + b;  }

        
        public int Subtract(int a, int b){ Myoperator = "-"; this.a = a; this.b = b; return a - b;  }
        public int Multiply(int a, int b){ Myoperator = "+"; this.a = a; this.b = b; return a * b; }

        public int GiveCalculation(int a, int b, Func<int,int,int> predicate)
        {
            return predicate(a, b);
        }


    }
}
