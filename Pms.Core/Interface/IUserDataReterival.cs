using Pms.Core.Models;

namespace Core
{
    public interface IUserDataRetrieval
    {
        UserModel RetrieveUserDetails(string username);
    }
}