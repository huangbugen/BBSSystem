using BBSSystem.Contract.ReplyApp.Dto;
using Volo.Abp.Application.Services;

namespace BBSSystem.Contract.ReplyApp
{
    public interface IReplyService : IApplicationService
    {
        Task<bool> AddReplyAsync(ReplyCreateDto createDto, bool isMaster);
        Task<bool> UpdateReplyReviewStateAsync(string postId, string reviewState);
        Task<bool> UpdateReplyContentAsync(string replyId, ReplyUpdateContentDto contentDto);
        Task<bool> RemoveReplyAsync(string id);
        Task<bool> HardDeleteReplyAsync(string id);
    }
}