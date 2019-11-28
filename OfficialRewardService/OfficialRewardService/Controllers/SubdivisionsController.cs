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
    public class SubdivisionsController : ControllerBase
    {
        private IDataAccess db;

        public SubdivisionsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/Subdivisions
        [HttpGet]
        public async Task<IEnumerable<Subdivision>> Get()
        {
            return await db.Subdivisions.GetAllAsync();
        }

        // GET: api/Subdivisions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var subdivision = await db.Subdivisions.GetItemByIdAsync(id);

            if (subdivision == null)
            {
                return NotFound();
            }

            return Ok(subdivision);
        }

        // PUT: api/Subdivisions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Subdivision subdivision)
        {
            if (subdivision == null)
            {
                return BadRequest();
            }

            if (id != subdivision.SubdivisionId)
            {
                return BadRequest();
            }

            await db.Subdivisions.UpdateAsync(subdivision);

            return Ok(subdivision);
        }

        // POST: api/Subdivisions
        [HttpPost]
        public async Task<IActionResult> Post(Subdivision subdivision)
        {
            Subdivision _subdivision;

            if (subdivision == null)
            {
                return BadRequest();
            }

            _subdivision = await db.Subdivisions.CreateAsync(subdivision);

            return Ok(_subdivision);
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