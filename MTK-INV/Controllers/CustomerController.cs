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
    public class CustomerController : Controller
    {
        private readonly dataContext _context;

        public CustomerController(dataContext context)
        {
            _context = context;
        }

        // GET: Customer
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Customer.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = _context.Customer.SingleOrDefault(X => X.id == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
