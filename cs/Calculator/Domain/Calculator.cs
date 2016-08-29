using System.Collections.Generic;

namespace Calculator.Domain
{
    public class Calculator
    {
        private readonly List<int> operands = new List<int>();
        public int Result { get; set; }

        public void Push(int number)
        {
            operands.Add(number);
        }

        internal void Add()
        {
            Result = operands[0] + operands[1];
        }
    }
}
