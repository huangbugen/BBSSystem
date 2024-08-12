using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BBSSystem.Contract.AreaApp.Dto
{
    public class AreaLordUserMappingDto : EntityDto<string>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AreaId { get; set; }
    }
}