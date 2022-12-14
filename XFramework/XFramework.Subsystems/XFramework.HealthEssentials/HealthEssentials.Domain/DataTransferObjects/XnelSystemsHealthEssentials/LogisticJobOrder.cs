using System;
using System.Collections.Generic;

namespace HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials
{
    public partial class LogisticJobOrder
    {
        public LogisticJobOrder()
        {
            LogisticJobOrderDetails = new HashSet<LogisticJobOrderDetail>();
            LogisticJobOrderLocations = new HashSet<LogisticJobOrderLocation>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public long RiderId { get; set; }
        public string Guid { get; set; } = null!;
        public short Status { get; set; }
        public long ScheduleId { get; set; }

        public virtual LogisticRider Rider { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual ICollection<LogisticJobOrderDetail> LogisticJobOrderDetails { get; set; }
        public virtual ICollection<LogisticJobOrderLocation> LogisticJobOrderLocations { get; set; }
    }
}
