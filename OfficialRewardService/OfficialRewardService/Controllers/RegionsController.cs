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
    public class RegionsController : ControllerBase
    {
        private IDataAccess db;

        public RegionsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<IEnumerable<Region>> Get()
        {
            return await db.Regions.GetAllAsync();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var region = await db.Regions.GetItemByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/Regions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Region region)
        {
            if (region == null)
            {
                return BadRequest();
            }

            if (id != region.RegionId)
            {
                return BadRequest();
            }

            await db.Regions.UpdateAsync(region);

            return Ok(region);
        }

        // POST: api/Regions
        [HttpPost]
        public async Task<IActionResult> Post(Region region)
        {
            Region _region;

            if (region == null)
            {
                return BadRequest();
            }

            _region = await db.Regions.CreateAsync(region);

            return Ok(_region);
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