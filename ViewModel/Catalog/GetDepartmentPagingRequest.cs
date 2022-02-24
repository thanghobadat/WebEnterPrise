using ViewModel.Common;

namespace ViewModel.Catalog
{
    public class GetDepartmentPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
