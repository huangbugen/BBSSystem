using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSSystem.Domain.Shared.Events.Eto
{
    public class ReplyChangeReviewStateEvent
    {
        public string PostId { get; set; }
        public string NewReviewState { get; set; }
    }
}