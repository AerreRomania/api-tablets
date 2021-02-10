using System;
using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IRealizariRepository
    {
        Task<Realizari> GetJobAsync(int id);

        void AddJob(Realizari job);

        void UpdateJob(Realizari job);

        Task<DateTime> GetLastClickAsync(int jobId);

        Task<DateTime> GetServerTimeAsync();

        Task<bool> SaveChangesAsync();

        Task<int> GetProducedPiecesAsync(int orderId, int operationId);
    }
}
