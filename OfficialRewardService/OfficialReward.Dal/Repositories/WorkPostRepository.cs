using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class WorkPostRepository : IWorkPostRepository
    {
        private readonly rewardControldbContext db;

        public WorkPostRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<WorkPost> CreateAsync(WorkPost item)
        {
            if (item != null)
            {
                db.WorkPosts.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<WorkPost> DeleteAsync(int id)
        {
            WorkPost item = await db.WorkPosts.FindAsync(id);

            if (item != null)
            {
                db.WorkPosts.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<WorkPost>> GetAllAsync()
        {
            return await db.WorkPosts.ToListAsync();
        }

        public async Task<WorkPost> GetItemByIdAsync(int id)
        {
            return await db.WorkPosts.FindAsync(id);
        }

        public async Task UpdateAsync(WorkPost item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
