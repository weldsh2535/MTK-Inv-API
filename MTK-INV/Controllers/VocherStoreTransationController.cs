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
    public class VocherStoreTransationController : Controller
    {
        private readonly dataContext _context;

        public VocherStoreTransationController(dataContext context)
        {
            _context = context;
        }

        // GET: vocherStoreTransation
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.vocherStoreTransation.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(VocherStoreTransation vocherStoreTransation)
        {
            _context.Add(vocherStoreTransation);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(VocherStoreTransation vocherStoreTransation)
        {
            _context.Update(vocherStoreTransation);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            VocherStoreTransation vehicle = _context.vocherStoreTransation.SingleOrDefault(X => X.id == id);
            _context.vocherStoreTransation.Remove(vehicle);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
