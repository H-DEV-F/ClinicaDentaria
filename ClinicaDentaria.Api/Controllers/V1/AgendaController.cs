using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AdmCondominio.Api.Controllers;
using ClinicaDentaria.Domain.Entities;
using ClinicaDentaria.Domain.Contracts;
using ClinicaDentaria.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AdmCondominio.Domain.Notification.Interfaces;

namespace ClinicaDentaria.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AgendaController : MainController
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaController(IAgendaRepository agendaRepository, INotificador notificador, IUser user) : base(notificador, user)
        {
            _agendaRepository = agendaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Agenda> ObterPorId(Guid id)
        {
            return await _agendaRepository.ObterPorId(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Agenda>> ObterTodos()
        {
            return await _agendaRepository.ObterTodos();
        }

        [HttpPost]
        public async void Adicionar(AgendaViewModels data)
        {
            await _agendaRepository.Adicionar((Agenda)data);
        }

        [HttpDelete]
        public async void Remover(AgendaViewModels data)
        {
            await _agendaRepository.Remover((Agenda)data);
        }
    }
}