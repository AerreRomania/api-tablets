using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IButoaneRepository
    {
        Task<Butoane> GetClickAsync(long id);
        void AddClick(Butoane butoaneToAdd);
        Task<bool> SaveChangesAsync();
    }
}
