using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaintservice.Entities
{
    public class Complaint : BaseEntity
    {
        public string Username { get; set; }

        public string Product { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }


        public string Response { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
