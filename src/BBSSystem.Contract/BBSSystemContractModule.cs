using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace BBSSystem.Contract
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
    )]
    public class BBSSystemContractModule : AbpModule
    {

    }
}