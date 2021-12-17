using Pms.Core.Models;
using System.Collections.Generic;
 
namespace Pms.Core.Interface
{
    public interface IConfigurationRetrieval
    {
        List<MembershipTypeModel> RetrieveMembershipTypes();
    }
}
