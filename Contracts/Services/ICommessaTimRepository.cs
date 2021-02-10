using System.Threading.Tasks;
using SmartB.API.Entities;


namespace SmartB.API.Contracts.Services
{
    public interface ICommessaTimRepository
    {
        Task<CommessaTIM> GetCommessaTimAsync(string barcode);
    }
}
