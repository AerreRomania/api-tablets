using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Pause;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/pause")]
    [ApiController]
    public class PauseController : ControllerBase
    {
        private IPauseRepository _pauseRepository;
        private IMapper _mapper;

        public PauseController(IPauseRepository pauseRepository, IMapper mapper)
        {
            _pauseRepository = pauseRepository ?? throw new ArgumentNullException(nameof(pauseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [PauseResultFilter]
        [Route("{id}", Name = nameof(GetPause))]
        public async Task<IActionResult> GetPause(int id)
        {
            var pauseEntity = await _pauseRepository.GetPauseAsync(id);
            if (pauseEntity == null)
            {
                return NotFound();
            }

            return Ok(pauseEntity);
        }

        [HttpGet]
        [PausesResultFilter]
        [Route("job={id}")]
        public async Task<IActionResult> GetPausesForJob(int id)
        {
            var pauses = await _pauseRepository.GetPausesAsync(id);
            if (pauses==null)
            {
                return NotFound();
            }

            return Ok(pauses);
        }

        [HttpPost]
        [PauseResultFilter]
        public async Task<IActionResult> CreatePause([FromBody] PauseForCreation pause)
        {
            var pauseEntity = _mapper.Map<Entities.Pause>(pause);
            _pauseRepository.AddPause(pauseEntity);
            await _pauseRepository.SaveChangesAsync();
            await _pauseRepository.GetPauseAsync(pauseEntity.PauseID);
            return CreatedAtRoute(nameof(PauseController.GetPause), new { id=pauseEntity.PauseID}, pauseEntity);
        }
    }
}
