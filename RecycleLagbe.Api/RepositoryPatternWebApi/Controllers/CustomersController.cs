﻿using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWebApi.DTOs;
using RepositoryPatternWebApi.Models;
using RepositoryPatternWebApi.Repositories;

namespace RepositoryPatternWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();

            var dtos = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName,
                Email = c.Email
            });

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var c = await _customerRepository.GetByIdAsync(id);
            if (c == null) return NotFound();

            var dto = new CustomerDTO
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName,
                Email = c.Email
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email
            };

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveAsync();

            dto.CustomerId = customer.CustomerId; // set generated ID

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO dto)
        {
            if (id != dto.CustomerId)
                return BadRequest("Id mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FullName = dto.FullName;
            existing.Email = dto.Email;

            _customerRepository.Update(existing);
            await _customerRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _customerRepository.Delete(existing);
            await _customerRepository.SaveAsync();

            return NoContent();
        }
    }
}