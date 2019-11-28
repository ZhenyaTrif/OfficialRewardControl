using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class BuisenessBookRepository : IBuisenessBookRepository
    {
        private readonly rewardControldbContext db;

        public BuisenessBookRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<BuisenessBook> CreateAsync(BuisenessBook item)
        {
            if (item != null)
            {
                db.BuisenessBooks.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<BuisenessBook> DeleteAsync(int id)
        {
            BuisenessBook item = await db.BuisenessBooks.FindAsync(id);

            if (item != null)
            {
                db.BuisenessBooks.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<BuisenessBook>> GetAllAsync()
        {
            return await db.BuisenessBooks.ToListAsync();
        }

        public async Task<BuisenessBook> GetItemByIdAsync(int id)
        {
            return await db.BuisenessBooks.FindAsync(id);
        }

        public async Task UpdateAsync(BuisenessBook item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
