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
    public class RewardsController : ControllerBase
    {
        private IDataAccess db;

        public RewardsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/Rewards
        [HttpGet]
        public async Task<IEnumerable<Reward>> Get()
        {
            return await db.Rewards.GetAllAsync();
        }

        // GET: api/Rewards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var reward = await db.Rewards.GetItemByIdAsync(id);

            if (reward == null)
            {
                return NotFound();
            }

            return Ok(reward);
        }

        // PUT: api/Rewards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Reward reward)
        {
            if (reward == null)
            {
                return BadRequest();
            }

            if (id != reward.RewardId)
            {
                return BadRequest();
            }

            await db.Rewards.UpdateAsync(reward);

            return Ok(reward);
        }

        // POST: api/Rewards
        [HttpPost]
        public async Task<IActionResult> Post(Reward reward)
        {
            Reward _reward;

            if (reward == null)
            {
                _reward = await db.Rewards.CreateAsync(new Reward { RewardName = "Новая награда" });

                return Ok(_reward);
            }

            _reward = await db.Rewards.CreateAsync(reward);

            return Ok(_reward);
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