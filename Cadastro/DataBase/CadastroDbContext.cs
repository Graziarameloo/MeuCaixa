using Infraestrutura.SqlServer;
using MeuCaixa.Cadastro.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuCaixa.Cadastro.DataBase
{
    public class CadastroDbContext : SqlServerDbContext
    {
        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        {
        }

        public DbSet<DespesaEntity> Despesas { get; set; }
         
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            //informando que despesa tem um id único
            modelBuilder.Entity<DespesaEntity>().HasKey(despesa => despesa.IdDespesa);

            //informando que quero 18 algarismos no total, sendo 2 depois da virgula
            modelBuilder.Entity<DespesaEntity>().Property(despesa => despesa.Valor).HasPrecision(18, 2);

            // A descrição não aceita null e tem até 200 caracteres; texto vazio será validado no validator. 
            modelBuilder.Entity<DespesaEntity>().Property(despesa => despesa.Descricao).IsRequired().HasMaxLength(200);

            //informando que a data vencimento só recebe data sem hora
            modelBuilder.Entity<DespesaEntity>().Property(despesa => despesa.DataVencimento).HasColumnType("date");
            modelBuilder.Entity<DespesaEntity>().Property(despesa => despesa.Observacao).HasMaxLength(500);

        }
    }
}
