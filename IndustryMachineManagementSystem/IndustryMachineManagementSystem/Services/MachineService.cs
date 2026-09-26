using AutoMapper;
using IndustryMachineManagementSystem.Client.Dtos;
using IndustryMachineManagementSystem.Contracts;
using IndustryMachineManagementSystem.Domain.Exceptions;
using IndustryMachineManagementSystem.Domain.Models;
using IndustryMachineManagementSystem.ServicesContracts;

namespace IndustryMachineManagementSystem.Services
{
    public class MachineService: IMachineService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MachineService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MachineDto>> GetMachinesAsync(bool trackChanges = false)
        {
            IEnumerable<Machine> pagedList = await _uow.MachineRepsoitory.GetMachinesAsync(trackChanges);
            var MachinesDtos = _mapper.Map<IEnumerable<MachineDto>>(pagedList);

            return MachinesDtos;

        }

        public async Task<MachineDto> GetMachineAsync(Guid id, bool trackChanges = false)
        {
            var dto = _mapper.Map<MachineDto>(await _uow.MachineRepsoitory.GetMachineAsync(id, trackChanges));

            if (dto == null) throw new MachineNotFoundException(id);

            return dto;
        }

        public async Task<MachineDto> UpdateMachineAsync(Guid id, UpdateMachineDto dto)
        {
            var existingMachine = await _uow.MachineRepsoitory.GetMachineAsync(id, trackChanges: true);

            if (existingMachine == null) throw new MachineNotFoundException(id);

            _mapper.Map(dto, existingMachine);

            await _uow.CompleteAsync();

            return _mapper.Map<MachineDto>(existingMachine); //For Demo
        }

        public async Task<MachineDto> CreateMachineAsync(CreateMachineDto dto)
        {
            var Machine = _mapper.Map<Machine>(dto);
            _uow.MachineRepsoitory.Create(Machine);
            await _uow.CompleteAsync();

            var created = _mapper.Map<MachineDto>(await _uow.MachineRepsoitory.GetMachineAsync(Machine.Id, trackChanges: false));

            return created;

        }

        public async Task DeleteMachineAsync(Guid id)
        {
            var Machine = await _uow.MachineRepsoitory.GetMachineAsync(id);

            if (Machine == null) throw new MachineNotFoundException(id);

            _uow.MachineRepsoitory.Delete(Machine);
            await _uow.CompleteAsync();
        }
    }
}
