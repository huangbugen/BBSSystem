using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BBSSystem.Application.Contract.SectionApp.Dto;
using BBSSystem.Contract.AreaApp.Dto;
using BBSSystem.Contract.PostApp.Dto;
using BBSSystem.Contract.ReplyApp.Dto;
using BBSSystem.Contract.SectionApp.Dto;
using BBSSystem.Domain.PostInfo;
using BBSSystem.Domain.Shared.Events.Eto;

namespace BBSSystem.Application
{
    public class BBSSystemProfile : Profile
    {
        public BBSSystemProfile()
        {
            CreateMap<Area, AreaDto>();
            CreateMap<AreaLordUserMapping, AreaLordUserMappingDto>();
            CreateMap<Section, SectionDto>();
            CreateMap<SectionLordUserMapping, SectionLordUserMappingDto>();
            CreateMap<ReplyCreateDto, Reply>();
            CreateMap<PostEditReviewStateDto, Post>();
            CreateMap<Post, PostEto>();
            CreateMap<Post, PostDto>();
            CreateMap<PostCreateDto, Post>().ConstructUsing(m => new Post(Guid.NewGuid().ToString("N")));
            CreateMap<ReplyCreateDto, Reply>().ConstructUsing(m => new Reply(Guid.NewGuid().ToString("N")));
            CreateMap<PostType, PostTypeDto>();
            CreateMap<Section, SectionSimpleDto>();
        }
    }
}