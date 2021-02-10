using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Comenzi;

namespace SmartB.API.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class ComenziController : ControllerBase
    {
        private IComenziRepository _comenziRepository;
        private IMapper _mapper;

        public ComenziController(IComenziRepository comenziRepository, IMapper mapper)
        {
            _comenziRepository = comenziRepository ?? throw new ArgumentNullException(nameof(comenziRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("sector={idSector}")]
        [ComenzisResultFilter]
        public async Task<IActionResult> GetOrdersForSector(int idSector)
        {
            var orders = await _comenziRepository.GetOrdersAsync(idSector);
            if (orders==null)
            {
                return NotFound();
            }
            return Ok(orders);
        }


        [HttpGet]
        [Route("{id}")]
        [ComenziResultFilter]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orderEntity = await _comenziRepository.GetOrderAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return Ok(orderEntity);
        }

        [HttpGet]
        [Route("{commessa}")]
        [ComenziResultFilter]
        public async Task<IActionResult> GetOrderWithName(string commessa)
        {
            var orderEntity = await _comenziRepository.GetOrderWithName(commessa);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(orderEntity);
        }
    }
}
