using Infraestrutura.Controllers;
using MeuCaixa.Cadastro.Entities;
using MeuCaixa.Cadastro.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MeuCaixa.Cadastro.Api.Controllers
{
    [ApiController]
    [Route("api/despesa")]
    public class DespesaController : ApiControllerBase
    {
        private readonly IDespesaService despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            this.despesaService = despesaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var despesas = await despesaService.ListarDespesaAsync();

            return Responder(despesas);
        }

        [HttpGet("{idDespesa}")]
        public async Task<IActionResult> ConsultarAsync(int idDespesa)
        {
            var despesas = await despesaService.ConsultarDespesaAsync(idDespesa);

            return Responder(despesas);
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync(DespesaEntity despesaEntity)
        {
            var despesas = await despesaService.IncluirDespesaAsync(despesaEntity);

            return Responder(despesas);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarAsync(DespesaEntity despesaEntity)
        {
            var despesas = await despesaService.AlterarDespesaAsync(despesaEntity);

            return Responder(despesas);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int idDespesa)
        {
            var despesas = await despesaService.DeletarDespesaAsync(idDespesa);

            return Responder(despesas);
        }

    }
}
