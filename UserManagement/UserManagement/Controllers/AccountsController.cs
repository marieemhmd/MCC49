using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UserManagement.Base;
using UserManagement.Context;
using UserManagement.Models;
using UserManagement.Repository.Data;
using UserManagement.View_Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly IConfiguration _configuration;
        private readonly AccountRepository accountRepository;
        private readonly MyContext myContext;
        
        public AccountsController(AccountRepository accountRepository, MyContext myContext, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
            _configuration = configuration;
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Register method    
        /// </summary>    
        /// <returns></returns> 
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var person = new Person
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Phone = registerVM.Phone,
                BirthDate = registerVM.BirthDate,
                Salary = registerVM.Salary,
                Email = registerVM.Email
            };
            myContext.Persons.Add(person); //simpan ke table
            myContext.SaveChanges();


            var account = new Account
            {
                NIK = person.NIK,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            myContext.Accounts.Add(account);
            myContext.SaveChanges();
                
            var education = new Education
            {
                GPA = registerVM.GPA,
                Degree = registerVM.Degree,
                UniversityId = registerVM.UniversityId
            };
            myContext.Educations.Add(education);
            myContext.SaveChanges();
                    
            var profiling = new Profiling
            {
                NIK = person.NIK,
                EducationId = education.Id
            };
            myContext.Profilings.Add(profiling);
            myContext.SaveChanges();

            var accountRole = new AccountRole
            {
                RoleId = 2,
                AccountId = person.NIK
            };
            myContext.AccountRoles.Add(accountRole);
            myContext.SaveChanges();
     
            return Ok(new { status = HttpStatusCode.OK, message = "Registrasi Berhasil" });
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Userdata method    
        /// </summary>    
        /// <returns></returns>
        [Authorize]
        [HttpGet("UserData")]
        public async Task<ActionResult> GetAllRegister()
        {
            //IEnumerable<RegisterVM> registers = null;
            var registers = (from p in myContext.Persons
                         join a in myContext.Accounts on p.NIK equals a.NIK
                         join pr in myContext.Profilings on p.NIK equals pr.NIK
                         join ed in myContext.Educations on pr.EducationId equals ed.Id
                         join ar in myContext.AccountRoles on pr.NIK equals ar.AccountId
                         join r in myContext.Roles on ar.RoleId equals r.Id
                         select new RegisterVM
                         {
                             NIK = p.NIK,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Phone = p.Phone,
                             BirthDate = p.BirthDate,
                             Salary = p.Salary,
                             Email = p.Email,
                             Password = a.Password,
                             Degree = ed.Degree,
                             GPA = ed.GPA,
                             UniversityId = ed.UniversityId,
                             Role = r.Name
                         }
                             );//.ToList();
            return Ok(await registers.ToListAsync());
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Profile by NIK method    
        /// </summary>    
        /// <returns></returns>
        [Authorize]
        [HttpGet("Profile/{NIK}")]
        public ActionResult GetRegisterByNIK(string NIK)
        {
            var person = myContext.Persons.Find(NIK);
            if(person != null)
            {
                return PersonProfile(NIK);
            }
            else
            {
                return NotFound("NIK Not Registered");
            }
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Login method    
        /// </summary>    
        /// <returns></returns>
        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            var person = myContext.Persons.Where(prsn => prsn.Email == login.Email).FirstOrDefault(); //firstordefault ngambil data nya cuma 1 atau lebih, bukan list
            if(person != null)
            {
                var account = myContext.Accounts.Where(acc => acc.NIK == person.NIK).FirstOrDefault();
                    //myContext.Accounts.Where(acc => acc.Password == login.Password && acc.NIK == person.NIK).FirstOrDefault();
                if (account != null && Hashing.ValidatePassword(login.Password, account.Password))
                {
                    var accRole = myContext.AccountRoles.Where(ar => ar.AccountId == account.NIK).FirstOrDefault();
                    var role = myContext.Roles.Where(r => r.Id == accRole.RoleId).FirstOrDefault();
 
                    //create claims details based on the user information
                    var authClaims = new List<Claim> {
                    //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(ClaimTypes.Role, role.Name),
                    new Claim("Email", login.Email),
                    new Claim("Role", role.Name)
                    //new Claim("FirstName", person.FirstName),
                    //new Claim("LastName", person.LastName),
                    //new Claim("Phone", person.Phone),
                    //new Claim("Email", person.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"], 
                        audience: _configuration["Jwt:Audience"], 
                        authClaims, 
                        expires: DateTime.Now.AddMinutes(10), 
                        signingCredentials: signIn);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                    //return Ok("Login Successful");

                    //return PersonProfile(person.NIK);
                }
                else
                {
                    return NotFound("Wrong Password");
                }
            }
            else
            {
                return NotFound("Email Not Found");
            }
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Change Password method    
        /// </summary>    
        /// <returns></returns>
        [Authorize]
        [HttpPost("UpdatePassword")]
        public ActionResult UpdatePass(UpdatePassVM updatePass)
        {
            var person = myContext.Persons.Where(prsn => prsn.Email == updatePass.Email).FirstOrDefault();
            if(person != null)
            {
                var oldPass = myContext.Accounts.Where(acc => acc.NIK == person.NIK).FirstOrDefault();
                if (oldPass != null && Hashing.ValidatePassword(updatePass.OldPass, oldPass.Password))
                {
                    oldPass.Password = Hashing.HashPassword(updatePass.NewPass);
                    myContext.SaveChanges();
                    return Ok("Password Has Successfully Changed");
                }
                else
                {
                    return NotFound("Password Incorrect");
                }
            }
            else
            {
                return NotFound("Email Not Found");
            }
        }

        // GET api/values    
        /// <summary>    
        /// AccountsController Api Forgot Password method    
        /// </summary>    
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public ActionResult ForgotPass(ForgotPassVM forgotPass)
        {
            Guid newPass = Guid.NewGuid();
            //var newPass = RandomString();
            Person person = myContext.Persons.Where(prsn => prsn.Email == forgotPass.Email).FirstOrDefault();
            if (person != null)
            {
                //Account account = myContext.Accounts.Where(acc => acc.NIK == person.NIK).FirstOrDefault();
                //UpdatePassVM updatePass = new UpdatePassVM
                //{
                //    Email = forgotPass.Email,
                //    OldPass = account.Password,
                //    NewPass = newPass
                //};
                //UpdatePass(updatePass);
                Account acc = myContext.Accounts.Find(person.NIK);
                acc.Password = Hashing.HashPassword(newPass.ToString());
                myContext.Entry(acc).State = EntityState.Modified;
                myContext.SaveChanges();
                

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)//host , port
                {
                    Credentials = new NetworkCredential("saipularipinjuned@gmail.com", "SaipulAripin123"),
                    EnableSsl = true
                };
                client.Send("mariemuhammad28041998@gmail.com", forgotPass.Email, "Reset Password", $"Hello {person.FirstName} {person.LastName}," +
                    $"\n\nYour New Password is {newPass}");
                return Ok("message sent");
            }
            else
            {
                return NotFound("Email Not Found");
            }
        }

        public string RandomString()
        {
            Random random = new Random();
            string[] rdm = new string[10];
            string  abjadNumber = "abcdefghijklmnopqrstuvwxyz1234567890!@$_";
            char[] ch = new char[abjadNumber.Length];

            for (int i=0;i<abjadNumber.Length; i++)
            {
                ch[i] = abjadNumber[i];
            }

            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(0, abjadNumber.Length - 1);
                rdm[i] = Convert.ToString(ch[index]);
            }

            return $"{rdm[0]}{rdm[1]}{rdm[2]}{rdm[3]}{rdm[4]}{rdm[5]}{rdm[6]}{rdm[7]}{rdm[8]}{rdm[9]}";
        }
        
        private ActionResult PersonProfile(string NIK)
        {
            var result = from p in myContext.Persons
                         join a in myContext.Accounts on p.NIK equals a.NIK
                         join pr in myContext.Profilings on p.NIK equals pr.NIK
                         join ed in myContext.Educations on pr.EducationId equals ed.Id
                         join ar in myContext.AccountRoles on pr.NIK equals ar.AccountId
                         join r in myContext.Roles on ar.RoleId equals r.Id
                         where p.NIK == NIK
                         select new RegisterVM
                         {
                             NIK = p.NIK,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Phone = p.Phone,
                             BirthDate = p.BirthDate,
                             Salary = p.Salary,
                             Email = p.Email,
                             Password = a.Password,
                             Degree = ed.Degree,
                             GPA = ed.GPA,
                             UniversityId = ed.UniversityId,
                             Role = r.Name
                             
                         };
            return Ok(result);
        }

        [HttpGet("GetAllFNameSync")]
        public ActionResult ExecuteSync()
        {
            //IEnumerable<Person> persons = new List<Person>();
            //List<PersonVM> personList = new List<PersonVM>();
            //persons = myContext.Persons.ToList();
            //foreach (var item in persons)
            //{
            //    PersonVM personVM = new PersonVM();
            //    personVM.NIK = item.NIK;
            //    personVM.FirstName = item.FirstName;
            //    personList.Add(personVM);
            //}
            var watch = Stopwatch.StartNew();
            var data = GetAllRegister();
            watch.Stop();
            var elapsedMS = watch.ElapsedMilliseconds;
            return Ok(new{data, message = $"Total Execution Time: {elapsedMS}"});
        }

        [HttpGet("GetAllFNameAsync")]
        public async Task<ActionResult> ExecuteAsync()
        {
            //IEnumerable<Person> persons = new List<Person>();
            //List<PersonVM> personList = new List<PersonVM>();
            //persons = myContext.Persons.ToList();
            //foreach (var item in persons)
            //{
            //    PersonVM personVM = new PersonVM();
            //    personVM.NIK = item.NIK;
            //    personVM.FirstName = item.FirstName;
            //    personList.Add(personVM);
            //}
            var watch = Stopwatch.StartNew();
            var data = await Task.Run(() => GetAllRegister());
            watch.Stop();
            var elapsedMS = watch.ElapsedMilliseconds;
            return Ok(new {data, Message = $"Total Execution Time: {elapsedMS}" });
        }
    }
}
