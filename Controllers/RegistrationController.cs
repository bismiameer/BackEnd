using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public DataContextClass objDataContextClass { get; set; }
        public RegistrationController(DataContextClass registrationcontext)
        {
            this.objDataContextClass = registrationcontext;
        }
        [HttpPost("insertregistrationdata")]
        public async Task<ActionResult> Registrationfn(Registration rg )
        {
            objDataContextClass.tblregistration.Add(rg);
            await objDataContextClass.SaveChangesAsync();
            return Ok(rg);
        }
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = objDataContextClass.tblregistration.Where(rg => rg.UserName == user.UserName && rg.Password == user.Password).FirstOrDefault();
            System.Console.WriteLine(userAvailable);
            if (userAvailable == null)
            {
                return Ok("Failure");
            }
            return Ok("Success");
        }
        [HttpPost("fileupload")]
        public async Task<ActionResult> uploadfn(Uploads up)
        {
            objDataContextClass.uploads.Add(up);
            await objDataContextClass.SaveChangesAsync();
            return Ok(up);
        }
        [HttpPost("contact")]
        public async Task<ActionResult> contactfn(Complaints cp)
        {
            objDataContextClass.tblcomplaints.Add(cp);
            await objDataContextClass.SaveChangesAsync();
            return Ok(cp);
        }
        //[HttpPost("deletecourse")]
        //public IActionResult deletecourse(Course cu)
        //{
        //objDataContextClass.tblcourse.Remove(cu);
        //objDataContextClass.SaveChanges();
        //  return Ok(cu);
        //}
        [HttpGet("view")]
        public async Task<List<Uploads>> View()
        {
            return objDataContextClass.uploads.ToList();
        }
    }
}
