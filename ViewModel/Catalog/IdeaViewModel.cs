using System;
using System.Collections.Generic;

namespace ViewModel.Catalog
{
    public class IDeaViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public int View { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
        public int UpVote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool IsAnonymously { get; set; }
        public List<string> Categories { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
        public int LikeAmount { get; set; }
        public int DislikeAmount { get; set; }
        public bool IsComment { get; set; }
        public bool IsEdit { get; set; }

    }
}
