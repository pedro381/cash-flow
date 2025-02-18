
# Controle de Fluxo de Caixa e Consolida��o Di�ria

## Descri��o do Projeto
Este projeto tem como objetivo fornecer uma solu��o escal�vel e resiliente para que um comerciante controle seu fluxo de caixa di�rio. A aplica��o registra lan�amentos de d�bitos e cr�ditos e gera um relat�rio consolidado do saldo di�rio. A arquitetura adota microsservi�os para isolar as responsabilidades e facilitar a escalabilidade e manuten��o.

## Funcionalidades
- **Registro de Transa��es:** Cria��o, consulta, atualiza��o e dele��o de lan�amentos (d�bito e cr�dito).
- **Consolida��o Di�ria:** Agrega��o dos lan�amentos para calcular o saldo di�rio consolidado.
- **Escalabilidade:** Projeto preparado para crescimento horizontal e alta disponibilidade.
- **Resili�ncia:** Implementa��o de mecanismos de failover e redund�ncia.
- **Seguran�a:** Autentica��o, autoriza��o e criptografia para prote��o dos dados.

## Estrutura do Projeto
- **src/**  
  Cont�m os projetos das APIs e as camadas de Application, Domain e Infrastructure para os m�dulos de Transa��es e Consolida��o.
  
- **tests/**  
  Testes unit�rios e de integra��o para garantir a qualidade e confiabilidade do sistema.

- **docs/**  
  Documenta��o detalhada do projeto, incluindo decis�es arquiteturais e design.

## Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core (.NET 6 ou superior)
- **ORM:** Entity Framework Core
- **Testes:** xUnit, Moq
- **Containeriza��o (opcional):** Docker

## Como Executar a Aplica��o

### Pr�-requisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- Banco de Dados (SQL Server, PostgreSQL ou outro compat�vel)
- (Opcional) Docker, para execu��o em cont�ineres

### Passos para Execu��o
1. **Clonar o Reposit�rio:**
   ```bash
   git clone https://github.com/SEU_USUARIO/ControleFluxoCaixa.git
   cd ControleFluxoCaixa
   ```

2. **Configurar as Strings de Conex�o:**
   - Atualize os arquivos `appsettings.json` de cada API com a string de conex�o do seu banco de dados.

3. **Executar as Migrations (caso use EF Core):**
   ```bash
   cd src/Transactions.Infrastructure
   dotnet ef database update
   cd ../Consolidation.Infrastructure
   dotnet ef database update
   ```

4. **Executar as APIs:**
   - Para a API de Transa��es:
     ```bash
     dotnet run --project src/Transactions.Api
     ```
   - Para a API de Consolida��o:
     ```bash
     dotnet run --project src/Consolidation.Api
     ```

5. **Executar os Testes:**
   ```bash
   dotnet test
   ```

## Documenta��o
- **Arquitetura:** Consulte [docs/architecture.md](docs/architecture.md) para detalhes sobre as decis�es arquiteturais e diagramas.
- **Design:** Consulte [docs/design.md](docs/design.md) para informa��es detalhadas sobre o design e os fluxos de dados.

## Considera��es Finais
Este projeto foi desenvolvido aplicando boas pr�ticas de desenvolvimento, padr�es arquiteturais e de design, garantindo uma solu��o escal�vel, resiliente e segura. Evolu��es futuras podem incluir integra��o com mensageria, melhorias em seguran�a e otimiza��es de desempenho.

---

*Desenvolvido por Pedro Souza.*
```

---
