using System.Reflection;
using System;
using System.Collections.Generic;
using AccessFramework;
using Core;
using NSubstitute;
using Pms.Core.Interface;
using Pms.Core.Models;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace MyNamespace
	{
		[Binding]
		public class StepDefinitions
		{
			

            [Given(@"the membership types")]
public void Giventhemembershiptypes(Table table)
{
	var membershipTypes = this.GetMembershipTypeModelsFromTable(table);
    ScenarioContext.Current.Add("MembershipTypes", membershipTypes);
}

[Given(@"a user")]
public void Givenauser(Table table)
{
	var user = this.GetUsersFromTable(table)?.FirstOrDefault();
    ScenarioContext.Current.Add("User", user);
}

[When(@"Access Result is Required")]
public void WhenAccessResultisRequired()
{
	//data from context
    var membershipTypes = (List<MembershipTypeModel>)ScenarioContext.Current["MembershipTypes"];
    var user = (UserModel)ScenarioContext.Current["User"];
 
    //setup the mocks
    var configurationRetrieval = Substitute.For<IConfigurationRetrieval>();
    configurationRetrieval.RetrieveMembershipTypes().Returns(membershipTypes);
 
    var userDataRetrieval = Substitute.For<IUserDataRetrieval>();
    userDataRetrieval.RetrieveUserDetails(Arg.Any<string>()).Returns(user);
 
    //call to AccessFrameworkAnalyser
    var accessResult = new AccessFrameworkAnalyser(configurationRetrieval, userDataRetrieval).DetermineAccessResults(user.Username);
    ScenarioContext.Current.Add("AccessResult", accessResult);
}

[Then(@"then result should be")]
public void Thentheresultshouldbe(Table table)
{
	var expectedAccessResult = this.GetAccessResultFromTable(table);
 
    var accessResult = (AccessResultModel)ScenarioContext.Current["AccessResult"];
    Assert.AreEqual(false, accessResult.CanApply);
    Assert.AreEqual(false, accessResult.CanSearch);
}

private AccessResultModel GetAccessResultFromTable(Table table)
{
    var results = new AccessResultModel();
 
    foreach ( var row in table.Rows)
    {
               
 
        results.CanSearch = row.ContainsKey("CanSearch") ? Convert.ToBoolean(row["CanSearch"]) : false;
        results.CanApply = row.ContainsKey("CanApply") ? Convert.ToBoolean(row["CanApply"]) : false;
        
    }
 
    return results;
}

private List<UserModel> GetUsersFromTable(Table table)
{
    var results = new List<UserModel>();
 
    foreach ( var row in table.Rows)
    {
        var model = new UserModel();
        
 
        model.Username = row.ContainsKey("Username") ? row["Username"] : string.Empty;
        model.FirstName = row.ContainsKey("FirstName") ? row["FirstName"] : string.Empty;
        model.LastName = row.ContainsKey("LastName") ? row["LastName"] : string.Empty;
        model.MembershipTypeName = row.ContainsKey("MembershipTypeName") ? row["MembershipTypeName"] : string.Empty;
        model.CurrentUsage = new UserUsageModel();
        model.CurrentUsage.CurrentSearchesCount = row.ContainsKey("CurrentSearchesCount") ? Convert.ToInt32(row["CurrentSearchesCount"]) : 0;
        model.CurrentUsage.CurrentApplicationsCount = row.ContainsKey("CurrentApplicationsCount") ? Convert.ToInt32(row["CurrentApplicationsCount"]) : 0;
 
       
 
        results.Add(model);
    }
 
    return results;
}
private List<MembershipTypeModel> GetMembershipTypeModelsFromTable(Table table)
{
    var results = new List<MembershipTypeModel>();
 
    foreach ( var row in table.Rows)
    {
        var model = new MembershipTypeModel();
        model.Restriction = new RestrictionModel();
 
        model.MembershipTypeName = row.ContainsKey("MembershipTypeName") ? row["MembershipTypeName"] : string.Empty;
 
        if (row.ContainsKey("MaxSearchesPerDay"))
        {
            int maxSearchesPerDay = 0;
 
            if (int.TryParse(row["MaxSearchesPerDay"], out maxSearchesPerDay))
            {
                model.Restriction.MaxSearchesPerDay = maxSearchesPerDay;
            }
        }
 
        if (row.ContainsKey("MaxApplicationsPerDay"))
        {
            int maxApplicationsPerDay = 0;
 
            if (int.TryParse(row["MaxApplicationsPerDay"], out maxApplicationsPerDay))
            {
                model.Restriction.MaxApplicationsPerDay = maxApplicationsPerDay;
            }
        }
 
        results.Add(model);
    }
 
    return results;
}


			
		}
	}