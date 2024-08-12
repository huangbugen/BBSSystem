using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Contract.SectionApp.Dto;
using Volo.Abp.Application.Dtos;

namespace BBSSystem.Contract.AreaApp.Dto
{
    public class AreaDto : EntityDto<string>
    {
        public string AreaName { get; set; }
        public int Sort { get; set; }
        public List<AreaLordUserMappingDto> AreaPadLorders { get; set; }

        public List<SectionDto> Sections { get; set; }
    }
}