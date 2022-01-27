using System;
using System.Collections.Generic;

namespace Module4HW5.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int OfficeId { get; set; }
        public virtual OfficeEntity Office { get; set; } = null!;

        public int TitleId { get; set; }
        public virtual TitleEntity Title { get; set; } = null!;

        public virtual List<EmployeeProjectEntity> EmployeeProjects { get; set; } = new ();
    }
}
