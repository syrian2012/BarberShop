using AutoMapper;
using BarberShop.Dto;
using BarberShop.Interfaces;
using BarberShop.Models;
using BarberShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _mapper.Map<List<CustomerGetDto>>(_customerRepository.GetCustomers().ToList());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("/Customers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomersOriginals()
        {
            var customers = _customerRepository.GetCustomers().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerCreateDto createCustomer)
        {
            if (createCustomer == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(createCustomer);
            customerMap.CreateTime = DateTime.Now;
            customerMap.IsDeleted = false;
            customerMap.IsActive = false;

            if (!_customerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Some Thing Went Wrong While Saving Your Entry");
                return StatusCode(500, ModelState);
            }

            return Ok("Customer Created Successfully");
        }
    }
}
