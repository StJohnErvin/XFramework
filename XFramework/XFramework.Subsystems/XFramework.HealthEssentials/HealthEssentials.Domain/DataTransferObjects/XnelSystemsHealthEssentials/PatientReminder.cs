using System;
using System.Collections.Generic;

namespace HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials
{
    public partial class PatientReminder
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public long PatientId { get; set; }
        public long? ConsultationJobOrderId { get; set; }
        public bool IsSeen { get; set; }
        public short Status { get; set; }
        public string Guid { get; set; } = null!;

        public virtual ConsultationJobOrder? ConsultationJobOrder { get; set; }
        public virtual Patient Patient { get; set; } = null!;
    }
}
