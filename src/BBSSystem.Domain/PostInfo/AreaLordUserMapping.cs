using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    public class AreaLordUserMapping : Entity<string>
    {
        public AreaLordUserMapping(string id) : base(id)
        {

        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AreaId { get; set; }
    }
}