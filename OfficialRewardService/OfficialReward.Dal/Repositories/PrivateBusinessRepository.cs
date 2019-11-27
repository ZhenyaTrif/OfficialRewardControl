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
    public class PrivateBusinessRepository: IPrivateBusinessRepository
    {
        private readonly rewardControldbContext db;

        public PrivateBusinessRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<PrivateBusiness> CreateAsync(PrivateBusiness item)
        {
            if (item != null)
            {
                db.PrivateBusinesses.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<PrivateBusiness> DeleteAsync(int id)
        {
            PrivateBusiness item = await db.PrivateBusinesses.FindAsync(id);

            if (item != null)
            {
                db.PrivateBusinesses.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<PrivateBusiness>> GetAllAsync()
        {
            return await db.PrivateBusinesses.ToListAsync();
        }

        public async Task<PrivateBusiness> GetItemByIdAsync(int id)
        {
            return await db.PrivateBusinesses.FindAsync(id);
        }

        public async Task UpdateAsync(PrivateBusiness item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
