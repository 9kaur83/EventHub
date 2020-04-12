using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEventApi.ViewModel
{
    public class PaginatedItemViewModel<TEntity>
        where TEntity : class
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public long count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
