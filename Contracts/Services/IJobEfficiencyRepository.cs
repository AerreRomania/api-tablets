using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IJobEfficiencyRepository
    {
        Task<JobEfficiency> GetJobEfficiencyAsync(int id);
        void AddJobEfficiency(JobEfficiency jobEfficiency);
        Task<bool> SaveChangesAsync();
    }
}
