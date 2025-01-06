using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class AUDIT_TYPE_MASTER : M_COMMON_FIELDS
    {
        public string? AUDIT_TYPE_ID { get; set; }
        public string? AUDIT_TYPE_NAME { get; set; }
        public string? AUDIT_TYPE_IDENTITY { get; set; }
        public string? AUDIT_TYPE_NAME_AR { get; set; }

    }
    public class AUDIT_STANDARD_MASTER : M_COMMON_FIELDS
    {
        public string? STANDARD_ID { get; set; }
        public string? STANDARD_NAME { get; set; }
        public string? STANDARD_IDENTITY { get; set; }
        public string? STANDARD_NAME_AR { get; set; }
    }
}
