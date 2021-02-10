using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Articole;

namespace SmartB.API.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticolController : ControllerBase
    {
        private IArticolRepository _articolRepository;
        private IMapper _mapper;

        public ArticolController(IArticolRepository articolRepository, IMapper mapper)
        {
            _articolRepository = articolRepository ?? throw new ArgumentNullException(nameof(articolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}")]
        [ArticoleResultFilter]
        public async Task<IActionResult> GetArticle(int id)
        {
            var articleEntity = await _articolRepository.GetArticleAsync(id);
            if (articleEntity == null)
            {
                return NotFound();
            }

            return Ok(articleEntity);
        }
    }
}
