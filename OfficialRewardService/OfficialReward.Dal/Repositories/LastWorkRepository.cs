using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class LastWorkRepository : ILastWorkRepository
    {
        private readonly rewardControldbContext db;

        public LastWorkRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<LastWork> CreateAsync(LastWork item)
        {
            if (item != null)
            {
                db.LastWorks.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<LastWork> DeleteAsync(int id)
        {
            LastWork item = await db.LastWorks.FindAsync(id);

            if (item != null)
            {
                db.LastWorks.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<LastWork>> GetAllAsync()
        {
            return await db.LastWorks.ToListAsync();
        }

        public async Task<LastWork> GetItemByIdAsync(int id)
        {
            return await db.LastWorks.FindAsync(id);
        }

        public async Task UpdateAsync(LastWork item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
