using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Login(Registration lg)
        {
            var userAvailable = objDataContextClass.tblregistration.Where(u => u.UserName == lg.UserName && u.Password == lg.Password && u.Status == "Confirmed").FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(userAvailable);
            }
            return Ok("Failed");
        }
        [HttpGet("viewuser")]
        public async Task<List<Registration>> ViewUser()
        {
            // return objDataContextClass.tbluser.Where(u => u.Status == "NotConfirmed").ToList();
            return objDataContextClass.tblregistration.OrderByDescending(u => u.Registrationid).Where(u => u.Status == "NotConfirmed").ToList();
        }
        [HttpPost("confirmuser")]
        public async Task<ActionResult> ConfirmUser(Registration cu)
        {
            objDataContextClass.tblregistration.Update(cu);
            await objDataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
        [HttpGet("viewconfirmeduser")]
        public async Task<List<Registration>> ViewConfirmedUser()
        {
            return objDataContextClass.tblregistration.ToList();
        }
        [HttpPost("removeuser")]
        public async Task<ActionResult> RemoveUser(Registration pu)
        {
            objDataContextClass.tblregistration.Update(pu);
            await objDataContextClass.SaveChangesAsync();
            return Ok(pu);
        }
        [HttpGet("ViewCategory")]
        public async Task<List<Category>> Viewcategory()
        {
            //return objDataContextClass.tblproduct.ToList();
            return objDataContextClass.tblcategory.OrderByDescending(x => x.Categoryid).ToList();
        }
        [HttpPost("insertdesc")]
        public async Task<ActionResult> insertdesc(Desc ds)
        {
            objDataContextClass.tbldesc.Add(ds);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ds);
        }
       
        [HttpGet("ViewCategoryByid/{id}")]
        public IActionResult ViewCategoryByid(int id)
        {
            return Ok(objDataContextClass.tblcategory.Find(id));
        }
        [HttpPost("updatecategory")]
        public async Task<ActionResult> UpdateCategory(Category ca)
        {
            objDataContextClass.tblcategory.Update(ca);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ca);
        }

        [HttpPost("deletecategory")]
        public async Task<ActionResult> DeleteCategory(Category ca)
        {
            objDataContextClass.tblcategory.Remove(ca);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ca);
        }
        [HttpGet("getdescdata/{id}")]
        public async Task<ActionResult<Desc>> Getdescdata(int id)
        {

            var data = await objDataContextClass.tbldesc.Where(x => x.Registrationid == id).ToArrayAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("contact")]
        public async Task<ActionResult> contactfn(Complaints cp)
        {
            objDataContextClass.tblcomplaints.Add(cp);
            await objDataContextClass.SaveChangesAsync();
            return Ok(cp);
        }

        [HttpPost("complaintupdate")]
        public IActionResult updatecomplaints(Complaints cm)
        {
            objDataContextClass.tblcomplaints.Update(cm);
            objDataContextClass.SaveChanges();
            return Ok(cm);
        }
        [HttpGet("ViewC")]
        public async Task<List<Complaints>>Viewfn()
        {
            return objDataContextClass.tblcomplaints.ToList();
        }
        [HttpGet("ViewU")]
        public async Task<List<Registration>> viewu()
        {
            return objDataContextClass.tblregistration.ToList();
        }
        [HttpGet("ViewCountry")]
        public async Task<List<Country>> Viewcountry()
        {
            //return objDataContextClass.tblproduct.ToList();
            return objDataContextClass.tblcountry.OrderByDescending(x => x.Countryid).ToList();
        }
        [HttpPost("addcategory")]
        public async Task<ActionResult> categoryfn(Category ct)
        {
            objDataContextClass.tblcategory.Add(ct);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ct);
        }
        [HttpGet("allcomplaints")]
        public IActionResult AllComplaints()
        {
            var result = (from C in objDataContextClass.tblcomplaints
                          join U in objDataContextClass.tblregistration on C.Registrationid equals U.Registrationid
                          where U.Status == "confirmed"
                          select new { C.name, C.email,C.subject,C.message,C.status, C.Complaintid, C.Registrationid }).OrderByDescending(x => x.Complaintid).ToList();
            return Ok(result);
        }
        [HttpGet("getcomplaints")]
        public IActionResult GetComplaints()
        {
            var result = (from C in objDataContextClass.tblcomplaints
                          join U in objDataContextClass.tblregistration on C.Registrationid equals U.Registrationid
                          where C.status == "NotChecked" && U.Status == "confirmed"
                          select new { C.name, C.email, C.subject, C.message, C.status, C.Complaintid, C.Registrationid }).OrderByDescending(x => x.Complaintid).ToList();
            return Ok(result);
        }
        [HttpPost("updatestatuspending")]
        public async Task<ActionResult> UpdateStatusPending(Complaints nc)
        {
            objDataContextClass.tblcomplaints.Update(nc);
            await objDataContextClass.SaveChangesAsync();
            return Ok(nc);

        }
        [HttpGet("getpendingcomplaints")]
        public IActionResult GetPendingComplaints()
        {
            var result = (from C in objDataContextClass.tblcomplaints
                          join U in objDataContextClass.tblregistration on C.Registrationid equals U.Registrationid
                          where C.status == "Pending" && U.Status == "confirmed"
                          select new { C.name, C.email, C.subject, C.message, C.status, C.Complaintid, C.Registrationid }).OrderByDescending(x => x.Complaintid).ToList();
            return Ok(result);
        }
        [HttpPost("updatestatuscompleted")]
        public async Task<ActionResult> UpdateStatusCompleted(Complaints nc)
        {
            objDataContextClass.tblcomplaints.Update(nc);
            await objDataContextClass.SaveChangesAsync();
            return Ok(nc);

        }
        [HttpGet("getstatuscomplaint/{id}")]
        public async Task<ActionResult<Complaints>> GetStatusComplaint(int id)
        {

            var data = await objDataContextClass.tblcomplaints.Where(x => x.Registrationid == id).ToArrayAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("ViewDescByid/{id}")]
        public IActionResult ViewDescByid(int id)
        {
            return Ok(objDataContextClass.tbldesc.Find(id));
        }
        [HttpPost("updatedesc")]
        public async Task<ActionResult> Updatedesc(Desc ca)
        {
            objDataContextClass.tbldesc.Update(ca);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ca);
        }

        [HttpPost("deletedesc")]
        public async Task<ActionResult> Deletedesc(Desc ca)
        {
            objDataContextClass.tbldesc.Remove(ca);
            await objDataContextClass.SaveChangesAsync();
            return Ok(ca);
        }
        [HttpGet("ViewSearchCategory")]
        public async Task<List<Desc>> ViewSearchCategory()
        {
            return objDataContextClass.tbldesc.ToList();
        }
        [HttpGet("ViewCategorySearch")]
        public IActionResult ViewCategorySearch()
        {
            var result = (from C in objDataContextClass.tbldesc
                          join U in objDataContextClass.tblcategory on C.CategoryName equals U.CategoryName
                          select new { C.CategoryName,C.description}).OrderByDescending(x => x.CategoryName).ToList();
            return Ok(result);
        }

    }
}
