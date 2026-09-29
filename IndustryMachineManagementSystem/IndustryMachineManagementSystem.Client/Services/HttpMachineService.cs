using IndustryMachineManagementSystem.Client.Dtos;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;

namespace IndustryMachineManagementSystem.Client.Services
{
    public class HttpMachineService : IHttpMachineService
    {
        private readonly HttpClient _httpClient;
        public HttpMachineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<MachineDto> CreateMachineAsync(CreateMachineDto machine)
        {
            MachineDto machineDto = new MachineDto();

            if (machine == null)
            {
                machineDto?.LastData = "No data";
                machineDto?.IsOnline = false;
                machineDto?.Name = string.IsNullOrWhiteSpace(machineDto.Name) ? $"Machine {"mock"}" : machineDto.Name;
            }
            var response = await _httpClient.PostAsync("/api/machines", JsonContent.Create(machineDto));

            return await response.Content.ReadFromJsonAsync<MachineDto>() ?? machineDto!;
        }

        public async Task<bool> DeleteMachineAsync(Guid id)
        {
            var machine = await _httpClient.GetFromJsonAsync<MachineDto>($"/api/machines/{id}");

            if (machine != null)
            {
                var response = await _httpClient.DeleteAsync($"/api/machines/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<MachineDto> GetMachineByIdAsync(Guid id)
        {
            var machine = await _httpClient.GetFromJsonAsync<MachineDto>($"/api/machines/{id}");

            return machine!;
        }

        public async Task<List<MachineDto>> GetMachinesAsync()
        {
            var machines = await _httpClient.GetFromJsonAsync<List<MachineDto>>("/api/machines")
              ?? new List<MachineDto>();
            return machines;
        }

        public async Task<MachineDto> StartMachineAsync(Guid id)
        {
            var machinedto = await GetMachineByIdAsync(id);
            if (machinedto != null)
            {
                machinedto.IsOnline = true;
                machinedto.LastUpdated = DateTime.Now;
                await _httpClient.PutAsync($"/api/machines/{id}", JsonContent.Create(machinedto));
                
            }
            return machinedto!;
        }

        public async Task<MachineDto> StopMachineAsync(Guid id)
        {
            var machinedto = await GetMachineByIdAsync(id);
            if (machinedto != null)
            {
                machinedto.IsOnline = false;
                machinedto.LastUpdated = DateTime.Now;
                await _httpClient.PutAsync($"/api/machines/{id}", JsonContent.Create(machinedto));

            }
            return machinedto!;
        }

        public async Task<MachineDto> UpdateMachineAsync(UpdateMachineDto machine, Guid id)
        {
                var machinedto = await GetMachineByIdAsync(id);
                if (machinedto != null)
            {
                machinedto.Name = machine.Name;
                machinedto.IsOnline = machine.IsOnline;
                machinedto.LastData = machine.LastData;
                machinedto.LastUpdated = DateTime.Now;
                await _httpClient.PutAsync($"/api/machines/{id}", JsonContent.Create(machinedto));

            }
            return machinedto!;
        }

    }
}