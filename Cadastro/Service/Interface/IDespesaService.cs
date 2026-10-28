using Infraestrutura.Shared.Interfaces;
using MeuCaixa.Cadastro.Entities;

namespace MeuCaixa.Cadastro.Service.Interface
{
    public interface IDespesaService
    {
        Task<IResultadoValidacao<DespesaEntity>> IncluirDespesaAsync(DespesaEntity entity);
        Task<IResultadoValidacao<DespesaEntity?>> ConsultarDespesaAsync(int idDespesa);
        Task<IResultadoValidacao<DespesaEntity?>> AlterarDespesaAsync(DespesaEntity entity);
        Task<IResultadoValidacao<List<DespesaEntity>>> ListarDespesaAsync();
        Task<IResultadoValidacao<bool>> DeletarDespesaAsync(int idDespesa);
    }
}
