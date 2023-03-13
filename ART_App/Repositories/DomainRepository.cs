using ART_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    public class DomainRepository : IRepositories<DomainsModel>, IGetRepository<DomainsModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public DomainRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(DomainsModel obj)
        {
            if (obj != null)
            {
                 obj.Age = (int)(DateTime.Now - obj.ApprovedDate).TotalDays;
                _dbContext.DomainsModel.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<DomainsModel> Delete(int id)
        {
            var domain = await _dbContext.DomainsModel.FirstOrDefaultAsync(a => a.Id == id);
            if (domain != null)
            {
                _dbContext.Remove(domain);
                await _dbContext.SaveChangesAsync();
                return domain;
            }
            return null;
        }

        public async Task<IEnumerable<DomainsModel>> GetAll()
        {
            var allDomains = await _dbContext.DomainsModel.ToListAsync();
            return allDomains;
        }

        public async Task<DomainsModel> GetById(int id)
        {
            var domain = await _dbContext.DomainsModel.FirstOrDefaultAsync(h => h.Id == id);
            if (domain != null)
            {
                return domain;
            }
            return null;
        }

        public  async Task<DomainsModel> Update(int id, DomainsModel obj)
        {
            var domain = await _dbContext.DomainsModel.FirstOrDefaultAsync(a => a.Id == id);
            if (domain != null)
            {
                domain.ProjectName = obj.ProjectName;
               // domain.AccountId = obj.AccountId;
                  domain.SkillSetRequired = obj.SkillSetRequired;
                  domain.JobDescription = obj.JobDescription;
                  domain.Status = obj.Status;
                  domain.Grade= obj.Grade;
                domain.Added_Modified_By = obj.Added_Modified_By;
                domain.ProjectFkId= obj.ProjectFkId;
                domain.Age= obj.Age;
                domain.DomainName= obj.DomainName;
                domain.EmployeeId= obj.EmployeeId;
                domain.No_Of_Positions= obj.No_Of_Positions;
                domain.ApprovedDate= obj.ApprovedDate;



                _dbContext.Update(domain);
                await _dbContext.SaveChangesAsync();

                return domain;
            }
            return null;
        }
    }
}
