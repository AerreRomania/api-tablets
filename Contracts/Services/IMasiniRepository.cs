using System.Collections.Generic;
using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IMasiniRepository
    {
        Task<IEnumerable<Masini>> GetMachinesAsync(int idSector, string line);

        Task<Masini> GetMachineAsync(int id);

        Task<bool?> IsMachineActiveAsync(int id);

        void UpdateMachine(Masini machineForUpdate);

        Task<bool> SaveChangesAsync();
    }
}
