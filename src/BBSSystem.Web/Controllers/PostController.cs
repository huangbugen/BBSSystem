using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.PointsRuleApp;
using BBSSystem.Contract.PostApp;
using BBSSystem.Contract.PostApp.Dto;
using BBSSystem.Contract.ReplyApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BBSSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IReplyService _replyService;
        private readonly IPointsRuleService _pointsRuleService;

        public PostController(
            IPostService postService,
            IReplyService replyService,
            IPointsRuleService pointsRuleService
            )
        {
            this._postService = postService;
            this._replyService = replyService;
            this._pointsRuleService = pointsRuleService;
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> AddPostAsync(PostCreateDto createDto)
        {
            var replyCreateDto = createDto.replyCreate;
            createDto.replyCreate = null;
            var postDto = await _postService.AddPostAsync(createDto);
            replyCreateDto.SectionId = postDto.SectionId;
            replyCreateDto.PostId = postDto.Id;
            var isSuccess = await _replyService.AddReplyAsync(replyCreateDto, true);
            await _pointsRuleService.SetTotalScoreAndPublishToUserSystemAsync();
            return isSuccess;
        }

        [HttpGet]
        public async Task<List<PostDto>> GetPostDtosAsync(string sectionId, int pageIndex = 1, int pageSize = 30)
        {
            return await _postService.GetPostDtosAsync(sectionId, pageIndex, pageSize);
        }

        [HttpPut]
        public async Task<bool> ChangePostReviewStateAsync(string id, PostEditReviewStateDto editReviewStateDto)
        {
            await _postService.UpdatePostReviewStateAsync(id, editReviewStateDto);
            return true;
        }

        [HttpGet("PostType")]
        public async Task<List<PostTypeDto>> GetPostTypeDtoAsync(string sectionId)
        {
            return await _postService.GetPostTypeDtoAsync(sectionId);
        }
    }
}