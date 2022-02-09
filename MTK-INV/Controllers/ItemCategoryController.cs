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
    public class ItemCategoryController : Controller
    {
        private readonly dataContext _context;

        public ItemCategoryController(dataContext context)
        {
            _context = context;
        }

        // GET: Categorie
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.ItemCategory.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(ItemCategory category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(ItemCategory category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ItemCategory category1 = _context.ItemCategory.SingleOrDefault(X => X.id == id);
            _context.ItemCategory.Remove(category1);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
