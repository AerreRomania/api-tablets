using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.OperatiArticol;

namespace SmartB.API.Controllers
{
    [Route("api/article/{articleId}/phases")]
    [ApiController]

    public class OperatiArticolController : ControllerBase
    {
        private IOperatiArticolRepository _operations;
        private IMapper _mapper;

        public OperatiArticolController(IOperatiArticolRepository operations, IMapper mapper)
        {
            _operations = operations ?? throw new ArgumentNullException(nameof(operations));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{machineName}")]
        [OperatiArticolResultFilter]
        public async Task<IActionResult> GetPhasesForArticle(int articleId, string machineName)
        {
            var articlePhases = await _operations.GetPhasesForArticleAsync(articleId, machineName);
            if (articlePhases == null)
            {
                return NotFound();
            }

            return Ok(articlePhases);

        }
    }
}
