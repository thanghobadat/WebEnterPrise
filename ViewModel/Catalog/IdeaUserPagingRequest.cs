using System;
using ViewModel.Common;

namespace ViewModel.Catalog
{
    public class IdeaUserPagingRequest : PagingRequestBase
    {
        public Guid UserId { get; set; }
        public int Number { get; set; }
    }
}
