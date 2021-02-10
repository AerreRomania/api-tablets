using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.JobEfficiency;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/efficiency")]
    [ApiController]
    public class JobEfficiencyController : ControllerBase
    {
        private IJobEfficiencyRepository _efficiencyRepository;
        private IMapper _mapper;

        public JobEfficiencyController(IJobEfficiencyRepository efficiencyRepository, IMapper mapper)
        {
            _efficiencyRepository = efficiencyRepository ?? throw new ArgumentNullException(nameof(efficiencyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [JobEfficiencyResultFilter]
        [Route("{id}", Name = nameof(GetEfficiency))]
        public async Task<IActionResult> GetEfficiency(int id)
        {
            var efficiencyEntity =  await _efficiencyRepository.GetJobEfficiencyAsync(id);
            if (efficiencyEntity == null)
            {
                return NotFound();
            }

            return Ok(efficiencyEntity);
        }

        [HttpPost]
        [JobEfficiencyResultFilter]
        public async Task<IActionResult> CreateEfficiency([FromBody] JobEfficiencyForCreation efficiency)
        {
            var efficicencyEntity = _mapper.Map<Entities.JobEfficiency>(efficiency);
            _efficiencyRepository.AddJobEfficiency(efficicencyEntity);
            await _efficiencyRepository.SaveChangesAsync();
            await _efficiencyRepository.GetJobEfficiencyAsync(efficicencyEntity.EfficiencyID);
            return CreatedAtRoute(nameof(JobEfficiencyController.GetEfficiency),
                new {id = efficicencyEntity.EfficiencyID}, efficicencyEntity);
        }
    }
}
