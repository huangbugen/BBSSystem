using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    public class Reply : Entity<string>, IHasCreationTime, IHasModificationTime, IHasDeletionTime
    {
        public Reply(string id) : base(id)
        {

        }
        public string ReplyContent { get; set; }
        public string UserId { get; set; }
        public string HeadUrl { get; set; }
        public string UserName { get; set; }
        public string SectionId { get; set; }
        public DateTime CreationTime { get; set; }

        public string IsClose { get; set; }

        public string? CloseUserId { get; set; }


        public string PostId { get; set; }

        [Comment("是否是帖子内容（T/F）")]
        public string IsMasterReply { get; set; } = "F";

        [Comment("是否已审核（T/F）")]
        public string IsReview { get; set; } = "F";

        public DateTime? LastModificationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        public void InitReplay(ICurrentClaims currentClaims, bool isMaster)
        {
            SetIsMasterValue(isMaster);
            UserId = currentClaims.UserId;
            UserName = currentClaims.UserName;
            HeadUrl = currentClaims.HeadUrl;
            this.IsClose = "F";
            CreationTime = DateTime.Now;
        }

        public void SetIsMasterValue(bool isMaster)
        {
            if (isMaster)
                IsMasterReply = "T";
            else
                IsMasterReply = "F";
        }
    }
}