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
    public class EducationsController : ControllerBase
    {
        private IDataAccess db;

        public EducationsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<IEnumerable<Education>> Get()
        {
            return await db.Educations.GetAllAsync();
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var education = await db.Educations.GetItemByIdAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        // PUT: api/Educations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Education education)
        {
            if (education == null)
            {
                return BadRequest();
            }

            if (id != education.EducationId)
            {
                return BadRequest();
            }

            await db.Educations.UpdateAsync(education);

            return Ok(education);
        }

        // POST: api/Educations
        [HttpPost]
        public async Task<IActionResult> Post(Education education)
        {
            Education _education;

            if (education == null)
            {
                return BadRequest();
            }

            _education = await db.Educations.CreateAsync(education);

            return Ok(_education);
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