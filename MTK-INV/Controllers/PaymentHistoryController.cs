using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery.Models;
using MTK_Inv.Models;

namespace MTK_Delivery.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoryController : Controller
    {
        private readonly dataContext _context;

        public PaymentHistoryController(dataContext context)
        {
            _context = context;
        }
        // GET: paymentHistory
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.paymentHistories.ToArrayAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(paymentHistory fun)
        {
            _context.Add(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(paymentHistory fun)
        {
            _context.Update(fun);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            paymentHistory res = _context.paymentHistories.SingleOrDefault(X => X.id == id);
            _context.paymentHistories.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
