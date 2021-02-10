using System.Collections.Generic;
using System.Threading.Tasks;
using SmartB.API.Models;

namespace SmartB.API.Contracts.Services
{
    public interface IOperatiArticolRepository
    {
        Task<IEnumerable<Phases>> GetPhasesForArticleAsync(int articleId, string machineName);

    }
}
