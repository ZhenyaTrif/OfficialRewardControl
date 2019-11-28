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
    public class CommandsController : ControllerBase
    {
        private IDataAccess db;

        public CommandsController(IDataAccess db)
        {
            this.db = db;
        }

        // GET: api/Commands
        [HttpGet]
        public async Task<IEnumerable<Command>> Get()
        {
            return await db.Commands.GetAllAsync();
        }

        // GET: api/Commands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var command = await db.Commands.GetItemByIdAsync(id);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(command);
        }

        // PUT: api/Commands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Command command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            if (id != command.CommandId)
            {
                return BadRequest();
            }

            await db.Commands.UpdateAsync(command);

            return Ok(command);
        }

        // POST: api/Commands
        [HttpPost]
        public async Task<IActionResult> Post(Command command)
        {
            Command _command;

            if (command == null)
            {
                DateTime date = new DateTime().Date;

                _command = await db.Commands.CreateAsync(new Command { CommandDate = date, CommandText = "-" });

                return Ok(_command);
            }

            _command = await db.Commands.CreateAsync(command);

            return Ok(_command);
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