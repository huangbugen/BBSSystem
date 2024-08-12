using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    [Comment("子版块")]
    public class Section : Entity<string>
    {
        public Section(string id) : base(id)
        {

        }
        public string AreaId { get; set; }
        public string AreaName { get; set; }

        public string SectionTitle { get; set; }

        public string SectionIcon { get; set; }
        public string SectionDescription { get; set; }

        [Comment("板块海报")]
        public string SectionPlaybill { get; set; }

        public int Sort { get; set; }

        public DateTime CreateTime { get; set; }

        public long PostAllCount { get; set; }
        public long PostTodayCount { get; set; }

        [Comment("当前板块中包含的所有发帖类型和数量")]
        /// <summary>
        /// 当前板块中包含的所有发帖类型和数量，存序列化数据
        /// </summary>
        /// <value></value>
        public string PostTypeInfo { get; set; }

        // T F
        public string IsDeleted { get; set; }

        public List<SectionLordUserMapping> SectionLords { get; set; }
    }
}