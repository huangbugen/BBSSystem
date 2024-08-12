using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSSystem.Contract.ReplyApp.Dto
{
    public class ReplyCreateDto
    {
        public string ReplyContent { get; set; }
        public string UserId { get; set; }
        public string HeadUrl { get; set; }
        public string UserName { get; set; }
        public string SectionId { get; set; }
        public string PostId { get; set; }
        public string IsMasterReply { get; set; } = "F";
        public string IsReview { get; set; } = "F";
    }
}