using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaintservice.Entities
{
     public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
