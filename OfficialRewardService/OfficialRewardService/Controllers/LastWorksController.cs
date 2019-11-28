using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficialReward.Dal.DataAccess.Interfaces;

namespace OfficialRewardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastWorksController : ControllerBase
    {
        private IDataAccess db;

        public LastWorksController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/LastWorks
        [HttpGet]
        public async Task<IEnumerable<LastWork>> Get()
        {
            return await db.LastWorks.GetAllAsync();
        }

        // GET: api/LastWorks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var lastWork = await db.LastWorks.GetItemByIdAsync(id);

            if (lastWork == null)
            {
                return NotFound();
            }

            return Ok(lastWork);
        }

        // PUT: api/LastWorks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LastWork lastWork)
        {
            if (lastWork == null)
            {
                return BadRequest();
            }

            if (id != lastWork.LastWorkId)
            {
                return BadRequest();
            }

            await db.LastWorks.UpdateAsync(lastWork);

            return Ok(lastWork);
        }

        // POST: api/LastWorks
        [HttpPost]
        public async Task<IActionResult> Post(LastWork lastWork)
        {
            LastWork _lastWork;

            if (lastWork == null)
            {
                return BadRequest();
            }

            _lastWork = await db.LastWorks.CreateAsync(lastWork);

            return Ok(_lastWork);
        }

        // DELETE: api/AdvertisingCategories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    AdvertisingCategory advertisingCategory = await db.AdvertisingCategories.GetItemByIdAsync(id);

        //    if (advertisingCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    IEnumerable<AdvertisingModel> advertisings = await db.Advertisings.GetByAdvertisingCategoryIdAsync(id);

        //    if ((advertisings.ToList()).Count != 0)
        //    {
        //        foreach (var advertising in advertisings)
        //        {
        //            advertising.AdvertisingCategoryId = 0;
        //            await db.Advertisings.UpdateAsync(advertising);
        //        }
        //    }
        //    await db.AdvertisingCategories.DeleteAsync(advertisingCategory.Id);

        //    return Ok();
        //}
    }
}