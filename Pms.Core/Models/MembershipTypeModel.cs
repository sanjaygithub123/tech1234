namespace Pms.Core.Models
{
    public sealed class MembershipTypeModel
    {
        public string MembershipTypeName { get; set; }
 
        public RestrictionModel Restriction { get; set; }
    }
}