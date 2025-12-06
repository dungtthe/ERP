using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Helpers.Paginations
{
    public abstract class BasePaginationParameter
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        private int _page = 1;
        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : (value < 1 ? 10 : value);
        }

        private string _searchTerm = "";
        public string SearchTerm
        {
            get => _searchTerm;
            set => _searchTerm = value?.Trim() ?? "";
        }
    }
}
