using AutoMapper;
using back_project.Entities;
using back_project.Services.Dtos;

namespace back_project.Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DriverRequestDto, Driver>();
            CreateMap<Driver, DriverResponseDto>();
            CreateMap<DriverRequestDto, DriverResponseDto>();
         

            CreateMap<Vehicle, VehicleResponseDto>()
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => MapRoutes(src.Routes)));

            CreateMap<VehicleResponseDto, Vehicle>();

            CreateMap<VehicleRequestDto, Vehicle>()
                .ForMember(dist => dist.Routes, opt => opt.MapFrom(MapVehicleRoutes));


        }

        private List<Journey> MapVehicleRoutes( VehicleRequestDto vehicleRequestDto, Vehicle vehicle)
        {
            var vehicleRoute = new List<Journey>();

            foreach (var driver in vehicleRequestDto.Drivers)
            {
                vehicleRoute.Add(new Journey { DriverId = driver, Description = vehicleRequestDto.DescriptionJourney });
            }

            return vehicleRoute;
        }

        private List<RouterResponseDto> MapRoutes(List<Journey> routes)
        {
            var routesResponse = new List<RouterResponseDto>();

            if (routes.Count == 0)
                return routesResponse; 

            foreach (var route in routes)
            {
                routesResponse.Add(new RouterResponseDto
                {
                    Id = route.Id,
                    Description = route.Description,
                    Driver = new DriverResponseDto
                    {
                        FirstName = route.Driver.FirstName,
                        LastName = route.Driver.LastName,
                        Ssn = route.Driver.Ssn,
                        Dob = route.Driver.Dob,
                        Address = route.Driver.Address,
                        City = route.Driver.City,
                        Zip = route.Driver.Zip, 
                        Phone = route.Driver.Phone,
                        Active = route.Driver.Active,
                    }

                }); 
            }

            return routesResponse;  
        }
    }
}
