using ART_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    public class ProjectsBRRepository : IRepositories<ProjectsBRModel>, IGetRepository<ProjectsBRModel>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectsBRRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ProjectsBRModel obj)
        {
            if (obj != null)
            {
                TimeSpan? timeDiff = DateTime.Now - obj.ApproveDate;
                if (timeDiff != null)
                {
                    obj.Age = (int)timeDiff.Value.TotalDays;
                }
                int total = _dbContext.DomainsModel.Where(d => d.ProjectFkId == obj.Id).Where(d => d.No_Of_Positions >= 0).Sum(d => d.No_Of_Positions);
                obj.Total_Positions = total;

               // obj.Age = (int)(DateTime.Now - obj.ApproveDate).to

                _dbContext.ProjectsBR.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ProjectsBRModel> Delete(int id)
        {
            var projectBR = await _dbContext.ProjectsBR.FirstOrDefaultAsync(a => a.Id == id);
            if (projectBR != null)
            {
                _dbContext.Remove(projectBR);
                await _dbContext.SaveChangesAsync();
                return projectBR;
            }
            return null;
        }

        public async Task<IEnumerable<ProjectsBRModel>> GetAll()
        {

            var allProjects = await _dbContext.ProjectsBR.Include(a => a.AccountsBRModel).ToListAsync();

            return allProjects;
        }

        public async Task<ProjectsBRModel> GetById(int id)
        {
            var projectBR = await _dbContext.ProjectsBR.FirstOrDefaultAsync(h => h.Id == id);
            if (projectBR != null)
            {
                return projectBR;
            }
            return null;
        }

        public async Task<ProjectsBRModel> Update(int id, ProjectsBRModel obj)
        {
            var projectBR = await _dbContext.ProjectsBR.FirstOrDefaultAsync(a => a.Id == id);
            if (projectBR != null)
            {
                projectBR.ProjectName = obj.ProjectName;
                projectBR.AccountId = obj.AccountId;
              /*  projectBR.SkillSetRequired = obj.SkillSetRequired;
                projectBR.JobDescription = obj.JobDescription;
                projectBR.Status = obj.Status;
                projectBR.Grade= obj.Grade;*/
                projectBR.Added_Modified_By= obj.Added_Modified_By;
                projectBR.ApproveDate= obj.ApproveDate;
                TimeSpan? timeDiff = DateTime.Now - obj.ApproveDate;
                if (timeDiff != null)
                {
                    projectBR.Age = (int)timeDiff.Value.TotalDays;
                }
                projectBR.Age = (int)timeDiff.Value.TotalDays;
                _dbContext.Update(projectBR);
                await _dbContext.SaveChangesAsync();

                return projectBR;
            }
            return null;
        }

      
        public void UpdateProjectBr(ProjectsBRModel obj)
        {
            int total = _dbContext.DomainsModel.Where(d => d.ProjectFkId == obj.Id).Where(d => d.No_Of_Positions >= 0).Sum(d => d.No_Of_Positions);
            ProjectsBRModel projects = new();
            projects.Total_Positions = total;

        }
    }
}
