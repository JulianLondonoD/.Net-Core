using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Test.Data;
using Vueling.Test.Entities;

namespace Vueling.Test.Repository.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly VuelingDbContext _context;
        public TransactionsRepository(VuelingDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TransactionEntity>> read(IList<TransactionEntity> transactions)
        {
            using (_context)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        string strSQL = "TRUNCATE TABLE Transactions";
                        await _context.Database.ExecuteSqlRawAsync(strSQL);
                        foreach (TransactionEntity trans in transactions)
                        {
                            _context.Entry(trans).State = EntityState.Added;
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return await _context.Transactions.ToListAsync();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<IList<TransactionEntity>> read(string sku)
        {
            try
            {
                return await _context.Transactions.Where(t => t.Sku == sku).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
