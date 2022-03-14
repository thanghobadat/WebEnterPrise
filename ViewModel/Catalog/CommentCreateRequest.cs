using System;

namespace ViewModel.Catalog
{
    public class CommentCreateRequest
    {
        public string Content { get; set; }
        public bool IsAnonymous { get; set; }
        public int IdeaId { get; set; }
        public Guid UserId { get; set; }
    }
}
