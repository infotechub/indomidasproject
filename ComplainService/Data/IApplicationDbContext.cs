using Complaintservice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaintservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Complaint> Complaints{ get; set; }

        DbSet<Conversion> ConvertMeasurement { get; set; }
        Task<int> SaveChanges();
    }
}
