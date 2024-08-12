using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.ReplyApp;
using BBSSystem.Contract.ReplyApp.Dto;
using BBSSystem.Domain.Managers;
using BBSSystem.Domain.PostInfo;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Local;

namespace BBSSystem.Application.ReplyApp
{
    public class ReplyService : ApplicationService, IReplyService
    {
        private readonly ILocalEventBus _localEventBus;
        private readonly ReplyManager _replyManager;

        public ReplyService(
            ILocalEventBus localEventBus,
            ReplyManager replyManager
            )
        {
            this._localEventBus = localEventBus;
            this._replyManager = replyManager;
        }

        public async Task<bool> AddReplyAsync(ReplyCreateDto createDto, bool isMaster)
        {
            var reply = ObjectMapper.Map<ReplyCreateDto, Reply>(createDto);
            // 往数据库添加数据
            // ...
            // await _localEventBus.PublishAsync(new PostChangeCountEvent
            // {
            //     PostId = "111",
            //     AddCount = 2
            // }, false);

            await _replyManager.AddReplyAsync(reply, isMaster);
            return true;
        }

        public async Task<bool> UpdateReplyContentAsync(string replyId, ReplyUpdateContentDto contentDto)
        {
            var reply = await _replyManager.GetReplyAsync(replyId);
            reply = ObjectMapper.Map(contentDto, reply);
            await _replyManager.UpdateReplyAsync(reply);
            return true;
        }

        public async Task<bool> UpdateReplyReviewStateAsync(string postId, string reviewState)
        {
            // 直接获取帖子下主回复，再修改其回复状态
            // ...
            return true;
        }

        public async Task<bool> RemoveReplyAsync(string id)
        {
            await _replyManager.RemoveReplyAsync(id);
            return true;
        }

        public async Task<bool> HardDeleteReplyAsync(string id)
        {
            return await _replyManager.HardDeleteReplyAsync(id);
        }
    }
}