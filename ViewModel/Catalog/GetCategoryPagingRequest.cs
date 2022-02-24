using ViewModel.Common;

namespace ViewModel.Catalog
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

    }
}
