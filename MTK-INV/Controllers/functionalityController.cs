using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Inv.Models;

namespace MTK_Inv.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class functionalityController : Controller
    {
        private readonly dataContext _context;

        public functionalityController(dataContext context)
        {
            _context = context;
        }

        // GET: functionality
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.functionality.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(functionality fun)
        {
            _context.Add(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(functionality fun)
        {
            _context.Update(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            functionality res = _context.functionality.SingleOrDefault(X => X.id == id);
            _context.functionality.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
