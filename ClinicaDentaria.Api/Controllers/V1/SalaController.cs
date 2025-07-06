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
    public class SalaController : MainController
    {
        private readonly ISalaRepository _salaRepository;
        public SalaController(ISalaRepository salaRepository, INotificador notificador, IUser user) : base(notificador, user)
        {
            _salaRepository = salaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Sala> ObterPorId(Guid id)
        {
            return await _salaRepository.ObterPorId(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Sala>> ObterTodos()
        {
            return await _salaRepository.ObterTodos();
        }

        [HttpPost]
        public async void Adicionar(SalaViewModels data)
        {
            await _salaRepository.Adicionar((Sala)data);
        }

        [HttpDelete]
        public async void Remover(SalaViewModels data)
        {
            await _salaRepository.Remover((Sala)data);
        }
    }
}
