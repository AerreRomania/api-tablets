using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Butoane;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/click")]
    [ApiController]
    public class ButoaneController : ControllerBase
    {
        private IButoaneRepository _butoaneRepository;
        private IMapper _mapper;

        public ButoaneController(IButoaneRepository butoaneRepository, IMapper mapper)
        {
            _butoaneRepository = butoaneRepository ?? throw new ArgumentNullException(nameof(butoaneRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ButoaneResultFilter]
        [Route("{id}", Name = "GetClick")]
        public async Task<IActionResult> GetClick(int id)
        {
            var clickEntity = await _butoaneRepository.GetClickAsync(id);
            if (clickEntity==null)
            {
                return NotFound();
            }

            return Ok(clickEntity);
        }

        [HttpPost]
        [ButoaneResultFilter]
        public async Task<IActionResult> AddClick([FromBody] ButoaneForCreation click)
        {
            var clickEntity = _mapper.Map<Entities.Butoane>(click);

            _butoaneRepository.AddClick(clickEntity);
            await _butoaneRepository.SaveChangesAsync();
            await _butoaneRepository.GetClickAsync(clickEntity.Id);
            return CreatedAtRoute("GetClick", new {clickEntity.Id}, clickEntity);
        }
    }
}
