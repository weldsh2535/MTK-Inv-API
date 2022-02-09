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
    public class VocherController : Controller
    {
        private readonly dataContext _context;

        public VocherController(dataContext context)
        {
            _context = context;
        }

        // GET: Vocher
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Vocher.ToArrayAsync());
        }
        [HttpGet("{id}")]
        public JsonResult getVocherByDateTypId(int id)
        {
            Vocher lookup = _context.Vocher.SingleOrDefault(x => x.id == id);
            return new JsonResult(lookup);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vocher vocher)
        {
          
            _context.Add(vocher);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vocher vocher)
        {
            _context.Update(vocher);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Vocher vocher = _context.Vocher.SingleOrDefault(X => X.id == id);
            _context.Vocher.Remove(vocher);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
