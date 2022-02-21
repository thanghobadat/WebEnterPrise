using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime CreatedAt { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
