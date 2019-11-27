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
    public class UserRepository : IUserRepository
    {
        private readonly rewardControldbContext db;

        public UserRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<User> CreateAsync(User item)
        {
            if (item != null)
            {
                db.Users.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<User> DeleteAsync(int id)
        {
            User item = await db.Users.FindAsync(id);

            if (item != null)
            {
                db.Users.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetItemByIdAsync(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
