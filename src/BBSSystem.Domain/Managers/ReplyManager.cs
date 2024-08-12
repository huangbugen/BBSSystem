using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Domain.PostInfo;
using BBSSystem.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BBSSystem.Domain.Managers
{
    public class ReplyManager : DomainService
    {
        private readonly IRepository<Reply> _replyRepo;
        private readonly IDataFilter _dataFilter;
        private readonly ICurrentClaims _currentClaims;

        public IQueryable<Reply> ReplyQueryable => _replyRepo.GetQueryableAsync().Result;

        public ReplyManager(
            IRepository<Reply> replyRepo,
            IDataFilter dataFilter,
            ICurrentClaims currentClaims
        )
        {
            _replyRepo = replyRepo;
            _dataFilter = dataFilter;
            _currentClaims = currentClaims;
        }

        public async Task<Reply> GetReplyAsync(string replyId, bool isDisableSoftDelete = false)
        {
            Reply? reply = null;
            // 这句话的意思其实是，在获取数据时，不考虑软删除标记
            if (isDisableSoftDelete)
            {
                using (_dataFilter.Disable<ISoftDelete>())
                {
                    reply = await ReplyQueryable.FirstOrDefaultAsync(m => m.Id == replyId);
                }
            }
            else
            {
                reply = await ReplyQueryable.FirstOrDefaultAsync(m => m.Id == replyId);
            }

            return reply!;
        }

        public async Task<Reply> AddReplyAsync(Reply reply, bool isMaster)
        {
            reply.InitReplay(_currentClaims, isMaster);
            return await _replyRepo.InsertAsync(reply);
        }

        public async Task<Reply> UpdateReplyAsync(Reply reply)
        {
            return await _replyRepo.UpdateAsync(reply);
        }

        public async Task<bool> RemoveReplyAsync(string id)
        {
            await _replyRepo.DeleteAsync(m => m.Id == id);
            return true;
        }

        public async Task<bool> HardDeleteReplyAsync(string id)
        {
            await _replyRepo.HardDeleteAsync(m => m.Id == id);
            return true;
        }

        public async Task<int> GetReplyCountByUserId()
        {
            var userId = _currentClaims.UserId;
            var count = await ReplyQueryable.Where(m => m.UserId == userId).CountAsync();
            return count;
        }
    }
}