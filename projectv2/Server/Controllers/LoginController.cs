using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectv2.Server.Controllers.Data;
using projectv2.Shared.Models;

namespace projectv2.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<login>> PostAccount(login a)
        {
            _context.Add(a);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<login>>> Get()
        {
            if (_context.login == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _context.login.ToListAsync());
            }
        }
    }
}
