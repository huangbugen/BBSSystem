using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BBSSystem.Application.Contract.SectionApp.Dto
{
    public class SectionSimpleDto : EntityDto<string>
    {
        public string SectionTitle { get; set; }
        public string SectionDescription { get; set; }
        public string SectionPlaybill { get; set; }

        public long PostAllCount { get; set; }
        public long PostTodayCount { get; set; }

        public string PostTypeInfo { get; set; }
        public List<string> SectionLords { get; set; }
    }
}