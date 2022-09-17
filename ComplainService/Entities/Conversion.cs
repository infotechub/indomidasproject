using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaintservice.Entities
{
    public class Conversion : BaseEntity
    {
        public string MeasurementType { get; set; }

        public string Metric2imperial { get; set; }

        public string Imperial2Metric { get; set; }

        public string ConvertFrom { get; set; }

        public string ConvertTo { get; set; }

        public int MeasurementValue { get; set; }


    }
}
