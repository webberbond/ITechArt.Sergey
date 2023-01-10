using NUnit.Framework;
using TDD.CalculatorTesting;
using TechTalk.SpecFlow;

namespace BDD.CalculatorTesting;

[Binding]
public class CalculatorSteps
{
    private Calculator _calculator;
    
    [Given(@"I start calculator")]
    public void GivenIStartCalculator()
    {
        _calculator = new Calculator();
    }

    [Given(@"I have the first number (.*)")]
    public void GivenIHaveTheFirstNumber(int number)
    {
        _calculator.FirstNumber = number;
    }

    [Given(@"I have the second number (.*)")]
    public void GivenIHaveTheSecondNumber(int number)
    {
        _calculator.SecondNumber = number;
    }

    [When(@"I want to sum these numbers")]
    public void WhenIWantToSumTheseNumbers()
    {
        _calculator.Sum();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        Assert.AreEqual(expectedResult, _calculator.Result);
    }

    [When(@"I want to subtract these numbers")]
    public void WhenIWantToSubtractTheseNumbers()
    {
        _calculator.Subtract();
    }

    [When(@"I want to make multiplication of these numbers")]
    public void WhenIWantToMakeMultiplicationOfTheseNumbers()
    {
        _calculator.Multiplication();
    }

    [When(@"I want to make division of these numbers")]
    public void WhenIWantToMakeDivisionOfTheseNumbers()
    {
        _calculator.Division();
    }
}