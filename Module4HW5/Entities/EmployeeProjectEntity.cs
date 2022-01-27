using System;

namespace Module4HW5.Entities
{
    public class EmployeeProjectEntity
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartedDate { get; set; }

        public int ProjectId { get; set; }

        public virtual ProjectEntity Projects { get; set; } = null!;

        public int EmployeeId { get; set; }

        public virtual EmployeeEntity Employees { get; set; } = null!;
    }
}
