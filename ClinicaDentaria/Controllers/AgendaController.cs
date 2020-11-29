using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDentaria.Data;
using ClinicaDentaria.Models;
using System.Globalization;
using System.Security.Cryptography;

namespace ClinicaDentaria.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ClinicaDentariaContext _context;

        public AgendaController(ClinicaDentariaContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index(int? id)
        {
            //return View(await _context.Agenda.ToListAsync());
            ViewData["DentistaId"] = id;
            if (id == null)
            {
                return View(await _context.Agenda.Join(
                    _context.Dentista,
                    agenda => agenda.DentistaId,
                    dentista => dentista.Id,
                    (agenda, dentista) => new InfoAgendamento
                    {
                        AgendaId = agenda.Id,
                        DtDisponivel = agenda.DataDisponivel,
                        NomeDentista = dentista.Nome
                    }
                ).ToListAsync());
            }
            else
            {
                return View(await _context.Agenda.Join(
                    _context.Dentista.Where(m => m.Id == id),
                    agenda => agenda.DentistaId,
                    dentista => dentista.Id,
                    (agenda, dentista) => new InfoAgendamento
                    {
                        AgendaId = agenda.Id,
                        DtDisponivel = agenda.DataDisponivel,
                        NomeDentista = dentista.Nome
                    }
                ).ToListAsync());
            }
        }

        private object where(Agenda arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create(int? id)
        {
            Agenda agenda = new Agenda();
            agenda.DataDisponivel = DateTime.Now;
            var dentista = _context.Dentista.Where(m => m.Id == id).ToList();
            if (id == null)
            {
                ViewData["Dentistas"] = _context.Dentista.ToList();
            }
            else
            {
                ViewData["Dentistas"] = dentista;
            }
            ViewData["Salas"] = _context.Sala.ToList();
            ViewData["Pacientes"] = _context.Paciente.ToList();
            return View(agenda);
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int hora, [Bind("Id,DentistaId,SalaId,DataDisponivel,PacienteId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                if (agenda.PacienteId == null)
                {
                    DateTime data = agenda.DataDisponivel;
                    agenda.DataDisponivel = new DateTime(data.Year, data.Month, data.Day, hora, 0, 0);
                    Agenda nova_agenda = new Agenda { DentistaId = agenda.DentistaId, SalaId = agenda.SalaId, DataDisponivel = agenda.DataDisponivel };
                    _context.Agenda.Add(nova_agenda);
                    //return Json(nova_agenda);
                }
                else
                {
                    //return Json(agenda);
                    _context.Agenda.Add(agenda);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var dentista = _context.Dentista.Where(m => m.Id == id).ToList();


            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            string[] selectDate = agenda.DataDisponivel.ToString().Split(" ");

            ViewData["Dentistas"] = _context.Dentista.ToList();
            ViewData["Salas"] = _context.Sala.ToList();
            ViewData["Pacientes"] = _context.Paciente.ToList();
            ViewData["Data"] = selectDate[0];
            ViewData["Hora"] = selectDate[1];

            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DentistaId,SalaId,DataDisponivel,PacienteId")] Agenda agenda)
        {
            if (id != agenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.Id))
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
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .FirstOrDefaultAsync(m => m.Id == id);

            if (agenda == null)
            {
                return NotFound();
            }

            ViewData["Dentista"] = _context.Dentista.Where(m => m.Id == agenda.DentistaId).ToList()[0].Nome;
            ViewData["Sala"] = _context.Sala.Where(m => m.Id == agenda.SalaId).ToList()[0].Numero;
            if (agenda.PacienteId != null)
            {
                ViewData["Paciente"] = _context.Paciente.Where(m => m.Id == agenda.PacienteId).ToList()[0].Nome;
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.Id == id);
        }

        public IActionResult VerificarDatasDisponiveis(int? id)
        {
            //verificar disponibilidade dos dias
            int DiasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<DateTime> DiasDisponiveis = new List<DateTime>();

            for (int i = 1; i <= DiasDoMes; i++)
            {
                if (i >= DateTime.Now.Day)
                {
                    var list = _context.Agenda.Where(m => m.DentistaId == id).
                    Where(m => m.DataDisponivel.Day == i).
                    Where(m => m.DataDisponivel.Month == DateTime.Now.Month).
                    Where(m => m.DataDisponivel.Year == DateTime.Now.Year).ToList();

                    int time = 0;
                    if (list.Count() > 1)
                    {
                        for (int j = 0; j < list.Count(); j++)
                        {

                            if (j < list.Count() - 1)
                            {
                                TimeSpan ts = list[j + 1].DataDisponivel - list[j].DataDisponivel;
                                if ((int)ts.TotalMinutes > 60)
                                {
                                    time += 60;
                                }
                                else 
                                {
                                    time += (int)ts.TotalMinutes;
                                }
                            }
                            else
                            {
                                TimeSpan ts = list[j].DataDisponivel - list[j - 1].DataDisponivel;
                                if ((int)ts.TotalMinutes > 60)
                                {
                                    time += 60;
                                }
                                else
                                {
                                    time += (int)ts.TotalMinutes;
                                }
                            }
                        }

                        if (time < 540)
                        {
                            DiasDisponiveis.Add(new DateTime(list[0].DataDisponivel.Date.Year, list[0].DataDisponivel.Date.Month, list[0].DataDisponivel.Date.Day));
                        }
                    }
                    else 
                    {
                        DiasDisponiveis.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i));
                    }
                }
            }

            return Json(DiasDisponiveis);
        }

        public IActionResult VerificarHorariosDisponiveis(int? id, DateTime? date)
        {
            if (date == null) date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var list = _context.Agenda.Where(m => m.DentistaId == id).
                Where(m => m.DataDisponivel.Day == 12).//date.Value.Day
                Where(m => m.DataDisponivel.Month == date.Value.Month).
                Where(m => m.DataDisponivel.Year == date.Value.Year).OrderBy(m => m.DataDisponivel.Hour).ToList();
            
            //verificar disponibilidade das horas do dia
            List<int> HorariosDisponiveis = new List<int>();
            List<int> HorariosIndisponivel = new List<int>();

            foreach (var item in list) 
            {
                HorariosIndisponivel.Add(item.DataDisponivel.Hour);
            }

            if (list.Count() > 0)
            {
                for (int j = 9; j <= 18; j++)
                {
                    if (!HorariosIndisponivel.Contains(j))
                    {
                        HorariosDisponiveis.Add(j);
                    }
                }
            }
            else
            {
                for (int i = 9; i <= 18; i++) 
                {
                    HorariosDisponiveis.Add(i);
                }
            }

            return Json(HorariosDisponiveis);
        }
    }
}
