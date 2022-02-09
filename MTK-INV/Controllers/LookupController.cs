using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MTK_Inv.Models;
using Newtonsoft.Json;

namespace MTK_Inv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : Controller
    {
        private readonly dataContext _context;
        private readonly IConfiguration _configuration;
        public LookupController(dataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //GET: Lookup
       [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.lookup.ToArrayAsync());
        }
        [HttpGet("{type}")]
        public JsonResult getLookUpByType(int type)
        {
            Lookup lookup = _context.lookup.SingleOrDefault(x => x.type == type);
            return new JsonResult(lookup);
        }
        [HttpGet("{name}")]
        public JsonResult getLookupByName(string name)
        {
            Lookup lookup = _context.lookup.SingleOrDefault(x => x.name == name);
            return new JsonResult(lookup);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Lookup lookup)
        {
            _context.Add(lookup);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Put(Lookup lookup)
        {
            _context.Update(lookup);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.lookup.FindAsync(id);
            Lookup lookup = _context.lookup.SingleOrDefault(X => X.id == id);
            _context.lookup.Remove(lookup);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }

    }
}
