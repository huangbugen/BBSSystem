using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BBSSystem.Contract.PointsRuleApp
{
    public interface IPointsRuleService : IApplicationService
    {
        Task SetTotalScoreAndPublishToUserSystemAsync();
    }
}