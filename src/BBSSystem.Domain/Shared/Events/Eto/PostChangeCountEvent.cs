using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSSystem.Domain.Shared.Events.Eto
{
    public class PostChangeCountEvent
    {
        public string PostId { get; set; }
        public int AddCount { get; set; }
    }
}