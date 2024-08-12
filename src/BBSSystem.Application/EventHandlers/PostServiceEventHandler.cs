using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.ReplyApp;
using BBSSystem.Domain.PostInfo;
using BBSSystem.Domain.Shared.Events.Eto;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace BBSSystem.Application.EventHandlers
{
    public class PostServiceEventHandler :
        ITransientDependency,
        ILocalEventHandler<ReplyChangeReviewStateEvent>,
        ILocalEventHandler<EntityCreatedEventData<Post>>
    {
        private readonly IReplyService _replyService;
        public PostServiceEventHandler(IReplyService replyService)
        {
            _replyService = replyService;
        }

        public async Task HandleEventAsync(ReplyChangeReviewStateEvent eventData)
        {
            await _replyService.UpdateReplyReviewStateAsync(eventData.PostId, eventData.NewReviewState);
        }

        public Task HandleEventAsync(EntityCreatedEventData<Post> eventData)
        {
            throw new NotImplementedException();
        }
    }
}