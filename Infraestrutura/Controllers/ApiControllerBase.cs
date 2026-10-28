using Infraestrutura.Shared.Enums;
using Infraestrutura.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infraestrutura.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult Responder<T>(
            IResultadoValidacao<T> resultado)
        {
            if (!resultado.OcorreuErro)
                return Ok(resultado);

            var status = resultado.TipoErro switch
            {
                TipoErro.DadosInvalidos => 400,
                TipoErro.NaoEncontrado => 404,
                TipoErro.Conflito => 409,
                _ => 500
            };

            return StatusCode(status, new
            {
                resultado.OcorreuErro,
                resultado.MensagemErro,
                resultado.TipoErro
            });
        }
    }
}
