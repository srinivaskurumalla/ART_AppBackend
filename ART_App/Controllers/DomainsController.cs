using ART_App.Models;
using ART_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ART_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly IRepositories<DomainsModel> _domainRepository;
        private readonly IGetRepository<DomainsModel> _getRepository;

        public DomainsController(IRepositories<DomainsModel> domainRepository, IGetRepository<DomainsModel> getRepository)
        {
            _domainRepository = domainRepository;
            _getRepository = getRepository;
        }
        [HttpGet("GetAllDomains")]
        public async Task<IActionResult> GetAllDomains()
        {
            var allDomains = await _getRepository.GetAll();
            if (allDomains != null)
            {
                return Ok(allDomains);
            }
            return NotFound();
        }
        //Get ProjectBR By Id 
        [HttpGet]
        [Route("GetDomainById/{id}", Name = "GetDomainById")]
        public async Task<IActionResult> GetDomainById(int id)
        {
            var projBR = await _getRepository.GetById(id);
            if (projBR != null)
            {
                return Ok(projBR);
            }
            return NotFound();
        }

        //Add ProjecttBR
        [HttpPost("CreateDomain")]
        public async Task<IActionResult> CreateDomain([FromBody] DomainsModel domainModel)
        {
            if (ModelState.IsValid)
            {
                // projectsBRModel.Status ??= "PENDING";
                await _domainRepository.Create(domainModel);
                return CreatedAtAction("GetDomainById", new { id = domainModel.Id }, domainModel);
            }
            return BadRequest();

        }

        //update ProjectBR
        [HttpPut("UpdateDomain/{id}")]
        public async Task<IActionResult> UpdateDomain(int id, [FromBody] DomainsModel domainsModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _domainRepository.Update(id, domainsModel);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return BadRequest();
        }

        //delete ProjectBR

        [HttpDelete("DeleteDomain/{id}")]
        public async Task<IActionResult> DeleteDomain(int id)
        {
            var res = await _domainRepository.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Domain with id " + id + " is not available");
        }

    }
}
