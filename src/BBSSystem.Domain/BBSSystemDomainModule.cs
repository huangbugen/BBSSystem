using Volo.Abp.Domain;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace BBSSystem.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class BBSSystemDomainModule : AbpModule
    {

    }
}