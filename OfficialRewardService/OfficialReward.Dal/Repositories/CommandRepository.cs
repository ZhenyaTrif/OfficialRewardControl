using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly rewardControldbContext db;

        public CommandRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Command> CreateAsync(Command item)
        {
            if (item != null)
            {
                db.Commands.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Command> DeleteAsync(int id)
        {
            Command item = await db.Commands.FindAsync(id);

            if (item != null)
            {
                db.Commands.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Command>> GetAllAsync()
        {
            return await db.Commands.ToListAsync();
        }

        public async Task<Command> GetItemByIdAsync(int id)
        {
            return await db.Commands.FindAsync(id);
        }

        public async Task UpdateAsync(Command item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
