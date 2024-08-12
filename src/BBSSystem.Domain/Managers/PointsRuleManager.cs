using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSSystem.Domain.ScoreInfo;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BBSSystem.Domain.Managers
{
    public class PointsRuleManager : DomainService
    {
        public IRepository<PointsRule> PointsRule { get; set; }

        public async Task<int> GetNewScoreAsync(int postCount, int replyCount)
        {
            int totalScore = 0;
            var pointsRules = await PointsRule.GetListAsync();
            foreach (var pointsRule in pointsRules)
            {
                switch (pointsRule.PointItem)
                {
                    case "Post":
                        {
                            totalScore += postCount * pointsRule.Integral;
                            break;
                        }
                    case "Reply":
                        {
                            totalScore += replyCount * pointsRule.Integral;
                            break;
                        }
                }
            }
            return totalScore;
        }
    }
}