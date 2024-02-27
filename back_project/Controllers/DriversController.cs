using back_project.Services;
using back_project.Services.Dtos;
using back_project.Services.Wrappers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace back_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService)
        {
            _driverService = driverService;
        }

        // GET: api/<DriversController>
        [HttpGet("get-all-drivers")]
        public async Task<ActionResult<Response<List<DriverResponseDto>>>> Get()
        {
            var result = await _driverService.GetDrivers();
           return StatusCode(result.StatusCode, result); 
        }

        // GET api/<DriversController>/5
        [HttpGet("get-driver-by-id/{id}")]
        public async Task<ActionResult<Response<List<DriverResponseDto>>>> Get(int id)
        {
            var result = await _driverService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }
        // POST api/<DriversController>
        [HttpPost("add-driver")]
        public async Task<ActionResult<Response<List<DriverResponseDto>>>> Post(DriverRequestDto driver)
        {
            var result = await _driverService.Add(driver);
            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<DriversController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<List<DriverResponseDto>>>> Put(int id, [FromBody]DriverResponseDto driver)
        {
            if (driver.Id != id)
                throw new Exception(""); 

            var result = await _driverService.Update(driver);
            return StatusCode(result.StatusCode, result);
        }

        // DELETE api/<DriversController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
