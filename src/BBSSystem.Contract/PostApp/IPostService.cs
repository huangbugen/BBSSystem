using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.PostApp.Dto;
using Volo.Abp.Application.Services;

namespace BBSSystem.Contract.PostApp
{
    public interface IPostService : IApplicationService
    {
        Task<List<PostDto>> GetPostDtosAsync(string sectionId, int pageIndex, int pageSize);
        Task<int> UpdatePostReplyCountAsync(string postId, int addCount = 1);
        Task<bool> UpdatePostReviewStateAsync(string id, PostEditReviewStateDto editReviewStateDto);
        Task<PostDto> AddPostAsync(PostCreateDto createDto);
        Task<List<PostTypeDto>> GetPostTypeDtoAsync(string sectionId);
    }
}