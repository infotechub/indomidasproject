using Complaintservice.Data;
using Complaintservice.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainService.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ComplaintController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Complaint complaint)
        {
            Complaint complaints = new Complaint();
            {
                complaints.Subject = complaint.Subject;
                complaints.IsDeleted = false;
                complaints.Content = complaint.Content;
                complaints.CreatedOn = DateTime.Now;
                complaints.Username = complaint.Username;
            }

            _context.Complaints.Add(complaint);
            await _context.SaveChanges();
            return Ok(complaint.Id);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var complaint = await _context.Complaints.ToListAsync();
            if (complaint == null) return NotFound();
            return Ok(complaint);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var complaint = await _context.Complaints.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
            if (complaint == null) return NotFound();
            return Ok(complaint);
        }

        //[HttpGet("{username}")]
        //public async Task<IActionResult> GetByUsername(string username)
        //{
        //    var complaint = await _context.Complaints.Where(x => x.Username == username && x.IsDeleted == false).ToListAsync();
        //    if (complaint == null) return NotFound();
        //    return Ok(complaint);
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var complaint = await _context.Complaints.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (complaint == null) return NotFound();
            _context.Complaints.Remove(complaint);
            await _context.SaveChanges();
            return Ok(complaint.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Complaint complaintdata)
        {
            var complaint = _context.Complaints.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();

            if (complaint == null) return NotFound();
            else
            {
                complaint.Subject = complaintdata.Subject;
                complaint.IsDeleted = false;
                complaint.Content = complaintdata.Content;
                complaint.Response = complaintdata.Response;
                complaint.IsCompleted = false;
                complaint.UpdatedOn = DateTime.Now;
                await _context.SaveChanges();
                return Ok(complaint.Id);
            }
        }
    }
}
