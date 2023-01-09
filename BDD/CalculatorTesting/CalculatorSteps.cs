using TechTalk.SpecFlow;

namespace BDD.CalculatorTesting;

[Binding]
public class CalculatorSteps
{
    [Given(@"I start calculator")]
    public void GivenIStartCalculator()
    {
        throw new NotImplementedException();
    }

    [Given(@"I have the first number (.*)")]
    public void GivenIHaveTheFirstNumber(int number)
    {
        throw new NotImplementedException();
    }

    [Given(@"I have the second number (.*)")]
    public void GivenIHaveTheSecondNumber(int number)
    {
        throw new NotImplementedException();
    }

    [When(@"I want to sum these numbers")]
    public void WhenIWantToSumTheseNumbers()
    {
        throw new NotImplementedException();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        throw new NotImplementedException();
    }

    [When(@"I want to subtract these numbers")]
    public void WhenIWantToSubtractTheseNumbers()
    {
        throw new NotImplementedException();
    }

    [When(@"I want to make multiplication of these numbers")]
    public void WhenIWantToMakeMultiplicationOfTheseNumbers()
    {
        throw new NotImplementedException();
    }

    [When(@"I want to make division of these numbers")]
    public void WhenIWantToMakeDivisionOfTheseNumbers()
    {
        throw new NotImplementedException();
    }
}