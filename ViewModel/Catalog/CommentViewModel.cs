using System;

namespace ViewModel.Catalog
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsAnonymously { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
