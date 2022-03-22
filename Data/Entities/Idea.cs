using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Idea
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public int View { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsAnonymously { get; set; }
        public List<IdeaCategory> IdeaCategories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<LikeOrDislike> LikeOrDislikes { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
