using System;

namespace Data.Entities
{
    public class LikeOrDislike
    {
        public int IdeaId { get; set; }
        public Guid UserId { get; set; }
        public bool IsLike { get; set; }
        public bool IsDislike { get; set; }
        public Idea Idea { get; set; }
        public AppUser User { get; set; }
    }
}
