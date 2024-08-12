using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.PostApp;
using BBSSystem.Contract.PostApp.Dto;
using BBSSystem.Domain.Managers;
using BBSSystem.Domain.PostInfo;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BBSSystem.Application.PostApp
{
    public class PostService : ApplicationService, IPostService
    {
        private readonly IRepository<Post> _postRepo;
        private readonly PostManager _postManager;

        public PostService(
            IRepository<Post> postRepo,
            PostManager postManager
            )
        {
            this._postRepo = postRepo;
            this._postManager = postManager;
        }

        public async Task<List<PostDto>> GetPostDtosAsync(string sectionId, int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            var res = await _postManager.GetPostsBySectionAsync(skip, pageSize, sectionId);
            var dtos = ObjectMapper.Map<List<Post>, List<PostDto>>(res);
            return dtos;
        }

        public async Task<int> UpdatePostReplyCountAsync(string postId, int addCount = 1)
        {
            // 获取当前的Post数据
            // 拿到当前的Post中回复的数量
            // 回复数量+1，再存回数据库
            return addCount++;
        }

        public async Task<bool> UpdatePostReviewStateAsync(string id, PostEditReviewStateDto editReviewStateDto)
        {
            // 先取到当前的帖子
            // ...
            var post = new Post(Guid.NewGuid().ToString("N"));
            // 修改帖子中的审核状态
            post.ChangeReviewState(editReviewStateDto.IsReview);
            // 保存修改过的帖子
            // ...
            await _postRepo.InsertAsync(post);
            return true;
        }

        public async Task<PostDto> AddPostAsync(PostCreateDto createDto)
        {
            var post = ObjectMapper.Map<PostCreateDto, Post>(createDto);
            var res = await _postManager.AddPostAsync(post);
            return ObjectMapper.Map<Post, PostDto>(res);
        }

        public async Task<List<PostTypeDto>> GetPostTypeDtoAsync(string sectionId)
        {
            var list = await _postManager.GetPostTypesAsync(sectionId);
            var dtos = ObjectMapper.Map<List<PostType>, List<PostTypeDto>>(list);
            return dtos;
        }
    }
}