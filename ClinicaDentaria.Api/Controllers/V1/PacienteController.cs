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
    public class PacienteController : MainController
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController(IPacienteRepository pacienteRepository, INotificador notificador, IUser user) : base(notificador, user)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Paciente> ObterPorId(Guid id)
        {
            return await _pacienteRepository.ObterPorId(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Paciente>> ObterTodos()
        {
            return await _pacienteRepository.ObterTodos();
        }

        [HttpPost]
        public async void Adicionar(PacienteViewModels data)
        {
            await _pacienteRepository.Adicionar((Paciente)data);
        }

        [HttpDelete]
        public async void Remover(PacienteViewModels data)
        {
            await _pacienteRepository.Remover((Paciente)data);
        }
    }
}