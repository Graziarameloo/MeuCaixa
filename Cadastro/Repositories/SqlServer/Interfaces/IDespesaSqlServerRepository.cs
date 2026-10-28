using MeuCaixa.Cadastro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeuCaixa.Cadastro.Repositories.SqlServer.Interfaces
{
    public interface IDespesaSqlServerRepository
    {
        Task<DespesaEntity> IncluirDespesaAsync (DespesaEntity entity);
        Task<DespesaEntity?> ConsultarDespesaAsync(int idDespesa);
        Task<DespesaEntity?> AlterarDespesaAsync(DespesaEntity entity);
        Task<List<DespesaEntity>> ListarDespesaAsync();
        Task<bool> DeletarDespesaAsync(int idDespesa);
    }
}
