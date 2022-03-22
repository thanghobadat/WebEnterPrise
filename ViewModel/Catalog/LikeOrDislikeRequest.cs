using System;

namespace ViewModel.Catalog
{
    public class LikeOrDislikeRequest
    {
        public int IdeaId { get; set; }
        public Guid UserId { get; set; }
        public int Number { get; set; }
    }
}
