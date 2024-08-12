using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    public class PostTypeTemplate : Entity<string>
    {
        public string PostTypeName { get; set; }
    }
}