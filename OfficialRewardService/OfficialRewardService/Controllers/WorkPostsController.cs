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
    public class WorkPostsController : ControllerBase
    {
        private IDataAccess db;

        public WorkPostsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/WorkPosts
        [HttpGet]
        public async Task<IEnumerable<WorkPost>> Get()
        {
            return await db.WorkPosts.GetAllAsync();
        }

        // GET: api/WorkPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var workPost = await db.WorkPosts.GetItemByIdAsync(id);

            if (workPost == null)
            {
                return NotFound();
            }

            return Ok(workPost);
        }

        // PUT: api/WorkPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, WorkPost workPost)
        {
            if (workPost == null)
            {
                return BadRequest();
            }

            if (id != workPost.WorkPostId)
            {
                return BadRequest();
            }

            await db.WorkPosts.UpdateAsync(workPost);

            return Ok(workPost);
        }

        // POST: api/WorkPosts
        [HttpPost]
        public async Task<IActionResult> Post(WorkPost workPost)
        {
            WorkPost _workPost;

            if (workPost == null)
            {
                return BadRequest(new WorkPost());
            }

            _workPost = await db.WorkPosts.CreateAsync(workPost);

            return Ok(_workPost);
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