using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTK_Inv.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Inv.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStoreBalanceController : Controller
    {
        private readonly dataContext _context;

        public ItemStoreBalanceController(dataContext context)
        {
            _context = context;
        }
        //GET:ItemStoreBalance
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.ItemStoreBalance.ToArrayAsync());
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            ItemStoreBalance order = _context.ItemStoreBalance.SingleOrDefault(X => X.id == id);
            return new JsonResult(order);
        }
        [HttpGet("{vocherId, ItemID}")]
        public JsonResult getBalanceByItemId_VoucherId_Vendor_Customer(int vocherId,int itemId)
        {
            ItemStoreBalance order = _context.ItemStoreBalance.SingleOrDefault(x => x.itemId == itemId);
            return new JsonResult(order);
        }
        [HttpGet("{itemId}")]
        public JsonResult getBalanceByItemId(int itemrId)
        {
            ItemStoreBalance order = _context.ItemStoreBalance.SingleOrDefault(x => x.itemId == itemrId);
            return new JsonResult(order);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ItemStoreBalance itemStoreBalance)
        {
            _context.Add(itemStoreBalance);
            await _context.SaveChangesAsync();
            ItemStoreBalance order1 = new ItemStoreBalance();
            int id = order1.id;
            return new JsonResult(id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(ItemStoreBalance order)
        {
            try
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return new JsonResult("Updated Successfully");
            }
            catch
            {
                throw new Exception("An error has occured in this method");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var acc = _context.ItemStoreBalance.FindAsync(id);
            ItemStoreBalance order = _context.ItemStoreBalance.SingleOrDefault(X => X.id == id);
            _context.ItemStoreBalance.Remove(order);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
