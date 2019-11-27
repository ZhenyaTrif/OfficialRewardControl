using OfficialReward.Dal.DataAccess.Interfaces;
using OfficialReward.Dal.Repositories.Interfaces;

namespace OfficialReward.Dal.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IBuisenessBookRepository buisenessBooks, ICommandRepository commands,
            IEducationRepository educations, IEmployeeRepository employees,
            ILastWorkRepository lastWorks, IPrivateBusinessRepository privateBusinesses,
            IRegionRepository regions, IRewardRepository rewards,
            ISubdivisionRepository subdivision, IUserRepository users,
            IWorkPostRepository workPosts)
        {
            BuisenessBooks = buisenessBooks;
            Commands = commands;
            Educations = educations;
            Employees = employees;
            LastWorks = lastWorks;
            PrivateBusinesses = privateBusinesses;
            Regions = regions;
            Rewards = rewards;
            Subdivisions = subdivision;
            Users = users;
            WorkPosts = workPosts;
        }

        public IBuisenessBookRepository BuisenessBooks { get; set; }
        public ICommandRepository Commands { get; set; }
        public IEducationRepository Educations { get; set; }
        public IEmployeeRepository Employees { get; set; }
        public ILastWorkRepository LastWorks { get; set; }
        public IPrivateBusinessRepository PrivateBusinesses { get; set; }
        public IRegionRepository Regions { get; set; }
        public IRewardRepository Rewards { get; set; }
        public ISubdivisionRepository Subdivisions { get; set; }
        public IUserRepository Users { get; set; }
        public IWorkPostRepository WorkPosts { get; set; }
    }
}
