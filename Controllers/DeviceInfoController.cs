using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartB.API.Contracts.Services;
using SmartB.API.Filters.DeviceInfo;
using SmartB.API.Models;

namespace SmartB.API.Controllers
{
    [Route("api/deviceinfo")]
    [ApiController]
    public class DeviceInfoController : ControllerBase
    {
        private IDeviceInfoRepository _deviceInfoRepository;
        private IMapper _mapper;

        public DeviceInfoController(IDeviceInfoRepository deviceInfoRepository, IMapper mapper)
        {
            _deviceInfoRepository = deviceInfoRepository ?? throw new ArgumentException(nameof(deviceInfoRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        [DevicesInfoResultFilter]
        [Route("{id}" , Name = nameof(GetDeviceInfo))]
        public async Task<IActionResult> GetDeviceInfo(int id)
        {
            var deviceInfoEntity = await _deviceInfoRepository.GetDeviceInfoAsync(id);
            if (deviceInfoEntity == null)
            {
                return NotFound();
            }

            return Ok(deviceInfoEntity);
        }

        [HttpPut]
        [DeviceInfoResultFilter]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDeviceInfo([FromBody] DeviceInfoForUpdate deviceInfoForUpdate, int id)
        {
            var deviceInfoEntity = await _deviceInfoRepository.GetDeviceInfoAsync(id);
            if (deviceInfoEntity == null)
            {
                return BadRequest();
            }

            _mapper.Map(deviceInfoForUpdate, deviceInfoEntity);
            _deviceInfoRepository.UpdateDeviceInfo(deviceInfoEntity);
            if (!await _deviceInfoRepository.SaveChangesAsync())
            {
                throw new Exception($"Updating a employee {deviceInfoEntity.DeviceInfoID} failed on save.");
            }

            return NoContent();
        }

        [HttpPost]
        [DeviceInfoResultFilter]
        public async Task<IActionResult> CreateDeviceInfo([FromBody] DeviceInfoForCreation deviceInfoForCreations)
        {
            var deviceInfoEntity = _mapper.Map<Entities.DeviceInfo>(deviceInfoForCreations);
            _deviceInfoRepository.AddDeviceInfo(deviceInfoEntity);
            await _deviceInfoRepository.SaveChangesAsync();
            await _deviceInfoRepository.GetDeviceInfoAsync(deviceInfoEntity.DeviceInfoID);
            return CreatedAtRoute(nameof(GetDeviceInfo), new {id = deviceInfoEntity.DeviceInfoID}, deviceInfoEntity);
        }

    }
}
