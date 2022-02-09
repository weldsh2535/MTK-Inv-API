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
    public class SupplierController : Controller
    {
        private readonly dataContext _context;

        public SupplierController(dataContext context)
        {
            _context = context;
        }

        // GET: Supplier
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Supplier.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Supplier supplier)
        {
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Supplier supplier)
        {
            _context.Update(supplier);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Supplier res = _context.Supplier.SingleOrDefault(X => X.id == id);
            _context.Supplier.Remove(res);
            _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
