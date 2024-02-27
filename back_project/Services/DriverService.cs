using AutoMapper;
using back_project.Data;
using back_project.Entities;
using back_project.Services.Dtos;
using back_project.Services.Wrappers;


namespace back_project.Services
{
    public class DriverService
    {
        private readonly IRepositoryGeneric<Driver> _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IRepositoryGeneric<Driver> driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<DriverResponseDto>>> GetDrivers()
        {
            var result = await _driverRepository.GetAll();
            var drivers = _mapper.Map<List<DriverResponseDto>>(result);
            _driverRepository.Dispose();
            return new Response<List<DriverResponseDto>>(drivers, StatusCodes.Status200OK);
        }

        public async Task<Response<DriverResponseDto>> GetById(int id)
        {
            var result = await _driverRepository.GetById(id); 
            var driver = _mapper.Map<DriverResponseDto>(result);
            _driverRepository.Dispose();
            return new Response<DriverResponseDto>(driver, StatusCodes.Status200OK);
        }

        public async Task<Response<DriverResponseDto>> Add(DriverRequestDto driver)
        {
            var result = _mapper.Map<Driver>(driver);
            await _driverRepository.Add(result);
            await _driverRepository.Save();
            _driverRepository.Dispose();
            var driverResponse = _mapper.Map<DriverResponseDto>(driver);

            return new Response<DriverResponseDto>(driverResponse, StatusCodes.Status201Created);
        }

        public async Task<Response<DriverResponseDto>> Update(DriverResponseDto driver)
        {
            var result = _mapper.Map<Driver>(driver); 
            _driverRepository.Update(result);
            await _driverRepository.Save();
            _driverRepository.Dispose();
    
            return new Response<DriverResponseDto>(driver, StatusCodes.Status204NoContent);
        }
    }
}
