using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarOrderingWebApi.Models;
using Microsoft.AspNet.OData;
using CarOrderingWebApi.ViewModels;

namespace CarOrderingWebApi.Controllers
{
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly CarOrderingDBContext _context;

        public LoginsController(CarOrderingDBContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [EnableQuery]
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<Login> GetLogin()
        {
            return _context.Login;
        }

        // GET: api/Logins/5
        [EnableQuery]
        [Route("api/[controller]")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins/5
        [EnableQuery]
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin([FromRoute] int id, [FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Logins
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5  
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }

        // POST: api/CheckLogin
        [Route("api/CheckLogin")]
        [HttpPost]
        public async Task<IActionResult> CheckLogin([FromBody] LoginRequestVM loginrequest)
        {
            try
            {
                var authenticatedUserDetails = await _context.Login.Include(x => x.Register).Where(x => x.Username == loginrequest.Username && x.Password == loginrequest.Password).ToListAsync();
                //await _context.SaveChangesAsync();
                if (!authenticatedUserDetails.Any())
                {
                    return NotFound();
                }

                var userDetails = authenticatedUserDetails.FirstOrDefault();

                var response = new LoginResponseVM()
                {
                    UserId = userDetails.Register.Id,
                    Name = userDetails.Register.FirstName
                };

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}