using ART_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    public class AccountsRepository : IGetRepository<SignUpModel>, IRepositories<SignUpModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(SignUpModel obj)
        {
            if (obj != null)
            {
                _dbContext.SignUpModel.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<SignUpModel> Delete(int id)
        {
            var emp = await _dbContext.SignUpModel.FirstOrDefaultAsync(a => a.Id == id);
            if (emp != null)
            {
                _dbContext.Remove(emp);
                await _dbContext.SaveChangesAsync();
                return emp;
            }
            return null;
        }

        public async Task<IEnumerable<SignUpModel>> GetAll()
        {
            var allEmps = await _dbContext.SignUpModel.ToListAsync();
            return allEmps;
        }

        public async Task<SignUpModel> GetById(int id)
        {
            var emp = await _dbContext.SignUpModel.FirstOrDefaultAsync(h => h.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

        public async Task<SignUpModel> Update(int id, SignUpModel obj)
        {
            var emp = await _dbContext.SignUpModel.FirstOrDefaultAsync(a => a.Id == id);
            if (emp != null)
            {
                emp.Name = obj.Name;
                emp.Email = obj.Email;
                emp.Password = obj.Password;
              


                _dbContext.Update(emp);
                await _dbContext.SaveChangesAsync();

                return emp;
            }
            return null;
        }

      
    }
}
