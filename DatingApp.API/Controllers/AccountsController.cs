using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DatingApp.API.Database;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DatingApp.API.Services;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountsController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public ActionResult<string> Register([FromBody] RegisterDto registerDto)
        {
            if(!ModelState.IsValid){
                return  BadRequest(ModelState);
            }
            registerDto.Username.ToLower();
            if(_context.Users.Any(u => u.Username == registerDto.Username))
            {
                return BadRequest("Username is existed");
            }
            // hash password
            using var hmac = new HMACSHA512();
            var user = new Users
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,

            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(_tokenService.CreateToken(user));
        }
        [HttpPost("login")]
        public ActionResult<String> Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username.ToLower());
            if(user == null) 
            {
                return Unauthorized("Invalid Username");
            } 
            // hash password
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(var i =0 ; i< computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            var token = _tokenService.CreateToken(user);
            return Ok(token);
            
        }
        
    }
}