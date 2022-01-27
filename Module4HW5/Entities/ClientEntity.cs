using System.Collections.Generic;
using Module4HW5.Entities;

namespace Module4HW5.Entities
{
    public class ClientEntity
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
#nullable enable
        public string? Adress { get; set; }
        public virtual List<ProjectEntity> Projects { get; set; } = new ();
    }
}
