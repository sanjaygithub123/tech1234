using System;
	using TechTalk.SpecFlow;
	
	namespace MyNamespace
	{
		[Binding]
		public class StepDefinitions
		{
			private readonly ScenarioContext _scenarioContext;
	
			public StepDefinitions(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}

            [Given(@"the membership types")]
public void Giventhemembershiptypes()
{
	_scenarioContext.Pending();
}

[Given(@"a user")]
public void Givenauser()
{
	_scenarioContext.Pending();
}

[When(@"Access Result is Required")]
public void WhenAccessResultisRequired()
{
	_scenarioContext.Pending();
}

[Then(@"thenn result should be (.*)")]
public void Thentheresultshouldbe(int args1)
{
	_scenarioContext.Pending();
}


			
		}
	}