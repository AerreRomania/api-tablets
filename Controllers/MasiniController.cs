using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/machines")]
    [ApiController]
    public class MasiniController : ControllerBase
    {
        private IMasiniRepository _masiniRepository;
        private IMapper _mapper;

        public MasiniController(IMasiniRepository masiniRepository, IMapper mapper)
        {
            _masiniRepository = masiniRepository ?? throw new ArgumentNullException(nameof(masiniRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("sector={idSector}/line={line}")]
        [MasinisResultFilter]
        public async Task<IActionResult> GetMachinesForSector(int idSector, string line)
        {
            var machines = await _masiniRepository.GetMachinesAsync(idSector, line);
            if (machines == null)
            {
                return NotFound();
            }

            return Ok(machines);
        }


        [HttpGet]
        [Route("{id}")]
        [MasiniResultFilter]
        public async Task<IActionResult> GetMachine(int id)
        {
            var machineEntity = await _masiniRepository.GetMachineAsync(id);
            if (machineEntity==null)
            {
                return NotFound();
            }

            return Ok(machineEntity);
        }

        [HttpGet]
        [Route("active={id}")]
        public async Task<IActionResult> MachineState(int id)
        {
            var machineState = await _masiniRepository.IsMachineActiveAsync(id);
            if (machineState == null)
            {
                return NotFound();
            }
            return Ok(machineState);
        }

        [HttpPut]
        [Route("{id}")]
        [MasiniResultFilter]
        public async Task<IActionResult> UpdateMachine([FromBody] MasiniForUpdate machineForUpdate, int id)
        {
            var machineEntity = await _masiniRepository.GetMachineAsync(id);
            if (machineEntity==null)
            {
                return BadRequest();
            }

            _mapper.Map(machineForUpdate, machineEntity);

          //  _masiniRepository.UpdateMachine(machineEntity);

            if (!await _masiniRepository.SaveChangesAsync())
            {
                throw new Exception($"Updating a employee {machineEntity.CodMasina}-{machineEntity.Descriere} failed on save.");
            }

            return NoContent();
        }

    }
}
