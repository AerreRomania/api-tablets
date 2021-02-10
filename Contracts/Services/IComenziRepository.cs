using System.Collections.Generic;
using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IComenziRepository
    {
        Task<IEnumerable<Comenzi>> GetOrdersAsync(int idSector);
        Task<Comenzi> GetOrderAsync(int id);

        Task<Comenzi> GetOrderWithName(string commessa);
    }
}
