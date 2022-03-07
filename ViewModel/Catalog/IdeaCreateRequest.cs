using Microsoft.AspNetCore.Http;
using System;

namespace ViewModel.Catalog
{
    public class IdeaCreateRequest
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public bool IsAnonymously { get; set; }
        public IFormFile File { get; set; }
    }
}
