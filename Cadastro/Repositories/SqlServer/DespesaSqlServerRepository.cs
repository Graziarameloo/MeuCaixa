using MeuCaixa.Cadastro.DataBase;
using MeuCaixa.Cadastro.Entities;
using MeuCaixa.Cadastro.Repositories.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeuCaixa.Cadastro.Repositories.SqlServer
{
    public class DespesaSqlServerRepository : IDespesaSqlServerRepository
    {
        private readonly CadastroDbContext cadastroDbContext;

        public DespesaSqlServerRepository(CadastroDbContext context)
        {
            cadastroDbContext = context;
        }

        public async Task<DespesaEntity?> AlterarDespesaAsync(DespesaEntity despesa)
        {
            var alterarDespesa =  await cadastroDbContext.Despesas.FindAsync(despesa.IdDespesa);

            if (alterarDespesa == null)
                return null;

            alterarDespesa.Descricao = despesa.Descricao;
            alterarDespesa.Valor = despesa.Valor;
            alterarDespesa.DataVencimento = despesa.DataVencimento;
            alterarDespesa.Pago = despesa.Pago;
            alterarDespesa.Observacao = despesa.Observacao;
            
            
            await cadastroDbContext.SaveChangesAsync();

            return alterarDespesa;
        }

        public async Task<DespesaEntity?> ConsultarDespesaAsync(int idDespesa)
        {
           return await cadastroDbContext.Despesas.FindAsync(idDespesa);
        }

        public async Task<bool> DeletarDespesaAsync(int idDespesa)
        {
            var excluirDespesa = await cadastroDbContext.Despesas.FindAsync(idDespesa);

            if (excluirDespesa == null)
                return false;

            cadastroDbContext.Despesas.Remove(excluirDespesa);
            
            await cadastroDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<DespesaEntity> IncluirDespesaAsync(DespesaEntity despesa)
        {
            cadastroDbContext.Despesas.Add(despesa);
            await cadastroDbContext.SaveChangesAsync();

            return despesa;
        }

        public async Task<List<DespesaEntity>> ListarDespesaAsync()
        {
            return await cadastroDbContext.Despesas.AsNoTracking()
                .OrderBy(despesa => despesa.DataVencimento)
                .ThenBy(despesa => despesa.IdDespesa)
                .ToListAsync();
        }
    }
}
