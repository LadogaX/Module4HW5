using System.Collections.Generic;

namespace Module4HW5.Entities
{
    public class TitleEntity
    {
        public int TitleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual List<EmployeeEntity> Employees { get; set; } = new ();
    }
}
