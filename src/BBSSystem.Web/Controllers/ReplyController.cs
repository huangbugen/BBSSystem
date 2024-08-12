using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.ReplyApp;
using BBSSystem.Contract.ReplyApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BBSSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            this._replyService = replyService;
        }

        // [HttpPost]
        // public async Task<bool> AddReplyAsync(ReplyCreateDto createDto)
        // {
        //     return await _replyService.AddReplyAsync(createDto);
        // }

        [HttpPut]
        public async Task<bool> UpdateReplyContentAsync(string replyId, ReplyUpdateContentDto contentDto)
        {
            return await _replyService.UpdateReplyContentAsync(replyId, contentDto);
        }

        [HttpDelete]
        public async Task<bool> RemoveReplyAsync(string id)
        {
            return await _replyService.RemoveReplyAsync(id);
        }

        [HttpDelete("hard")]
        public async Task<bool> HardDeleteReplyAsync(string id)
        {
            return await _replyService.HardDeleteReplyAsync(id);
        }
    }
}