using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Context;
using API.Controllers.Base;
using API.Handler;
using API.Models;
using API.Repository.Data;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly AccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        //private readonly MyContext myContext;
        public AccountController(AccountRepository accountRepository, EmployeeRepository employeeRepository, IConfiguration configuration) : base(accountRepository)
        {
            _employeeRepository = employeeRepository;
            _accountRepository = accountRepository;
            _configuration = configuration;
            //this.myContext = myContext;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVM login)
        {
            var result = _accountRepository.Login(login);
            if (result != null)
            {
                var jwt = new JwtServices(_configuration);
                var token = jwt.GenerateSecurityToken(result);
                return Ok(new { Message = "You have successfully Sign In", result, Token = token });
            }
            else
            {
                return new OkObjectResult(new { Status = HttpStatusCode.Unauthorized, ErrorMessage = "Unauthorized Access" });
            }
        }

        [HttpPut("ChangePassword/{NIK}")]
        public IActionResult ChangePassword(string NIK, ChangePasswordVM changePasswordVM)
        {
            var account = _accountRepository.Get(NIK);

            if (Hashing.ValidatePassword(changePasswordVM.OldPassword, account.AccountPassword))
            {

                if (account != null)
                {
                    var result = _accountRepository.ChangePassword(NIK, changePasswordVM.NewPassword);
                    if (result != 0)
                    {
                        return Ok(new { message = "Password Changed Successfully", status = "Ok" });
                    }
                    else
                    {
                        return StatusCode(404, new { status = "404", message = "Failed" });
                    }
                }
                return StatusCode(404, new { status = "404", message = "old password not same" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, message = "Internal Server Error" });
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordVM forgot)
        {
            var Email = forgot.Email;
            var Get = _employeeRepository.Get();
            var CheckLogin = Get.FirstOrDefault(x => x.Email == forgot.Email);
            if (CheckLogin != null)
            {
                Guid newPassword = Guid.NewGuid();
                Account account = new Account
                {
                    NIK = CheckLogin.NIK,
                    AccountPassword = newPassword.ToString("N").Substring(0, 6)
                };
                _accountRepository.ChangePassword(CheckLogin.NIK, account.AccountPassword);
                SendEmail.ForgotPassword(Email, account.AccountPassword);

                return Ok(new { status = HttpStatusCode.OK, message = "New Password has been send to your Email" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.OK, message = "Email you entered is wrong" });
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(CreateEmployeeVM create)
        {
            var result = _accountRepository.Register(create);
            if (result > 0)
            {
                return Ok(new { Status = HttpStatusCode.OK, Message = "Registration is successful", result });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.InternalServerError, message = "Internal Server Error" });
            }

        }
    }
}