# Design do Projeto

## Introdução
Este documento detalha as escolhas de design e os fluxos de dados entre os componentes da solução, garantindo que os requisitos de negócio e não-funcionais sejam atendidos.

## Fluxo de Dados e Processos
1. **Registro de Transações:**
   - O comerciante envia uma requisição para a **Transactions API** com os dados do lançamento (débito ou crédito).
   - A API valida e encaminha os dados para a camada de aplicação, que aplica as regras de negócio.
   - A transação é persistida no banco de dados por meio do repositório na camada de infraestrutura.

2. **Consolidação Diária:**
   - Em períodos definidos ou mediante requisição, a **Consolidation API** agrega os lançamentos do dia.
   - A camada de aplicação consulta os dados e calcula o saldo consolidado.
   - O relatório consolidado é disponibilizado através de um endpoint REST.

## Componentes e Interações
- **Transactions API:**
  - **Controllers:** Expor endpoints REST para criação e consulta de transações.
  - **Services:** Implementam a lógica de negócio e validam os dados.
  - **Repositories:** Abstraem o acesso ao banco de dados, utilizando Entity Framework Core.
  
- **Consolidation API:**
  - **Controllers:** Expor endpoints REST para consulta do relatório consolidado.
  - **Services:** Orquestram a consolidação dos dados e aplicam as regras de agregação.
  - **Repositories:** Realizam o acesso aos dados necessários para a consolidação.

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
- **Diagrama de Sequência (Exemplo de Lançamento e Consolidação):**
  1. O cliente envia uma requisição para registrar uma transação.
  2. A Transactions API processa e armazena a transação.
  3. Ao final do dia, a Consolidation API é acionada para agrupar as transações do período.
  4. O resultado é retornado ao cliente mediante requisição.

## Padrões e Práticas de Design
- **Separation of Concerns:** Cada camada é responsável por uma parte específica da aplicação (domínio, aplicação, infraestrutura).
- **Reusabilidade:** Componentes comuns, como validação e mapeamento (AutoMapper), são centralizados para facilitar a manutenção.
- **Testabilidade:** A estrutura permite a criação de testes unitários e de integração, garantindo a qualidade e robustez do sistema.
- **Segurança:** Implementação de mecanismos de autenticação, autorização e criptografia para proteger os dados e a comunicação.
