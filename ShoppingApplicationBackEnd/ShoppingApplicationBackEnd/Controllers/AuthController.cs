using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingApplicationBackEnd.DTOS;
using ShoppingApplicationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {

           var currentUser = await unitOfWork.AuthRepository.Login(userLogin.UserName, userLogin.Password);
            if(currentUser == null)
            {
                return Unauthorized("UserName or Password is not correct");
            }
            JwtSecurityTokenHandler handler;
            SecurityToken token;
            JwtGenerator(currentUser, out handler,out token);

            return Ok(new { 
                Token = handler.WriteToken(token),
                ExpireDate = token.ValidTo,
                UserID = currentUser.UserID
            });
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(UsersSignUpDTO usersSign)
        {
           var user = mapper.Map<Models.User>(usersSign);
           var signedInUser = await unitOfWork.AuthRepository.SignUp(user, usersSign.Password);
            JwtSecurityTokenHandler handler;
            SecurityToken token;
            JwtGenerator(signedInUser, out handler, out token);
            return Created("", new
            {
                Token = handler.WriteToken(token),
                ExpireDate = token.ValidTo,
                UserID = signedInUser.UserID
            });
        }


        private void JwtGenerator(Models.User user, out JwtSecurityTokenHandler handler, out SecurityToken token)
        {
            var claims = new Claim[]{
                new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Surname , user.Name)
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
            var signIncreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var descrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signIncreds,
                Expires = DateTime.Now.AddDays(2)
            };
            handler = new JwtSecurityTokenHandler();
            token = handler.CreateToken(descrptor);
        }
    }
}
