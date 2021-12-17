using Core;
using Pms.Core.Interface;
using Pms.Core.Models;
using System;
using System.Linq;
 
namespace AccessFramework
{
    public sealed class AccessFrameworkAnalyser
    {
        IConfigurationRetrieval _configurationRetrieval;
        IUserDataRetrieval _userDataRetrieval;       
 
        public AccessFrameworkAnalyser(IConfigurationRetrieval configurationRetrieval, IUserDataRetrieval userDataRetrieval)
        {
            if ( configurationRetrieval == null || userDataRetrieval == null)
            {
                throw new ArgumentNullException();
            }
 
            this._configurationRetrieval = configurationRetrieval;
            this._userDataRetrieval = userDataRetrieval;
        }
 
        public AccessResultModel DetermineAccessResults(string username)
        {            
            if ( string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException();
            }
 
            var userData = this._userDataRetrieval.RetrieveUserDetails(username);
            var membershipTypes = this._configurationRetrieval.RetrieveMembershipTypes();
 
            var userMembership = membershipTypes.FirstOrDefault(p => p.MembershipTypeName.Equals(userData.MembershipTypeName, StringComparison.OrdinalIgnoreCase));            
            var result = new AccessResultModel();
 
            if (userMembership != null)
            {
                result.CanApply = userData.CurrentUsage.CurrentApplicationsCount < userMembership.Restriction.MaxApplicationsPerDay ? true : false;
                result.CanSearch = userData.CurrentUsage.CurrentSearchesCount < userMembership.Restriction.MaxSearchesPerDay ? true : false;
            }
 
            return result;
        }
    }
}