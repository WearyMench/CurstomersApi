using CurstomersApi.Dtos;
using CurstomersApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CurstomersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDatabaseContext customerDatabaseContext;
        public CustomerController(CustomerDatabaseContext customerDatabaseContext)
        {
            this.customerDatabaseContext = customerDatabaseContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<List<CustomerDto>> GetCustomer() => throw new NotImplementedException();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerEntity result = await customerDatabaseContext.Get(id);
            return new OkObjectResult(result.ToDto());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await customerDatabaseContext.Add(customer);
            return new CreatedResult($"http://localhost:7030/api/customer/{result.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<CustomerDto> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
