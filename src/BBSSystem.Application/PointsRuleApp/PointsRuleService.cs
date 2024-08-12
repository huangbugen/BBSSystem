using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.PointsRuleApp;
using BBSSystem.Domain.Managers;
using BBSSystem.Domain.Shared;
using BBSSystem.Domain.Shared.Events.Eto;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;

namespace BBSSystem.Application.PointsRuleApp
{
    public class PointsRuleService : ApplicationService, IPointsRuleService
    {
        private readonly PostManager _postManager;
        private readonly PointsRuleManager _pointsRuleManager;
        private readonly ReplyManager _replyManager;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly ICurrentClaims _currentClaims;

        public PointsRuleService(PostManager postManager, PointsRuleManager pointsRuleManager, ReplyManager replyManager, IDistributedEventBus distributedEventBus, ICurrentClaims currentClaims)
        {
            _postManager = postManager;
            _pointsRuleManager = pointsRuleManager;
            _replyManager = replyManager;
            _distributedEventBus = distributedEventBus;
            _currentClaims = currentClaims;
        }

        public async Task SetTotalScoreAndPublishToUserSystemAsync()
        {
            var postCount = await _postManager.GetPostCountByUserId();
            var replyCount = await _replyManager.GetReplyCountByUserId();
            var newScore = await _pointsRuleManager.GetNewScoreAsync(postCount, replyCount);
            await _distributedEventBus.PublishAsync(new ReplyAddedEvent
            {
                UserId = _currentClaims.UserId,
                NewScore = newScore
            });
        }
    }
}