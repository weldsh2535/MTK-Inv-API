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
    public class VendorsController : Controller
    {
        private readonly dataContext _context;

        public VendorsController(dataContext context)
        {
            _context = context;
        }

        // GET: Vehicle
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Vendors.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vendors vendors)
        {
            if (vendors.id == 0)
            {
                _context.Add(vendors);
                await _context.SaveChangesAsync();
            }
            _context.Add(vendors);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vendors vendors)
        {
            _context.Update(vendors);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Vendors vendors = _context.Vendors.SingleOrDefault(X => X.id == id);
            _context.Vendors.Remove(vendors);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
