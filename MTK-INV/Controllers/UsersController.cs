using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery;
using MTK_Inv.Models;

namespace MTK_Inv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public UsersController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        // GET: users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.users.ToArrayAsync());
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Users users)
        {
            var token = jwtAuthenticationManager.Authenticate(users.username, users.password);
            if (token == null)
                return Unauthorized();
            return Json(token);
        }
      
        //[HttpPost]
        //public async Task<IActionResult> Post(Users users)
        //{
        //    if (users.id == 0)
        //    {
        //        _context.Add(users);
        //        await _context.SaveChangesAsync();
        //    }
        //    _context.Add(users);
        //    await _context.SaveChangesAsync();
        //    return new JsonResult("Added Successfully");
        //}

        [HttpPut]
        public async Task<IActionResult> Put(Users users)
        {
            _context.Update(users);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Users users = _context.users.SingleOrDefault(X => X.id == id);
            _context.users.Remove(users);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
