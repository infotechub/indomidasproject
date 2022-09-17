using System;

namespace ComplaintService.Client.Models
{
    public class ConversionVM
    {
   
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        public string DeletedBy { get; set; }

       
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string MeasurementType { get; set; }

        public string Metric2imperial { get; set; }

        public string Imperial2Metric { get; set; }

        public string ConvertFrom { get; set; }

        public string ConvertTo { get; set; }

        public int MeasurementValue { get; set; }

    }
}
