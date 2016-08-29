using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Calculator.Steps
{
    [Binding]
    public sealed class AdditionSteps
    {
        [Then(@"adding (.*) and (.*) should create the correct (.*)\.")]
        public void ThenAddingShouldCreateTheCorrectSum(int first, int second, int sum)
        {
            var calculator = new Domain.Calculator();
            calculator.Push(first);
            calculator.Push(second);
            calculator.Add();
            Assert.That(calculator.Result, Is.EqualTo(sum));
        }
    }
}
