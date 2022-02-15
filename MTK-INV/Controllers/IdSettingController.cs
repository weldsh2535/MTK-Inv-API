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
    public class IdSettingController : Controller
    {
        private readonly dataContext _context;

        public IdSettingController(dataContext context)
        {
            _context = context;
        }

        // GET: IdSetting
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.IdSetting.ToArrayAsync());
        }
        [HttpGet("{voucherTypeId}")]
        public JsonResult getIDSetting(int voucherTypeId)
        {
            IdSetting idSetting = _context.IdSetting.SingleOrDefault(x => x.voucherTypeId == voucherTypeId);
            return new JsonResult(idSetting);
        }
        [HttpPost]
        public async Task<IActionResult> Post(IdSetting idSetting)
        {
            _context.Add(idSetting);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Put(IdSetting idSetting)
        {
            _context.Update(idSetting);
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IdSetting res = _context.IdSetting.SingleOrDefault(X => X.id == id);
            _context.IdSetting.Remove(res);
            await _context.SaveChangesAsync();
            return new JsonResult("delete Successfully");
        }
    }
}
