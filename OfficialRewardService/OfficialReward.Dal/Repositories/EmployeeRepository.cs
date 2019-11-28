using Common.Entity;
using Microsoft.EntityFrameworkCore;
using OfficialReward.Dal.Contexts;
using OfficialReward.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialReward.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly rewardControldbContext db;

        public EmployeeRepository(rewardControldbContext db)
        {
            this.db = db;
        }

        public async Task<Employee> CreateAsync(Employee item)
        {
            if (item != null)
            {
                db.Employees.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            Employee item = await db.Employees.FindAsync(id);

            if (item != null)
            {
                db.Employees.Remove(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetItemByIdAsync(int id)
        {
            return await db.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
