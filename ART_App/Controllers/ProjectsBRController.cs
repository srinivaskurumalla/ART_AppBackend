using ART_App.Models;
using ART_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ART_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsBRController : ControllerBase
    {
        private readonly IRepositories<ProjectsBRModel> _projectRepository;
        private readonly IGetRepository<ProjectsBRModel> _getRepository;
        private readonly ApplicationDbContext _dbContext;

        public ProjectsBRController(IRepositories<ProjectsBRModel> projectRepository, IGetRepository<ProjectsBRModel> getRepository)
        {
            _projectRepository = projectRepository;
            _getRepository = getRepository;
        }

        [HttpGet("GetAllProjectBRs")]
        public async Task<IActionResult> GetAllProjects()
        {
            var allProjects = await _getRepository.GetAll();
            if (allProjects != null)
            {
                return Ok(allProjects);
            }
            return NotFound();
        }
        //Get ProjectBR By Id 
        [HttpGet]
        [Route("GetProjectBRById/{id}", Name = "GetProjectBRById")]
        public async Task<IActionResult> GetProjectBRById(int id)
        {
            var projBR = await _getRepository.GetById(id);
            if (projBR != null)
            {
                return Ok(projBR);
            }   
            return NotFound();
        }

        //Add ProjecttBR
        [HttpPost("CreateProjectBR")]
        public async Task<IActionResult> CreateProjectBR([FromBody] ProjectsBRModel projectsBRModel)
        {
            if (ModelState.IsValid)
            {
               // projectsBRModel.Status ??= "PENDING";
                await _projectRepository.Create(projectsBRModel);
                return CreatedAtAction("GetProjectBRById", new { id = projectsBRModel.Id }, projectsBRModel);
            }
            return BadRequest();

        }

        //update ProjectBR
        [HttpPut("UpdateProjectBR/{id}")]
        public async Task<IActionResult> UpdateProjectBR(int id, [FromBody] ProjectsBRModel projectsBRModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _projectRepository.Update(id, projectsBRModel);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return BadRequest();
        }

        //delete ProjectBR

        [HttpDelete("DeleteProjectBR/{id}")]
        public async Task<IActionResult> DeleteProjectBR(int id)
        {
            var res = await _projectRepository.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("ProjectBR with id " + id + " is not available");
        }


     
    }
}
