using Microsoft.AspNetCore.Http;

namespace ViewModel.Catalog
{
    public class IdeaUpdateRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public IFormFile File { get; set; }
    }
}
