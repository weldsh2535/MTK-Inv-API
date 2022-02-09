using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Inv.Models;

namespace MTK_Inv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly dataContext _context;

        public UserRoleController(dataContext context)
        {
            _context = context;
        }

        // GET: UserRole
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.userRole.ToArrayAsync());
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            return Json(await _context.userRole.FindAsync(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserRole user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserRole user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            UserRole res = _context.userRole.SingleOrDefault(X => X.id == id);
            _context.userRole.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
