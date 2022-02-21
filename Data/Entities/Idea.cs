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
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsAnonymously { get; set; }
        public List<IdeaCategory> IdeaCategories { get; set; }
    }
}
