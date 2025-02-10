using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyLearnerAPIController : ControllerBase
    {
        private readonly SchoolContext _context;
        public MyLearnerAPIController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Learner>>> GetLearners()
        {
            if(_context.Learners == null)
            {
                return NotFound();
            }
            return await _context.Learners.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Learner>> GetLearner(int id)
        {
            if (_context.Learners == null)
            {
                return NotFound();
            }
            var learner = await _context.Learners.FindAsync(id);

            if (learner == null)
            {
                return NotFound();
            }

            return learner;
        }
    }
}
