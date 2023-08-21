using Microsoft.AspNetCore.Mvc;
using Specification.Api.Models;
using Specification.Api.Specifications;
using static Specification.Infrastucture.SpecBase;
using static Specification.Infrastucture.SpecFactory;

namespace Specification.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "EvaluateOperation")]
        public bool EvaluateOperation(string name, int yearOfBirth, int memberSince, bool expected)
        {
            var customer = new Customer(name, new DateTime(yearOfBirth, 1, 1), DateTime.Now.AddYears(-1 * memberSince));

            // define specifications needed!
            var spec = (Default<AdultCustomerSpec>()
                        .And(Default<ValidCustomerNameSpec>()))
                        .Or(Not(Default<PremiumCustomerSpec>()));
            
            // satisfied expressions 
            var evaluation = spec.IsSatisfied(customer);

            return evaluation == expected;
        }

        [HttpGet(Name = "EvaluatesNotOperation")]
        public bool EvaluatesNotOperation(int year, bool expected)
        {
            var customer = new Customer("test", new DateTime(year, 1, 1));
            var spec = Not(Default<AdultCustomerSpec>());
            var evaluation = spec.IsSatisfied(customer);

            return evaluation == expected;
        }

    }
}