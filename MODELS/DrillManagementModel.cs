using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class DrillManagementModel
    {
        public string? DRILL_TYPE_ID { get; set; }
        public string? DRILL_TYPE_NAME { get; set; }
        public string? DRILL_TYPE_NAME_AR { get; set; }
        public string? STATUS { get; set; }
    }
    public class DRILL_TYPE : M_COMMON_FIELDS
    {
        public string? DRILL_TYPE_ID { get; set; }
        public string? DRILL_TYPE_NAME { get; set; }
        public string? DRILL_TYPE_NAME_AR { get; set; }
        public string? STATUS { get; set; }
    }
}
