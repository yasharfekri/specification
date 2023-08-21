using Specification.Api.Models;
using Specification.Infrastucture;

namespace Specification.Api.Specifications
{
    public class ValidCustomerNameSpec : Spec<Customer>
    {
        public ValidCustomerNameSpec() : base(x => x.Name.Length > 0 && x.Name.Length < 15) { }
    }
}