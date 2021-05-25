using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class AngajatiRepository : IAngajatiRepository, IDisposable
    {
        private AppDbContext _context;

        public AngajatiRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Angajati>> GetEmployeesAsync()
        {
            return await _context.Angajatis.ToListAsync();
        }

        public async Task<IEnumerable<Angajati>> GetEmployeesAsync(IEnumerable<int> employeeIds)
        {
            return await _context.Angajatis.Where(a => employeeIds.Contains(a.Id)).ToListAsync();
        }

        public async Task<bool> GetManagerAsync(string pin)
        {
            Angajati employee = await _context.Angajatis.FirstOrDefaultAsync(a => a.CodAngajat == pin);
            if (employee == null)
                return false;
            else if (employee.Mansione == "CAPO LINEA")
                return true;
            else return false;
        }

        public async Task<IEnumerable<string>> GetAllEmployeeNames()
        {
            return await _context.Angajatis.Select(a => a.Angajat).ToListAsync();
        }

        public async Task<bool?> IsUserActiveAsync(int id)
        {
            var employee = await _context.Angajatis.FirstOrDefaultAsync(a => a.Id == id);
            return employee?.Active;
        }

        public async Task<Angajati> GetEmployeeAsync(int id)
        {
            return await _context.Angajatis.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Angajati> GetEmployeeAsync(string name, string code)
        {
            return await _context.Angajatis.FirstOrDefaultAsync(a => a.Angajat == name && a.CodAngajat == code);
        }

        public void UpdateEmployee(Angajati employee)
        {

        }

        public void AddEmployee(Angajati employeeToAdd)
        {
            if (employeeToAdd == null)
            {
                throw new ArgumentNullException(nameof(employeeToAdd));
            }

            _context.Add(employeeToAdd);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context !=null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
