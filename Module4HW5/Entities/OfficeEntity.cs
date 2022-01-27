using System.Collections.Generic;

namespace Module4HW5.Entities
{
    public class OfficeEntity
    {
        public int OfficeId { get; set; }
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual List<EmployeeEntity> Employees { get; set; } = new ();
    }
}
