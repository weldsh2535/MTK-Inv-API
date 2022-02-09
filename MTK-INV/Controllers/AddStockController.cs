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
    public class AddStockController : Controller
    {
        private readonly dataContext _context;

        public AddStockController(dataContext context)
        {
            _context = context;
        }
        // GET: AddStock
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.AddStock.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddStock fun)
        {
            _context.Add(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(AddStock fun)
        {
            _context.Update(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AddStock res = _context.AddStock.SingleOrDefault(X => X.id == id);
            _context.AddStock.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
