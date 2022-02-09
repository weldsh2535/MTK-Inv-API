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
    public class ItemLocationController : Controller
    {
        private readonly dataContext _context;

        public ItemLocationController(dataContext context)
        {
            _context = context;
        }

        // GET: ItemLocation
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.ItemLocation.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(ItemLocation itemLocation)
        {
            _context.Add(itemLocation);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(ItemLocation itemLocation)
        {
            _context.Update(itemLocation);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ItemLocation itemLocation = _context.ItemLocation.SingleOrDefault(X => X.id == id);
            _context.ItemLocation.Remove(itemLocation);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
