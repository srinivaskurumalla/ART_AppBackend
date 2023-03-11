using ART_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ART_App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ART_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

     
        public AccountsController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
           
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SignUpModel userDetails)
        {
            if (userDetails == null)
            {

                return BadRequest();
            }




            var userExist = _dbContext.SignUpModel.FirstOrDefault(u => u.Name == userDetails.Name && u.Email == userDetails.Email);
            if (userExist != null )
            {
                return Conflict();
            }

            this.CreatePasswordHash(userDetails.Password, out byte[] passwordSalt, out byte[] passwordHash);
            userDetails.PasswordHash = passwordHash;
            userDetails.PasswordSalt = passwordSalt;
            _dbContext.SignUpModel.Add(userDetails);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            var currentEmployee = _dbContext.SignUpModel.FirstOrDefault(x => x.Email == login.Email);

            if (currentEmployee == null)
            {
                return BadRequest("Invalid Email Address");
            }

            var isValidPassword = VerifyPassword(login.Password, currentEmployee.PasswordSalt, currentEmployee.PasswordHash);

            if (!isValidPassword)
            {
                return BadRequest("Invalid Password");
            }

            var token = GenerateToken(currentEmployee);

            if (token == null)
            {
                return NotFound("Invalid credentials");
            }

            return Ok(token);
        }

        [NonAction]
        public string GenerateToken(SignUpModel empDetails)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var myClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,empDetails.Name),
                new Claim(ClaimTypes.Email, empDetails.Email),
              //  new Claim(ClaimTypes.Role, userDetails.Role)
            };

            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"],
                                             claims: myClaims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [NonAction]
        public void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        [NonAction]
        public bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }


        [HttpGet("GetEmpId/{email}")]
        public async Task<SignUpModel> GetUserId(string email)
        {
            var emp = await _dbContext.SignUpModel.FirstOrDefaultAsync(e => e.Email == email);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

    }
}
