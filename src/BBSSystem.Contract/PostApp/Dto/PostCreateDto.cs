using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.ReplyApp.Dto;

namespace BBSSystem.Contract.PostApp.Dto
{
    public class PostCreateDto
    {
        public string PostTitle { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public string PostTypeId { get; set; }
        public ReplyCreateDto replyCreate { get; set; }
    }
}