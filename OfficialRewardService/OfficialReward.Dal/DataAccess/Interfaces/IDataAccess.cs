using OfficialReward.Dal.Repositories.Interfaces;

namespace OfficialReward.Dal.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        IBuisenessBookRepository BuisenessBooks { get; set; }

        ICommandRepository Commands { get; set; }

        IEducationRepository Educations { get; set; }

        IEmployeeRepository Employees { get; set; }

        ILastWorkRepository LastWorks { get; set; }

        IPrivateBusinessRepository PrivateBusinesses { get; set; }

        IRegionRepository Regions { get; set; }

        IRewardRepository Rewards { get; set; }

        ISubdivisionRepository Subdivisions { get; set; }

        IUserRepository Users { get; set; }

        IWorkPostRepository WorkPosts { get; set; }
    }
}
