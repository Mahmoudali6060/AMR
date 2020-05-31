using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities
{
    public class DataSource
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
        public List<Filter> Filter { get; set; }
        public string Keyword { get; set; }
    }
}
