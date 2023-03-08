using ART_App.Models;
using ART_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ART_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsBRController : ControllerBase
    {
        private readonly IRepositories<AccountsBRModel> _accRepositories;
        private readonly IGetRepository<AccountsBRModel> _getRepositories;

        public AccountsBRController(IRepositories<AccountsBRModel> accRepositories, IGetRepository<AccountsBRModel> getRepositories)
        {
            _accRepositories = accRepositories;
            _getRepositories = getRepositories;
        }

        //get all accountBR's

        [HttpGet("GetAllAccBRs")]
        public async Task<IActionResult> GetAllAccBRs()
        {
            var allBrs = await _getRepositories.GetAll();
            if (allBrs != null)
            {
                return Ok(allBrs);
            }
            else
            {
              return  NotFound();
            }
        }

        //Get AccBR By Id
        [HttpGet]
        [Route("GetAccBRById/{id}", Name = "GetAccBRById")]
        public async Task<IActionResult> GetAccBRById(int id)
        {
            var accBR = await _getRepositories.GetById(id);
            if (accBR != null)
            {
                return Ok(accBR);
            }
            return NotFound();
        }

        //Add AccountBR
        [HttpPost("CreateAccountBR")]
        public async Task<IActionResult> CreateAccountBR([FromBody] AccountsBRModel accountsBRModel)
        {
            if (ModelState.IsValid)
            {
               // accountsBRModel.Status ??= "PENDING";
                await _accRepositories.Create(accountsBRModel);
                return CreatedAtAction("GetAccBRById", new { id = accountsBRModel.Id }, accountsBRModel);
            }
            return BadRequest();

        }

        //update AccBR
        [HttpPut("UpdateAccountBR/{id}")]
        public async Task<IActionResult> UpdateAccBR(int id, [FromBody] AccountsBRModel accountsBRModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accRepositories.Update(id, accountsBRModel);
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return BadRequest();
        }

        //delete AccBR

        [HttpDelete("DeleteAccBR/{id}")]
        public async Task<IActionResult> DeleteAccBR(int id)
        {
            var res = await _accRepositories.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("AccBR with id " + id + " is not available");
        }

    }
}
