using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthShield.Domain.Common
{
    public class Auditable
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateUtc { get; set; }
    }
}
