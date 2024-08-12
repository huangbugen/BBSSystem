using BBSSystem.Domain.Shared;
using BBSSystem.Domain.Shared.Events.Eto;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    public class Post : AggregateRoot<string>
    {
        public Post(string id) : base(id)
        {

        }

        public string PostTitle { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string SectionId { get; set; }
        public string SectionName { get; set; }
        public string PostTypeId { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastReplyUserId { get; set; }
        public string LastReplyUserName { get; set; }
        public DateTime LastReplyDate { get; set; }
        public long ReplyTimes { get; set; }
        public long BrowseTimes { get; set; }
        public string PostLevelId { get; set; }
        public string TopTypeId { get; set; }
        public string IsClose { get; set; }
        public string CloseUserId { get; set; }

        [Comment("是否已审核（T/F）")]
        public string IsReview { get; set; } = "F";

        public PostType PostType { get; set; }

        public void InitPost(ICurrentClaims claims)
        {
            CreateUserId = claims.UserId;
            CreateUserName = claims.UserName;
            CreateDate = DateTime.Now;
            LastReplyUserId = claims.UserId;
            LastReplyUserName = claims.UserName;
            LastReplyDate = CreateDate;
            BrowseTimes = 0;
            ReplyTimes = 0;
            PostLevelId = "";
            TopTypeId = "";
            IsClose = "F";
            CloseUserId = "";
        }

        public void ChangeReviewState(string changeState = "T")
        {
            IsReview = changeState;

            AddLocalEvent(new ReplyChangeReviewStateEvent
            {
                PostId = Id,
                NewReviewState = "T"
            });

            AddDistributedEvent(new PostAddedEto
            {
                NewScore = 666,
                UserId = "0a95e3c36af44739a9f31c17d0f645b1"
            });
        }
    }
}