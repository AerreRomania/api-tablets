using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IArticolRepository
    {
        Task<Articole> GetArticleAsync(int id);
    }
}
