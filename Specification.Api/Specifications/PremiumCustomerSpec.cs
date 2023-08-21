using Specification.Api.Models;
using Specification.Infrastucture;

namespace Specification.Api.Specifications
{
    public class PremiumCustomerSpec : Spec<Customer>
    {
        public PremiumCustomerSpec() : base(x => DateTime.Now.Year - x.MemberSince.Year > 12) { }
    }
}