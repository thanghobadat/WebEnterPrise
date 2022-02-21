using System.Collections.Generic;

namespace Data.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AppUser> AppUser { get; set; }
    }
}
