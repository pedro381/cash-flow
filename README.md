
# Controle de Fluxo de Caixa e Consolidação Diária

## Descrição do Projeto
Este projeto tem como objetivo fornecer uma solução escalável e resiliente para que um comerciante controle seu fluxo de caixa diário. A aplicação registra lançamentos de débitos e créditos e gera um relatório consolidado do saldo diário. A arquitetura adota microsserviços para isolar as responsabilidades e facilitar a escalabilidade e manutenção.

## Funcionalidades
- **Registro de Transações:** Criação, consulta, atualização e deleção de lançamentos (débito e crédito).
- **Consolidação Diária:** Agregação dos lançamentos para calcular o saldo diário consolidado.
- **Escalabilidade:** Projeto preparado para crescimento horizontal e alta disponibilidade.
- **Resiliência:** Implementação de mecanismos de failover e redundância.
- **Segurança:** Autenticação, autorização e criptografia para proteção dos dados.

## Estrutura do Projeto
- **src/**  
  Contém os projetos das APIs e as camadas de Application, Domain e Infrastructure para os módulos de Transações e Consolidação.
  
- **tests/**  
  Testes unitários e de integração para garantir a qualidade e confiabilidade do sistema.

- **docs/**  
  Documentação detalhada do projeto, incluindo decisões arquiteturais e design.

## Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core (.NET 6 ou superior)
- **ORM:** Entity Framework Core
- **Testes:** xUnit, Moq
- **Containerização (opcional):** Docker

## Como Executar a Aplicação

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Banco de Dados (SQL Server, PostgreSQL ou outro compatível)
- (Opcional) Docker, para execução em contêineres

### Passos para Execução
1. **Clonar o Repositório:**
   ```bash
   git clone https://github.com/pedro381/cash-flow.git
   cd ControleFluxoCaixa
   ```

2. **Configurar as Strings de Conexão:**
   - Atualize os arquivos `appsettings.json` de cada API com a string de conexão do seu banco de dados.

3. **Executar as Migrations (caso use EF Core):**
   ```bash
   cd src/Transactions.Infrastructure
   dotnet ef database update
   cd ../Consolidation.Infrastructure
   dotnet ef database update
   ```

4. **Executar as APIs:**
   - Para a API de Transações:
     ```bash
     dotnet run --project src/Transactions.Api
     ```
   - Para a API de Consolidação:
     ```bash
     dotnet run --project src/Consolidation.Api
     ```

5. **Executar os Testes:**
   ```bash
   dotnet test
   ```

## Documentação
- **Arquitetura:** Consulte [docs/architecture.md](docs/Architecture.md) para detalhes sobre as decisões arquiteturais e diagramas.
- **Design:** Consulte [docs/design.md](docs/DesignDecisions.md) para informações detalhadas sobre o design e os fluxos de dados.

## Considerações Finais
Este projeto foi desenvolvido aplicando boas práticas de desenvolvimento, padrões arquiteturais e de design, garantindo uma solução escalável, resiliente e segura. Evoluções futuras podem incluir integração com mensageria, melhorias em segurança e otimizações de desempenho.

---

*Desenvolvido por Pedro Souza.*
