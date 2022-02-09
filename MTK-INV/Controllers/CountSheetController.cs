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
    public class CountSheetController : Controller
    {
        private readonly dataContext _context;

        public CountSheetController(dataContext context)
        {
            _context = context;
        }

        // GET: CountSheet
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.CountSheet.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CountSheet countSheet)
        {
            _context.Add(countSheet);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(CountSheet countSheet)
        {
            _context.Update(countSheet);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CountSheet countSheet = _context.CountSheet.SingleOrDefault(X => X.id == id);
            _context.CountSheet.Remove(countSheet);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
