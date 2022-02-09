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
    public class StoreTransferController : Controller
    {
        private readonly dataContext _context;

        public StoreTransferController(dataContext context)
        {
            _context = context;
        }

        // GET: storeTransfer
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.storeTransfer.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(StoreTransfer storeTransfer)
        {
            _context.Add(storeTransfer);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(StoreTransfer storeTransfer)
        {
            _context.Update(storeTransfer);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            StoreTransfer res = _context.storeTransfer.SingleOrDefault(X => X.id == id);
            _context.storeTransfer.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
