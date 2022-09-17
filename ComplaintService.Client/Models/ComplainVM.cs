using System;

namespace ComplaintService.Client.Models
{
    public class ComplainVM
    {
        public int Id { get; set; }

        public bool? IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public string Product { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Username { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }


        public string Response { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
