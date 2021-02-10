using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/usercollections")]
    [ApiController]
    [AngajatisResultFilter]
    public class AngajatiCollectionsController : Controller
    {
        private readonly IAngajatiRepository _angajatiRepository;
        private IMapper _mapper;

        public AngajatiCollectionsController(IAngajatiRepository angajatiRepository, IMapper mapper)
        {
            _angajatiRepository = angajatiRepository ?? throw new ArgumentNullException(nameof(angajatiRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({employeeIds})", Name = "GetEmployeeCollection")]
        public async Task<IActionResult> GetEmployeeCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]
            IEnumerable<int> employeeIds)
        {
            var employeeEntities = await _angajatiRepository.GetEmployeesAsync(employeeIds);
            if (employeeIds.Count() != employeeEntities.Count())
            {
                return NotFound();
            }

            return Ok(employeeEntities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeCollection(
            [FromBody] IEnumerable<AngajatiForCreation> employeeCollection)
        {
            var employeeEntities = _mapper.Map<IEnumerable<Entities.Angajati>>(employeeCollection);

            foreach (var employeeEntity in employeeEntities)
            {
                _angajatiRepository.AddEmployee(employeeEntity);
            }

            await _angajatiRepository.SaveChangesAsync();

            var employeesToReturn =
                await _angajatiRepository.GetEmployeesAsync(employeeEntities.Select(b => b.Id).ToList());

            var employeeIds = string.Join(",", employeesToReturn.Select(e => e.Id));

            return CreatedAtRoute("GetEmployeeCollection", new{employeeIds}, employeesToReturn);
        }
    }
}
