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
    public class RegistersController : ControllerBase
    {
        private readonly CarOrderingDBContext _context;

        public RegistersController(CarOrderingDBContext context)
        {
            _context = context;
        }

        // GET: api/Registers
        [Route("api/[controller]")]
        [EnableQuery]
        [HttpGet]
        public IEnumerable<Register> GetRegister()
        {
            return _context.Register;
        }

        // GET: api/Registers/5
        [Route("api/[controller]")]
        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegister([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var register = await _context.Register.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return Ok(register);
        }

        // PUT: api/Registers/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister([FromRoute] int id, [FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != register.Id)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> PostRegister([FromBody] Register register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Register.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegister", new { id = register.Id }, register);
        }

        // DELETE: api/Registers/5
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegister([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Register.Remove(register);
            await _context.SaveChangesAsync();

            return Ok(register);
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.Id == id);
        }

        // POST: api/RegisterUser
        [Route("api/RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterVm registerVm)
        {
            try
            {
                var usernameExist = await _context.Login.AnyAsync(x => x.Username == registerVm.Username);

                if (usernameExist)
                {
                    return NotFound();
                }

                Register registerdetails = new Register()
                {
                    FirstName = registerVm.FirstName,
                    LastName = registerVm.LastName,
                    Contact = registerVm.Contact,
                    Address = registerVm.Address
                };
                _context.Register.Add(registerdetails);

                await _context.SaveChangesAsync();

                Login newUser = new Login()
                {
                    Username = registerVm.Username,
                    Password = registerVm.Password,
                    Register = registerdetails
                };

                _context.Login.Add(newUser);

                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}