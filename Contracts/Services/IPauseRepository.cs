using System.Collections.Generic;
using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IPauseRepository
    {
        Task<Pause> GetPauseAsync(int id);
        Task<IEnumerable<Pause>> GetPausesAsync(int jobId);
        void AddPause(Pause pause);
        Task<bool> SaveChangesAsync();
    }
}
