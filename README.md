\# MeuCaixa



API de controle de despesas desenvolvida para praticar C#, .NET,

persistência com Entity Framework Core e regras de negócio.



\## Tecnologias



\- C# e .NET 8

\- ASP.NET Core Web API

\- Entity Framework Core 8

\- SQL Server LocalDB

\- Swagger / OpenAPI



\## Funcionalidades



\- Cadastro, consulta, listagem, alteração e exclusão de despesas.

\- Validação de descrição, valor, vencimento e observação.

\- Novas despesas são cadastradas como pendentes.

\- Bloqueio de alteração e exclusão de despesas pagas.

\- Tratamento de resultados com status HTTP 400, 404, 409 e 500.

\- Versionamento da estrutura do banco por migrations.



\## Organização



\- \*\*API:\*\* controllers e configuração da aplicação.

\- \*\*Cadastro:\*\* entidades, serviços, validações e repositórios.

\- \*\*Infraestrutura:\*\* recursos compartilhados, contexto base e

&#x20; tratamento das respostas HTTP.



\## Como executar



\### Pré-requisitos



\- Visual Studio 2022 com suporte a ASP.NET.

\- SDK do .NET 8.

\- SQL Server Express LocalDB.



\### Configuração



1\. Clone o repositório e abra `MeuCaixa.sln`.

2\. Defina o projeto da API como projeto de inicialização.

3\. Confira a conexão `MeuCaixa` no `appsettings.json` da API:



```json

"ConnectionStrings": {

&#x20; "MeuCaixa": "Server=(localdb)\\\\MSSQLLocalDB;Database=MeuCaixa;Integrated Security=true;TrustServerCertificate=true"

}

```



4\. Compile a solução para restaurar os pacotes.

5\. No Console do Gerenciador de Pacotes NuGet:

&#x20;  - Selecione o projeto que contém `CadastroDbContext` e as migrations

&#x20;    no campo \*\*Projeto padrão\*\*.

&#x20;  - Execute:



```powershell

Update-Database -Context CadastroDbContext

```



6\. Execute a API com F5 e abra o Swagger para testar os endpoints.



\## Regras de negócio



\- Descrição obrigatória, com até 200 caracteres.

\- Valor maior que zero, respeitando o limite de `decimal(18,2)`.

\- Valor com no máximo duas casas decimais.

\- Data de vencimento obrigatória.

\- Observação opcional, com até 500 caracteres.

\- Despesas pagas não podem ser alteradas nem excluídas pelo cadastro.



\## Próximas etapas



\- Testes unitários.

\- Interface com Angular.

\- Filtros na listagem.

\- API Financeira e comunicação entre APIs.

