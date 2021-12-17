namespace Pms.Core.Models
{
    public sealed class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
 
        public string FirstName { get; set; }
 
        public string LastName { get; set; }
 
        public string MembershipTypeName { get;set; }
 
        public UserUsageModel CurrentUsage { get; set; }
    }
}