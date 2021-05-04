using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class RealizariRepository : IRealizariRepository, IDisposable
    {
        private AppDbContext _context;

        public RealizariRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Realizari> GetJobAsync(int id)
        {
            return await _context.Realizari.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void AddJob(Realizari jobToAdd)
        {
            if (jobToAdd==null)
            {
                throw new ArgumentNullException(nameof(jobToAdd));
            }

            _context.Add(jobToAdd);
        }

        public async Task<int> GetProducedPiecesAsync(int orderId, int operationId)
        {
                          return await (from jobs in _context.Realizari
                                        join pieces in _context.Butoane on jobs.Id equals pieces.IdRealizare
                                        join orders in _context.Comenzis on jobs.IdComanda equals orders.Id
                                        join articles in _context.Articoles on orders.IdArticol equals articles.Id
                                        join articleOperations in _context.OperatiiArticols on
                                        new { IdArticol = articles.Id, jobs.IdOperatie } equals
                                        new { articleOperations.IdArticol, articleOperations.IdOperatie }
                                        where jobs.IdComanda == orderId &&
                                              jobs.IdOperatie == operationId &&
                                              jobs.Creat.Day == DateTime.Now.Day &&
                                              jobs.Creat.Month == DateTime.Now.Month &&
                                              jobs.Creat.Year == DateTime.Now.Year
                                        select new Models.JobPieces
                                        {
                                            Order = orders.NrComanda,
                                            Click = pieces.Id,
                                            Value = articleOperations.BucatiButon
                                        }).SumAsync(x => x.Value);
        }

        public void UpdateJob(Realizari job)
        {
            
        }

        public async Task<DateTime> GetLastClickAsync(int jobId)
        {
            var userData = await _context.Butoane.Where(a => a.IdRealizare.Equals(jobId)).ToListAsync();
            return userData.Count == 0 ? new DateTime(2011, 11, 11) : userData.LastOrDefault().Data;
        }

        public async Task<DateTime> GetServerTimeAsync()
        {
            var connection = _context.Database.GetDbConnection();
   
            if (connection.State == ConnectionState.Closed)
            {
               await connection.OpenAsync();
            }

            var command = connection.CreateCommand();
            command.CommandText = "SELECT GETDATE()";
            return (DateTime) await command.ExecuteScalarAsync();
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
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
       

    }
}
