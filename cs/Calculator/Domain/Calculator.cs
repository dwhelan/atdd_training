using System.Collections.Generic;

namespace Calculator.Domain
{
    public class Calculator
    {
        public List<int> Operands { get; } = new List<int>();

        public void Push(int number)
        {
            Operands.Add(number);
        }

        internal void Add()
        {
            Result = Operands[0] + Operands[1];
        }

        public int Result { get; set; }
    }
}
