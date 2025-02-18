# Design do Projeto

## Introdu��o
Este documento detalha as escolhas de design e os fluxos de dados entre os componentes da solu��o, garantindo que os requisitos de neg�cio e n�o-funcionais sejam atendidos.

## Fluxo de Dados e Processos
1. **Registro de Transa��es:**
   - O comerciante envia uma requisi��o para a **Transactions API** com os dados do lan�amento (d�bito ou cr�dito).
   - A API valida e encaminha os dados para a camada de aplica��o, que aplica as regras de neg�cio.
   - A transa��o � persistida no banco de dados por meio do reposit�rio na camada de infraestrutura.

2. **Consolida��o Di�ria:**
   - Em per�odos definidos ou mediante requisi��o, a **Consolidation API** agrega os lan�amentos do dia.
   - A camada de aplica��o consulta os dados e calcula o saldo consolidado.
   - O relat�rio consolidado � disponibilizado atrav�s de um endpoint REST.

## Componentes e Intera��es
- **Transactions API:**
  - **Controllers:** Expor endpoints REST para cria��o e consulta de transa��es.
  - **Services:** Implementam a l�gica de neg�cio e validam os dados.
  - **Repositories:** Abstraem o acesso ao banco de dados, utilizando Entity Framework Core.
  
- **Consolidation API:**
  - **Controllers:** Expor endpoints REST para consulta do relat�rio consolidado.
  - **Services:** Orquestram a consolida��o dos dados e aplicam as regras de agrega��o.
  - **Repositories:** Realizam o acesso aos dados necess�rios para a consolida��o.

## Diagramas de Design
- **Diagrama de Componentes:**
  ```
  [Client]
     |
  [API Gateway (Opcional)]
     |
  ---------------------------------
  |             |               |
  |   Transactions API   Consolidation API  |
  |             |               |
  ---------------------------------
  ```
- **Diagrama de Sequ�ncia (Exemplo de Lan�amento e Consolida��o):**
  1. O cliente envia uma requisi��o para registrar uma transa��o.
  2. A Transactions API processa e armazena a transa��o.
  3. Ao final do dia, a Consolidation API � acionada para agrupar as transa��es do per�odo.
  4. O resultado � retornado ao cliente mediante requisi��o.

## Padr�es e Pr�ticas de Design
- **Separation of Concerns:** Cada camada � respons�vel por uma parte espec�fica da aplica��o (dom�nio, aplica��o, infraestrutura).
- **Reusabilidade:** Componentes comuns, como valida��o e mapeamento (AutoMapper), s�o centralizados para facilitar a manuten��o.
- **Testabilidade:** A estrutura permite a cria��o de testes unit�rios e de integra��o, garantindo a qualidade e robustez do sistema.
- **Seguran�a:** Implementa��o de mecanismos de autentica��o, autoriza��o e criptografia para proteger os dados e a comunica��o.
```

---
