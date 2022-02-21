using System;

namespace Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsAnonymously { get; set; }
        public Idea Idea { get; set; }
        public int IdeaId { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
