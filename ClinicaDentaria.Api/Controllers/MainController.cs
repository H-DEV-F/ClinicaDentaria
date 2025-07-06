using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClinicaDentaria.Domain.Contracts;
using AdmCondominio.Domain.Notification;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdmCondominio.Domain.Notification.Interfaces;

namespace AdmCondominio.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        private readonly IUser _user;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador, IUser user)
        {
            _notificador = notificador;
            _user = user;

            if (user.IsAuthenticated())
            {
                UsuarioId = user.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (!OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                error = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
                NotificarErro(erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message);
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}