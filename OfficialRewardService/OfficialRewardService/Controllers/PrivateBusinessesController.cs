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
    public class PrivateBusinessesController : ControllerBase
    {
        private IDataAccess db;

        public PrivateBusinessesController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/PrivateBusinesses
        [HttpGet]
        public async Task<IEnumerable<PrivateBusiness>> Get()
        {
            return await db.PrivateBusinesses.GetAllAsync();
        }

        // GET: api/PrivateBusinesses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var privateBusiness = await db.PrivateBusinesses.GetItemByIdAsync(id);

            if (privateBusiness == null)
            {
                return NotFound();
            }

            return Ok(privateBusiness);
        }

        // PUT: api/PrivateBusinesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PrivateBusiness privateBusiness)
        {
            if (privateBusiness == null)
            {
                return BadRequest();
            }

            if (id != privateBusiness.PrivateBusinessId)
            {
                return BadRequest();
            }

            await db.PrivateBusinesses.UpdateAsync(privateBusiness);

            return Ok(privateBusiness);
        }

        // POST: api/PrivateBusinesses
        [HttpPost]
        public async Task<IActionResult> Post(PrivateBusiness privateBusiness)
        {
            PrivateBusiness _privateBusiness;

            if (privateBusiness == null)
            {
                return BadRequest();
            }

            _privateBusiness = await db.PrivateBusinesses.CreateAsync(privateBusiness);

            return Ok(_privateBusiness);
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