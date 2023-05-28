using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MySql.Models;

namespace MySql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoDbContext _dbContext;

        public PrestamoController(PrestamoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prestamo>> Get()
        {
            var prestamos = _dbContext.Prestamos.Include(p => p.Cliente).Include(p => p.Garantia).ToList();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            var prestamo = _dbContext.Prestamos.Include(p => p.Cliente).Include(p => p.Garantia).FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                return Ok(prestamo);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Prestamo> Post(Prestamo prestamo)
        {
            _dbContext.Prestamos.Add(prestamo);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = prestamo.Id }, prestamo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Prestamo prestamo)
        {
            var existingPrestamo = _dbContext.Prestamos.FirstOrDefault(p => p.Id == id);
            if (existingPrestamo != null)
            {
                existingPrestamo.Cliente = prestamo.Cliente;
                existingPrestamo.Monto = prestamo.Monto;
                existingPrestamo.Plazo = prestamo.Plazo;
                existingPrestamo.TasaInteres = prestamo.TasaInteres;
                _dbContext.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prestamo = _dbContext.Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                _dbContext.Prestamos.Remove(prestamo);
                _dbContext.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
