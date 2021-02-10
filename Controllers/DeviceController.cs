using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.Device;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IMapper _mapper;
        private IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [DeviceResultFilter]
        [Route("sn={serial}")]
        public async Task<IActionResult> GetDeviceBySN(string serial)
        {
            var deviceEntity = await _deviceRepository.GetDeviceBySNAsync(serial);
            if (deviceEntity == null)
            {
                return NotFound();
            }
            return Ok(deviceEntity);
        }

        [HttpGet]
        [DeviceResultFilter]
        [Route("{id}", Name = nameof(GetDevice))]
        public async Task<IActionResult> GetDevice(int id)
        {
            var deviceEntity = await _deviceRepository.GetDeviceAsync(id);
            if (deviceEntity==null)
            {
                return NotFound();
            }
            return Ok(deviceEntity);
        }


        [HttpPut]
        [DeviceResultFilter]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDevice([FromBody] DeviceForUpdate deviceForUpdate, int id)
        {
            var deviceEntity = await _deviceRepository.GetDeviceAsync(id);
            if (deviceEntity == null)
            {
                return BadRequest();
            }

            _mapper.Map(deviceForUpdate, deviceEntity);
            _deviceRepository.UpdateDevice(deviceEntity);
            if (!await _deviceRepository.SaveChangesAsync())
            {
                throw new Exception($"Updating a employee {deviceEntity.DeviceID} failed on save.");
            }

            return NoContent();
        }

        [HttpPost]
        [DeviceResultFilter]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceForCreation device)
        {
            var deviceEntity = _mapper.Map<Entities.Devices>(device);
            _deviceRepository.AddDevice(deviceEntity);
            await _deviceRepository.SaveChangesAsync();
            await _deviceRepository.GetDeviceAsync(deviceEntity.DeviceID);
            return CreatedAtRoute(nameof(GetDevice), new {id = deviceEntity.DeviceID}, deviceEntity);
        }

    }
}
