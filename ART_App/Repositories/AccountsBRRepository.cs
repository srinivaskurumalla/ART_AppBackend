using ART_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    public class AccountsBRRepository : IRepositories<AccountsBRModel>, IGetRepository<AccountsBRModel>
    {
        private readonly ApplicationDbContext _dbContext;
        public AccountsBRRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(AccountsBRModel obj)
        {
            if (obj != null)
            {
                _dbContext.AccountsBR.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<AccountsBRModel> Delete(int id)
        {
           var accBR = await _dbContext.AccountsBR.FirstOrDefaultAsync(a => a.Id == id);
            if(accBR != null)
            {
                _dbContext.Remove(accBR);
                await _dbContext.SaveChangesAsync();
                return accBR;
            }
            return null;
        }

        //Get All AccountBR's
        public async Task<IEnumerable<AccountsBRModel>> GetAll()
        {
            var accBrs = await _dbContext.AccountsBR.ToListAsync();
            return accBrs;
        }

        public async Task<AccountsBRModel> GetById(int id)
        {
            var accountsBR = await _dbContext.AccountsBR.FirstOrDefaultAsync(h => h.Id == id);
            if (accountsBR != null)
            {
                return accountsBR;
            }
            return null;
        }

        public async Task<AccountsBRModel> Update(int id, AccountsBRModel obj)
        {
            var accBR = await _dbContext.AccountsBR.FirstOrDefaultAsync(a => a.Id == id);
            if(accBR!= null)
            {
                accBR.AccountName = obj.AccountName;

                _dbContext.Update(accBR);
                await _dbContext.SaveChangesAsync();

                return accBR;
            }
            return null;

        }
    }
}
