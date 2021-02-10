using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters;

namespace SmartB.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAngajatiRepository _angajatiRepository;

        public AuthenticationController(IAngajatiRepository angajatiRepository)
        {
            _angajatiRepository = angajatiRepository ?? throw new ArgumentNullException(nameof(angajatiRepository));
        }

        [HttpGet]
        [Route("username={username}/password={password}")]
        [AngajatiResultFilter]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            var employee = await _angajatiRepository.GetEmployeeAsync(username, password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest();
            }

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
