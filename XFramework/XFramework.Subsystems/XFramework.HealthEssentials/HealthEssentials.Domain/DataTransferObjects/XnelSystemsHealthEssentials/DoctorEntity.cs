using System;
using System.Collections.Generic;

namespace HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials
{
    public partial class DoctorEntity
    {
        public DoctorEntity()
        {
            Doctors = new HashSet<Doctor>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Guid { get; set; } = null!;
        public long GroupId { get; set; }
        public int? SortOrder { get; set; }

        public virtual DoctorEntityGroup Group { get; set; } = null!;
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
