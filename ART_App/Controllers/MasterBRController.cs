using ART_App.Models;
using ART_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ART_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterBRController : ControllerBase
    {
   
        private readonly IRepositories<MasterBRModel> _masterRepository;
        private readonly IGetRepository<MasterBRModel> _getRepository;

        public MasterBRController(IRepositories<MasterBRModel> masterRepository, IGetRepository<MasterBRModel> getRepository)
        {
            _masterRepository = masterRepository;
            _getRepository = getRepository;
        }

        [HttpGet("GetAllMasterBRs")]
        public async Task<IActionResult> GetAllMasterBRs()
        {
            var allProjects = await _getRepository.GetAll();
            if (allProjects != null)
            {
                return Ok(allProjects);
            }
            return NotFound();
        }
        //Get MasterBR By Id 
        [HttpGet]
        [Route("GetMasterBRById/{id}", Name = "GetMasterBRById")]
        public async Task<IActionResult> GetMasterBRById(int id)
        {
            var projBR = await _getRepository.GetById(id);
            if (projBR != null)
            {
                return Ok(projBR);
            }
            return NotFound();
        }

        //Add MasterBR
        [HttpPost("CreateMasterBR")]
        public async Task<IActionResult> CreateMasterBR([FromBody] MasterBRModel masterBRModel)
        {
            if (ModelState.IsValid)
            {
                // projectsBRModel.Status ??= "PENDING";
                await _masterRepository.Create(masterBRModel);
                return CreatedAtAction("GetMasterBRById", new { id = masterBRModel.Id }, masterBRModel);
            }
            return BadRequest();

        }

        //update MasterBR
        [HttpPut("UpdateMasterBR/{id}")]
        public async Task<IActionResult> UpdateMasterBR(int id, [FromBody] MasterBRModel masterBRModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _masterRepository.Update(id, masterBRModel);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return BadRequest();
        }

        //delete MasterBR

        [HttpDelete("DeleteMasterBR/{id}")]
        public async Task<IActionResult> DeleteProjectBR(int id)
        {
            var res = await _masterRepository.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("MasterBR with id " + id + " is not available");
        }

    }
}

