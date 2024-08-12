using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace BBSSystem.Domain.Shared.Events.Eto
{
    [EventName("BBS.PostEvent")]
    public class PostEto : EntityEto
    {
        public string Id { get; set; }
        public string IsReview { get; set; } = "F";
    }
}