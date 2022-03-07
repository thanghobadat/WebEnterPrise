using System.Collections.Generic;

namespace ViewModel.Catalog
{
    public class AddCategoryToIdeaRequest
    {
        public int IdeaId { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
