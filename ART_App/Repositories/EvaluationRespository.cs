using ART_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    public class EvaluationRespository : IRepositories<MasterBRModel>, IGetRepository<MasterBRModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public EvaluationRespository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(MasterBRModel obj)
        {
            if (obj != null)
            {
                _dbContext.MasterBR.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<MasterBRModel> Delete(int id)
        {
            var masterBR = await _dbContext.MasterBR.FirstOrDefaultAsync(a => a.Id == id);
            if (masterBR != null)
            {
                _dbContext.Remove(masterBR);
                await _dbContext.SaveChangesAsync();
                return masterBR;
            }
            return null;
        }

        public async Task<IEnumerable<MasterBRModel>> GetAll()
        {
            var allMasterBrs = await _dbContext.MasterBR.ToListAsync();
            return allMasterBrs;
        }

        public async Task<MasterBRModel> GetById(int id)
        {
            var masterBR = await _dbContext.MasterBR.FirstOrDefaultAsync(h => h.Id == id);
            if (masterBR != null)
            {
                return masterBR;
            }
            return null;
        }

        public async Task<MasterBRModel> Update(int id, MasterBRModel obj)
        {
            var masterBR = await _dbContext.MasterBR.FirstOrDefaultAsync(m => m.Id == id);

            if(masterBR != null)
            {
                masterBR.ProjectId = obj.ProjectId;
                masterBR.EmployeeId= obj.EmployeeId;
                masterBR.CandidateName = obj.CandidateName;
                masterBR.Int_Ext = obj.Int_Ext;
                masterBR.Location = obj.Location;
                masterBR.Source = obj.Source;
                masterBR.Grade = obj.Grade;
                masterBR.SkillSetRequired = obj.SkillSetRequired;
                masterBR.JobDescription = obj.JobDescription;
                masterBR.ScreeningDate = obj.ScreeningDate;
                masterBR.ScreeningResult = obj.ScreeningResult;
                masterBR.L1_Eval_Date = obj.L1_Eval_Date;
                masterBR.L1_Eval_Result = obj.L1_Eval_Result;
                masterBR.Client_Eval_Date = obj.Client_Eval_Date;
                masterBR.Client_Eval_Result = obj.Client_Eval_Result;
                masterBR.Manager_Eval_Date = obj.Manager_Eval_Date;
                masterBR.Manager_Eval_Result = obj.Manager_Eval_Result;
                masterBR.Status = obj.Status;
                masterBR.Eval_Comments += obj.Eval_Comments + "\n";
                masterBR.Added_Modified_By = obj.Added_Modified_By;

                _dbContext.Update(masterBR);
                await _dbContext.SaveChangesAsync();

                return masterBR;

            }
            return null;
        }
    }
}
