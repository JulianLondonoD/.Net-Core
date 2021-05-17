using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Data;
using Vueling.Test.Entities;

namespace Vueling.Test.Repository.Repository
{
    public class RatesRepository : IRatesRepository
    {
        private readonly VuelingDbContext _context;
        public RatesRepository(VuelingDbContext context)
        {
            _context = context;
        }

        public async Task<IList<RateEntity>> read(IList<RateEntity> rates)
        {
            using (_context)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        string strSQL = "TRUNCATE TABLE Rates";
                        await _context.Database.ExecuteSqlRawAsync(strSQL);
                        foreach (RateEntity rate in rates)
                        {
                            _context.Entry(rate).State = EntityState.Added;
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return await _context.Rates.ToListAsync();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<IList<RateEntity>> read()
        {
            try
            {
                return await _context.Rates.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
