using Specification.Api.Models;
using Specification.Infrastucture;

namespace Specification.Api.Specifications

{
    public class AdultCustomerSpec : Spec<Customer>
    {
        public AdultCustomerSpec() : base(x => DateTime.Now.Year - x.DateOfBirth.Year >= 18) { }
    }
}