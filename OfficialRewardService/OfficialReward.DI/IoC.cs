using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficialReward.Dal.DataAccess;
using OfficialReward.Dal.DataAccess.Interfaces;
using OfficialReward.Dal.Repositories;
using OfficialReward.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficialReward.DI
{
    static public class IoC
    {
        static public void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IBuisenessBookRepository, BuisenessBookRepository>();
            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<IEducationRepository, EducationRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ILastWorkRepository, LastWorkRepository>();
            services.AddTransient<IPrivateBusinessRepository, PrivateBusinessRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<IRewardRepository, RewardRepository>();
            services.AddTransient<ISubdivisionRepository, SubdivisionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWorkPostRepository, WorkPostRepository>();
        }
    }
}
