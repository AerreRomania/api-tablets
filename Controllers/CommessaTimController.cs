using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.CommessaTim;

namespace SmartB.API.Controllers
{
    [Route("api/tim")]
    [ApiController]
    public class CommessaTimController : ControllerBase
    {
        private ICommessaTimRepository _commessaTimRepository;

        public CommessaTimController(ICommessaTimRepository commessaTimRepository)
        {
            _commessaTimRepository = commessaTimRepository ?? throw new ArgumentNullException(nameof(commessaTimRepository));
        }

        [HttpGet]
        [Route("{barcode}")]
        [CommessaTimResultFilter]
        public async Task<IActionResult> GetCommessaTim(string barcode)
        {
            var comessaTimEntity = await _commessaTimRepository.GetCommessaTimAsync(barcode);
            if (comessaTimEntity == null)
            {
                return NotFound();
            }

            return Ok(comessaTimEntity);
        }
    }
}
