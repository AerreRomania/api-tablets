using System.Collections.Generic;
using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IAngajatiRepository
    {
        Task<IEnumerable<Angajati>> GetEmployeesAsync();
        Task<IEnumerable<Angajati>> GetEmployeesAsync(IEnumerable<int> employeeIds);
        Task<IEnumerable<string>> GetAllEmployeeNames();
        Task<bool?> IsUserActiveAsync(int id);
        Task<Angajati> GetEmployeeAsync(int id);
        Task<Angajati> GetEmployeeAsync(string name, string code);

        void UpdateEmployee(Angajati employee);

        void AddEmployee(Angajati employee);

        Task<bool> SaveChangesAsync();

        Task<bool> GetManagerAsync(string pin);
    }
}
