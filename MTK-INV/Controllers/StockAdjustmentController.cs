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
    public class StockAdjustmentController : Controller
    {
        private readonly dataContext _context;

        public StockAdjustmentController(dataContext context)
        {
            _context = context;
        }

        // GET: StockAdjustment
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.StockAdjustment.OrderByDescending(x => x.date).ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(StockAdjustment stockAdjustment)
        {
            _context.Add(stockAdjustment);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(StockAdjustment stockAdjustment)
        {
            _context.Update(stockAdjustment);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            StockAdjustment res = _context.StockAdjustment.SingleOrDefault(X => X.id == id);
            _context.StockAdjustment.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
