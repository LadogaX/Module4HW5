using System;
using System.Collections.Generic;
using Module4HW5.Entities;

namespace Module4HW5.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }

        public virtual List<EmployeeProjectEntity> EmployeeProjects { get; set; } = new ();
        public int ClientId { get; set; }
        public virtual ClientEntity Client { get; set; } = null!;
    }
}
