using Microsoft.Extensions.DependencyInjection;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Models.Skills;
using Slick.Repositories;
using Slick.Repositories.Skills;
using Slick.Services.Contracts;
using Slick.Services.People;
using Slick.Services.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api
{
    public static class StartupExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEntityRepository<SpecialisationLevel>,EntityRepository<SpecialisationLevel>>();
            services.AddTransient<IEntityRepository<Contract>, EntityRepository<Contract>>();
            services.AddTransient<IEntityRepository<Consultant>, EntityRepository<Consultant>>();

        }

        public static void RegisterServices(this IServiceCollection services) {
            services.AddTransient<ISpecialisationLevelService, SpecialisationLevelService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IConsultantsService, ConsultantsService>();
        }
    }
}
