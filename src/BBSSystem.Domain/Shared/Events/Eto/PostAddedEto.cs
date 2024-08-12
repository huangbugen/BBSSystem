using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace BBSSystem.Domain.Shared.Events.Eto
{
    [EventName("BBS.PostAddedEvent")]
    public class PostAddedEto : EntityEto
    {
        public string UserId { get; set; }
        public int NewScore { get; set; }
    }
}