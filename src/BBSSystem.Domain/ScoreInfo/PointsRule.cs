using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.ScoreInfo
{
    public class PointsRule : Entity<int>
    {
        public string PointItem { get; set; }
        public int Integral { get; set; }
    }
}