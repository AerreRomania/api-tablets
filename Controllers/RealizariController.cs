using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Realizari;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{

    [Route("api/job")]
    [ApiController]
    public class RealizariController : ControllerBase
    {
        private IRealizariRepository _realizariRepository;
        private IMapper _mapper;

        public RealizariController(IRealizariRepository realizariRepository, IMapper mapper)
        {
            _realizariRepository = realizariRepository ?? throw new ArgumentNullException(nameof(realizariRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("last={id}")]
        public async Task<IActionResult> GetLastClickForJob(int id)
        {
            var clickEntity = await _realizariRepository.GetLastClickAsync(id);
            return Ok(clickEntity);
        }

        [HttpGet]
        [Route("{orderId}/{operationId}")]
        public async Task<IActionResult> GetProducedPieces(int orderId, int operationId)
        {
            int pieces = await _realizariRepository.GetProducedPiecesAsync(orderId, operationId);
            return Ok(pieces);
        }


        [HttpGet]
        [RealizariResultFilter]
        [Route("{id}", Name = nameof(GetJob))]
        public async Task<IActionResult> GetJob(int id)
        {
            var jobEntity = await _realizariRepository.GetJobAsync(id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return Ok(jobEntity);
        }

        [HttpPut]
        [RealizariResultFilter]
        [Route("{id}")]
        public async Task<IActionResult> UpdateJob([FromBody] RealizariForUpdate jobForUpdate, int id)
        {
            var jobEntity = await _realizariRepository.GetJobAsync(id);

            if (jobEntity == null)
            {
                return BadRequest();
            }

            _mapper.Map(jobForUpdate, jobEntity);

            _realizariRepository.UpdateJob(jobEntity);

            if (!await _realizariRepository.SaveChangesAsync())
            {
                throw new Exception($"Updating a job {jobEntity.Id} failed on save.");
            }

            return NoContent();
            // return CreatedAtRoute(nameof(RealizariController.GetJob), new {id = jobEntity.Id}, jobEntity);
        }

        [HttpPost]
        [RealizariResultFilter]
        public async Task<IActionResult> CreateJob([FromBody] RealizariForCreation job)
        {
            var jobEntity = _mapper.Map<Entities.Realizari>(job);
            _realizariRepository.AddJob(jobEntity);
            await _realizariRepository.SaveChangesAsync();
            await _realizariRepository.GetJobAsync(jobEntity.Id);
            return CreatedAtRoute(nameof(RealizariController.GetJob), new { id = jobEntity.Id}, jobEntity);
        }




        [HttpGet]
        [Route("date")]
        public async Task<IActionResult> GetServerDateTime()
        {
            var jobDate = await _realizariRepository.GetServerTimeAsync();
            if (jobDate == DateTime.MinValue || jobDate == DateTime.MaxValue)
            {
                return NotFound();
            }

            return Ok(jobDate);
        }
    }
}
