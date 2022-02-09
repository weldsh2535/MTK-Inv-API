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
    public class LookupCatagoryController : Controller
    {
        private readonly dataContext _context;

        public LookupCatagoryController(dataContext context)
        {
            _context = context;
        }

        // GET: LookupCatagory
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.LookupCatagory.ToArrayAsync());
        }
        [HttpGet("{name}")]
        public JsonResult getLookUpByName(string name)
        {
            Lookup lookup = _context.lookup.SingleOrDefault(x => x.name == name);
            return new JsonResult(lookup);
        }
        [HttpPost]
        public async Task<IActionResult> Post(LookupCatagory lookupCatagory)
        {
            _context.Add(lookupCatagory);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(LookupCatagory lookupCatagory)
        {
            _context.Update(lookupCatagory);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            LookupCatagory res = _context.LookupCatagory.SingleOrDefault(X => X.id == id);
            _context.LookupCatagory.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
