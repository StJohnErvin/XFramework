using System;
using System.Collections.Generic;

namespace HealthEssentials.Domain.DataTransferObjects.XnelSystemsHealthEssentials
{
    public partial class MedicineIntakeEntity
    {
        public MedicineIntakeEntity()
        {
            MedicineIntakes = new HashSet<MedicineIntake>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string Guid { get; set; } = null!;
        public int? SortOrder { get; set; }

        public virtual ICollection<MedicineIntake> MedicineIntakes { get; set; }
    }
}
