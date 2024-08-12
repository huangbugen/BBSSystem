using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.PostApp;
using BBSSystem.Domain.Shared.Events.Eto;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace BBSSystem.Application.EventHandlers
{
    public class ReplayServiceEventHandler :
        ITransientDependency,
        ILocalEventHandler<PostChangeCountEvent>
    {
        private readonly IPostService _postService;
        public ReplayServiceEventHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task HandleEventAsync(PostChangeCountEvent eventData)
        {
            await _postService.UpdatePostReplyCountAsync(eventData.PostId, eventData.AddCount);
        }
    }
}