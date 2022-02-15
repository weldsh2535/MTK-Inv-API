using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTK_Delivery;
using MTK_Inv.Models;

namespace MTK_Inv.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly dataContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public ItemsController(dataContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;   
            _context = context;
        }
     
        // GET: Items
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Items.OrderByDescending(c => c.id).ToArrayAsync());
        }
        [HttpGet("{id}")]
        public JsonResult getBalanceByItemId(int id)
        {
            Items items = _context.Items.SingleOrDefault(x => x.id == id);
            return new JsonResult(items);
        }
        [HttpGet("{type}")]
        public JsonResult getItemByLookup(string type)
        {
            Items items = _context.Items.SingleOrDefault(x => x.type == type);
            return new JsonResult(items);
        }
        [HttpGet("{id}")]
        public JsonResult getItemByID(int id)
        {
            Items items = _context.Items.SingleOrDefault(x => x.id == id);
            return new JsonResult(items);
        }
        [HttpGet("{storeid}")]
        public JsonResult getItemByStoreID(int storeid)
        {
            Items items = _context.Items.SingleOrDefault(x => x.storeid == storeid);
            return new JsonResult(items);
        }
        [HttpGet("{Quantity, storeid, name, amhricName, price}")]
        public JsonResult getAllItemKEY(int Quantity, int storeid,string name,string amhricName,int price)
        {
            Items items = _context.Items.SingleOrDefault(x => x.Quantity == Quantity && x.storeid ==storeid && x.name == name && x.AmaricName==amhricName && x.price == price);
            return new JsonResult(items);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Items items)
        {
            _context.Add(items);
            await _context.SaveChangesAsync();
            Items item = new Items();
            int id = item.id;
            return new JsonResult(id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Items items)
        {
            _context.Update(items);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Items res = _context.Items.SingleOrDefault(X => X.id == id);
            _context.Items.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
