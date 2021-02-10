using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AngajatiController : ControllerBase
    {
        private IAngajatiRepository _angajatiRepository;
        private IMapper _mapper;

        public AngajatiController( IAngajatiRepository angajatiRepository, IMapper mapper)
        {
            _angajatiRepository = angajatiRepository ?? throw new ArgumentNullException(nameof(angajatiRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("p={pin}", Name = "GetManager")]
        public async Task<IActionResult> GetManager(string pin)
        {
            bool manager = await _angajatiRepository.GetManagerAsync(pin);
            return Ok(manager);
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetUserNames()
        {
            var userNames = await  _angajatiRepository.GetAllEmployeeNames();

            return Ok(userNames);
        }

        [HttpGet]
        [AngajatisResultFilter]
        public async Task<IActionResult> GetEmployees()
        {
            var employeeEntities = await _angajatiRepository.GetEmployeesAsync();
            return Ok(employeeEntities);
        }

        [HttpGet]
        [AngajatiResultFilter]
        [Route("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employeeEntity = await _angajatiRepository.GetEmployeeAsync(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }
            return Ok(employeeEntity);
        }

        [HttpGet]
        [Route("active={id}")]
        public async Task<IActionResult> EmployeeState(int id)
        {
            var employeeState = await _angajatiRepository.IsUserActiveAsync(id);
            if (employeeState == null)
            {
                return NotFound();
            }
            return Ok(employeeState);
        }

        [HttpPut]
        [AngajatiResultFilter]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] AngajatiForUpdate employeeForUpdate, int id)
        {
            var employeeEntity = await _angajatiRepository.GetEmployeeAsync(id);
            if (employeeEntity == null)
            {
                return BadRequest();
            }

            _mapper.Map(employeeForUpdate, employeeEntity);

            _angajatiRepository.UpdateEmployee(employeeEntity);

            if (!await _angajatiRepository.SaveChangesAsync())
            {
                throw new Exception($"Updating a employee {employeeEntity.Angajat} failed on save.");
            }

            return NoContent();
        }
        [HttpPost]
        [AngajatiResultFilter]
        public async Task<IActionResult> CreateEmployee([FromBody]AngajatiForCreation employee)
        {
            var employeeEntity = _mapper.Map<Entities.Angajati>(employee);
            _angajatiRepository.AddEmployee(employeeEntity);
            //TODO validations before saving the entity 
            await _angajatiRepository.SaveChangesAsync();

            await _angajatiRepository.GetEmployeeAsync(employeeEntity.Id);

            return CreatedAtRoute("GetEmployee", new { employeeEntity.Id}, employeeEntity);
        }
    }
}
