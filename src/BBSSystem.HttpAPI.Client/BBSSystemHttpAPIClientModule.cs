using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace BBSSystem.HttpAPI.Client
{
    [DependsOn(
    typeof(AbpHttpClientModule)
    )]
    public class BBSSystemHttpAPIClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BBSSystemContractModule).Assembly,
                "Default"
            );
            base.ConfigureServices(context);
        }
    }
}