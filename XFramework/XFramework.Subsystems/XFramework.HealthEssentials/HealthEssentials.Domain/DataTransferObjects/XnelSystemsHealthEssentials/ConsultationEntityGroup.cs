using System;
using System.Collections.Generic;

namespace HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials
{
    public partial class ConsultationEntityGroup
    {
        public ConsultationEntityGroup()
        {
            ConsultationEntities = new HashSet<ConsultationEntity>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string Guid { get; set; } = null!;

        public virtual ICollection<ConsultationEntity> ConsultationEntities { get; set; }
    }
}
