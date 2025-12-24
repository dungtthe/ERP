using ERP.Domain.Enums;
using ERP.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class GoodsIssue : AggregateRoot
    {
        public string Code { get; set; }
        public DateTime IssueDate { get; set; }
        public GoodsIssueType IssueType { get; set; }
        public Guid ReferenceId { get; set; }

        private readonly List<GoodsIssueLine> _goodsIssueLines = new();
        public IReadOnlyCollection<GoodsIssueLine> GoodsIssueLines => _goodsIssueLines;
    }

}
