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
    public class LineItemController : Controller
    {
        private readonly dataContext _context;

        public LineItemController(dataContext context)
        {
            _context = context;
        }

        // GET: LineItem
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.LineItem.ToArrayAsync());
        }
        [HttpGet("{itemId}")]
        public JsonResult getLineItemByItemId(int itemId)
        {
            LineItem items = _context.LineItem.SingleOrDefault(x => x.itemId == itemId);
            return new JsonResult(items);
        }
        [HttpPost]
        public async Task<IActionResult> Post(LineItem lineItem)
        {
            _context.Add(lineItem);
            await _context.SaveChangesAsync();
            // ViewData["LocationId"] = new SelectList(_context.locations, "id", "id", account.LocationId);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(LineItem lineItem)
        {
            _context.Update(lineItem);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.LineItem.FindAsync(id);
            LineItem account1 = _context.LineItem.SingleOrDefault(X => X.id == id);
            _context.LineItem.Remove(account1);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
