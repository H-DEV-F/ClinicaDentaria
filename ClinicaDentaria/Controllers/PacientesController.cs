using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Data;
using ClinicaDentaria.Models;

namespace ClinicaDentaria.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ClinicaDentariaContext _context;

        public PacientesController(ClinicaDentariaContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email")] Paciente paciente,
        [Bind("Logradouro, Numero, Bairro, Cidade, Estado, CEP")] Endereco endereco,
        [Bind("Tipo, Telefone")] List<Contato> contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                endereco.PacienteId = paciente.Id;
                _context.Endereco.Add(endereco);
                foreach (var c in contato)
                {
                    c.PacienteId = paciente.Id;
                    _context.Contato.Add(c);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }


        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);
            var endereco = await _context.Endereco
                .FirstOrDefaultAsync(m => m.PacienteId == paciente.Id);
            var contato = _context.Contato.Where(m => m.PacienteId == paciente.Id).ToList();

            paciente.Endereco = endereco;
            paciente.Contato = contato;

            ViewData["Contato"] = contato;

            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email")] Paciente paciente,
        [Bind("Id, Logradouro, Numero, Bairro, Cidade, Estado, CEP")] Endereco endereco,
        [Bind("Id, Tipo, Telefone")] List<Contato> contato)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    endereco.PacienteId = paciente.Id;
                    _context.Update(endereco);
                    foreach (var c in contato) {
                        c.PacienteId = paciente.Id;
                        _context.Update(c);
                        _context.SaveChanges();
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            var endereco = await _context.Endereco.FirstOrDefaultAsync(m => m.PacienteId == id);
            var contato = _context.Contato.Where(m => m.PacienteId == id).ToList();

            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
            }
            if (contato != null)
            {
                foreach (var c in contato)
                {
                    _context.Contato.Remove(c);
                }
            }
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
