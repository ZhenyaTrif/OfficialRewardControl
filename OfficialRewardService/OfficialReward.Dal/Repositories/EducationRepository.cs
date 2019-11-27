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
    public class EducationRepository : IEducationRepository
    {
        private readonly rewardControldbContext db;

        public EducationRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Education> CreateAsync(Education item)
        {
            if (item != null)
            {
                db.Educations.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Education> DeleteAsync(int id)
        {
            Education item = await db.Educations.FindAsync(id);

            if (item != null)
            {
                db.Educations.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await db.Educations.ToListAsync();
        }

        public async Task<Education> GetItemByIdAsync(int id)
        {
            return await db.Educations.FindAsync(id);
        }

        public async Task UpdateAsync(Education item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
