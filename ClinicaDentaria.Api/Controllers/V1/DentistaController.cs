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
    public class DentistaController : MainController
    {
        private readonly IDentistaRepository _dentistaRepository;
        public DentistaController(IDentistaRepository dentistaRepository, INotificador notificador, IUser user) : base(notificador, user)
        {
            _dentistaRepository = dentistaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Dentista> ObterPorId(Guid id)
        {
            return await _dentistaRepository.ObterPorId(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Dentista>> ObterTodos()
        {
            return await _dentistaRepository.ObterTodos();
        }

        [HttpPost]
        public async void Adicionar(DentistaViewModels data)
        {
            await _dentistaRepository.Adicionar((Dentista)data);
        }

        [HttpDelete]
        public async void Remover(DentistaViewModels data)
        {
            await _dentistaRepository.Remover((Dentista)data);
        }
    }
}