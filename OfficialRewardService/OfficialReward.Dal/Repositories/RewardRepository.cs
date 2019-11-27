using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly rewardControldbContext db;

        public RewardRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Reward> CreateAsync(Reward item)
        {
            if (item != null)
            {
                db.Rewards.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Reward> DeleteAsync(int id)
        {
            Reward item = await db.Rewards.FindAsync(id);

            if (item != null)
            {
                db.Rewards.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Reward>> GetAllAsync()
        {
            return await db.Rewards.ToListAsync();
        }

        public async Task<Reward> GetItemByIdAsync(int id)
        {
            return await db.Rewards.FindAsync(id);
        }

        public async Task UpdateAsync(Reward item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
