using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EventBus;

namespace BBSSystem.Domain.Shared.Events.Eto
{
    [EventName("BBS.ReplyAddedEvent")]
    public class ReplyAddedEvent
    {
        public string UserId { get; set; }
        public int NewScore { get; set; }
    }
}