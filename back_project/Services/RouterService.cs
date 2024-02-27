using AutoMapper;
using back_project.Data;
using back_project.Entities;
using back_project.Services.Dtos;
using back_project.Services.Wrappers;

namespace back_project.Services
{
    public class RouterService
    {
        private readonly IRepositoryGeneric<Journey> _routeRepository;
        private readonly IMapper _mapper;

        public RouterService(IRepositoryGeneric<Journey> routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<RouterResponseDto>>> GetDrivers()
        {
            var result = await _routeRepository.GetAll();
            var drivers = _mapper.Map<List<RouterResponseDto>>(result);
            _routeRepository.Dispose();
            return new Response<List<RouterResponseDto>>(drivers, StatusCodes.Status200OK);
        }

        public async Task<Response<RouterResponseDto>> GetById(int id)
        {
            var result = await _routeRepository.GetById(id);
            var driver = _mapper.Map<RouterResponseDto>(result);
            _routeRepository.Dispose();
            return new Response<RouterResponseDto>(driver, StatusCodes.Status200OK);
        }

        public async Task<Response<RouterResponseDto>> Add(RouterRequestDto driver)
        {
            var result = _mapper.Map<Journey>(driver);
            await _routeRepository.Add(result);
            await _routeRepository.Save();
            _routeRepository.Dispose();
            var driverResponse = _mapper.Map<RouterResponseDto>(driver);

            return new Response<RouterResponseDto>(driverResponse, StatusCodes.Status201Created);
        }

        public async Task<Response<RouterResponseDto>> Update(RouterResponseDto router)
        {
            var result = _mapper.Map<Journey>(router);
            _routeRepository.Update(result);
            await _routeRepository.Save();
            _routeRepository.Dispose();

            return new Response<RouterResponseDto>(router, StatusCodes.Status204NoContent);
        }
    }
}
