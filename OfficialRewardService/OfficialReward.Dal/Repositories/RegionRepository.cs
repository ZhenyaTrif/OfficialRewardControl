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
    public class RegionRepository : IRegionRepository
    {
        private readonly rewardControldbContext db;

        public RegionRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Region> CreateAsync(Region item)
        {
            if (item != null)
            {
                db.Regions.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Region> DeleteAsync(int id)
        {
            Region item = await db.Regions.FindAsync(id);

            if (item != null)
            {
                db.Regions.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await db.Regions.ToListAsync();
        }

        public async Task<Region> GetItemByIdAsync(int id)
        {
            return await db.Regions.FindAsync(id);
        }

        public async Task UpdateAsync(Region item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
