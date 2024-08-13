using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNet.JwtBearer;
using Abp.Microservice.Consul;
using BBSSystem.Contract;
using BBSSystem.Domain.PostInfo;
using BBSSystem.Domain.Shared.Events.Eto;
using BBSSystem.EntityFrameworkCore;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Modularity;

namespace BBSSystem.Application
{
    [DependsOn(
        typeof(BBSSystemContractModule),
        typeof(AbpAutoMapperModule),
        typeof(BBSSystemContractModule),
        typeof(BBSSystemEntityFrameworkCoreModule),
        typeof(AbpAspNetJwtBearerModule),
        typeof(AbpMicroserviceConsulModule)
    )]
    public class BBSSystemApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(opt =>
            {
                opt.AddProfile<BBSSystemProfile>();
            });

            Configure<AbpDistributedEntityEventOptions>(opt =>
            {
                opt.AutoEventSelectors.Add<Post>();
                opt.EtoMappings.Add<Post, PostEto>();
            });
            base.ConfigureServices(context);
        }
    }
}