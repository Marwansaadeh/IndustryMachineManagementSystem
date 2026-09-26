using AutoMapper;
using IndustryMachineManagementSystem.Client.Dtos;
using IndustryMachineManagementSystem.Domain.Models;

namespace IndustryMachineManagementSystem.Infrastructure.Data
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Machine, MachineDto>();
            CreateMap<MachineDto, Machine>();
            CreateMap<UpdateMachineDto, Machine>().ReverseMap();
            CreateMap<CreateMachineDto, Machine>();
        }
    }
}
