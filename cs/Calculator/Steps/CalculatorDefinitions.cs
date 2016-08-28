using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Calculator.Steps
{
    [Binding]
    public sealed class CalculatorDefinitions
    {
        public Domain.Calculator Calculator { get; set; }

        [Given(@"I have a new calculator")]
        public void GivenIHaveANewCalculator()
        {
            Calculator = new Domain.Calculator();
        }

        [Given("I have entered (.*)")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            Calculator.Push(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            Calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.That(Calculator.Result, Is.EqualTo(result));
        }
    }
}
