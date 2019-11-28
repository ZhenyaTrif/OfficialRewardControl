using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class SubdivisionRepository : ISubdivisionRepository
    {
        private readonly rewardControldbContext db;

        public SubdivisionRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Subdivision> CreateAsync(Subdivision item)
        {
            if (item != null)
            {
                db.Subdivisions.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Subdivision> DeleteAsync(int id)
        {
            Subdivision item = await db.Subdivisions.FindAsync(id);

            if (item != null)
            {
                db.Subdivisions.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Subdivision>> GetAllAsync()
        {
            return await db.Subdivisions.ToListAsync();
        }

        public async Task<Subdivision> GetItemByIdAsync(int id)
        {
            return await db.Subdivisions.FindAsync(id);
        }

        public async Task UpdateAsync(Subdivision item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
