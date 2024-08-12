using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace BBSSystem.Domain.PostInfo
{
    public class Area : Entity<string>
    {
        public Area(string id) : base(id)
        {

        }
        public string AreaName { get; set; }
        public int Sort { get; set; }
        public string IsDeleted { get; set; }

        [NotMapped]
        public List<AreaLordUserMapping> AreaPadLords { get; set; }
    }
}