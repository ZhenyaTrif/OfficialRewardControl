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
    public class BuisenessBooksController : ControllerBase
    {
        private IDataAccess db;

        public BuisenessBooksController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/BuisenessBooks
        [HttpGet]
        public async Task<IEnumerable<BuisenessBook>> Get()
        {
            return await db.BuisenessBooks.GetAllAsync();
        }

        // GET: api/BuisenessBooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var buisenessBook = await db.BuisenessBooks.GetItemByIdAsync(id);

            if (buisenessBook == null)
            {
                return NotFound();
            }

            return Ok(buisenessBook);
        }

        // PUT: api/BuisenessBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BuisenessBook buisenessBook)
        {
            if (buisenessBook == null)
            {
                return BadRequest();
            }

            if (id != buisenessBook.BuisenessBookId)
            {
                return BadRequest();
            }

            await db.BuisenessBooks.UpdateAsync(buisenessBook);

            return Ok(buisenessBook);
        }

        // POST: api/BuisenessBooks
        [HttpPost]
        public async Task<IActionResult> Post(BuisenessBook buisenessBook)
        {
            BuisenessBook _buisenessBook;

            if (buisenessBook == null)
            {
                DateTime date = new DateTime().Date;

                _buisenessBook = await db.BuisenessBooks.CreateAsync(new BuisenessBook { CreatingDate = date });

                return Ok(_buisenessBook);
            }

            _buisenessBook = await db.BuisenessBooks.CreateAsync(buisenessBook);

            return Ok(_buisenessBook);
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