using AutoMapper;
using back_project.Data;
using back_project.Entities;
using back_project.Services.Dtos;
using back_project.Services.Wrappers;

namespace back_project.Services
{
    public class VehicleService
    {
        private readonly IRepositoryGeneric<Vehicle> _vehicleRepository;
        private readonly IRepositoryGeneric<Driver> _driverRepository;
        private readonly IMapper _mapper;

        public VehicleService(
            IRepositoryGeneric<Vehicle> vehicleRepository,
            IRepositoryGeneric<Driver> driverRepository, 
            IMapper mapper
            )
        {
            _vehicleRepository = vehicleRepository;
            _driverRepository = driverRepository; 
            _mapper = mapper;
        }

        public async Task<Response<List<VehicleResponseDto>>> GetDrivers()
        {
            var result = await _vehicleRepository.GetAll();
            var drivers = _mapper.Map<List<VehicleResponseDto>>(result);
            _vehicleRepository.Dispose();
            return new Response<List<VehicleResponseDto>>(drivers, StatusCodes.Status200OK);
        }

        public async Task<Response<VehicleResponseDto>> GetById(int id)
        {
            var result = await _vehicleRepository.GetById(id);
            var driver = _mapper.Map<VehicleResponseDto>(result);
            _vehicleRepository.Dispose();
            return new Response<VehicleResponseDto>(driver, StatusCodes.Status200OK);
        }

        public async Task<Response<VehicleResponseDto>> Add(VehicleRequestDto vehicle)
        {
            var result = _mapper.Map<Vehicle>(vehicle);
            var driversIds = vehicle.Drivers; 
            var drivers = await _driverRepository.GetAll();

            if(!driversIds.All(e => drivers.Select(o => o.Id).Contains(e)))
            {
                throw new Exception("Some drivers are not registered"); 
            }

            await _vehicleRepository.Add(result);
            await _vehicleRepository.Save();
            _vehicleRepository.Dispose();

            var vehicleResponse = _mapper.Map<VehicleResponseDto>(vehicle);

            return new Response<VehicleResponseDto>(vehicleResponse, StatusCodes.Status201Created);
        }

        public async Task<Response<VehicleResponseDto>> Update(VehicleResponseDto vehicle)
        {
            var result = _mapper.Map<Vehicle>(vehicle);
            _vehicleRepository.Update(result);
            await _vehicleRepository.Save();
            _vehicleRepository.Dispose();

            return new Response<VehicleResponseDto>(vehicle, StatusCodes.Status204NoContent);
        }
    }
}
