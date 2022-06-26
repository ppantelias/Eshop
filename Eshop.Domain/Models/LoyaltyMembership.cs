namespace Eshop.Domain.Models
{
    public class LoyaltyMembership : BaseEntity
    {
        public int LoyaltyPoints { get; set; }
        public int TotalLoyaltyPointsGained { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }
        public bool Consent { get; set; }
        public Guid MembershipTierId { get; set; }
        public MembershipTier MembershipTier { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}