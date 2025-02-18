# Arquitetura do Projeto

## Visão Geral
Este projeto foi desenvolvido para controlar o fluxo de caixa diário de um comerciante, registrando lançamentos (débito e crédito) e gerando um relatório consolidado do saldo diário. A solução foi projetada com foco em escalabilidade, resiliência, segurança e desempenho.

## Arquitetura em Microsserviços
A aplicação foi dividida em dois serviços principais:
- **Transactions API:** Responsável pelo controle de lançamentos.
- **Consolidation API:** Responsável por gerar e disponibilizar o relatório consolidado diário.

Cada serviço é composto por camadas bem definidas:
- **Domain:** Contém as entidades e as regras de negócio.
- **Application:** Implementa os casos de uso, orquestrando as operações do domínio.
- **Infrastructure:** Responsável pelo acesso a dados, integração com bancos de dados e implementação de repositórios.

## Padrões e Boas Práticas
- **SOLID:** Aplicação dos princípios SOLID para garantir um código modular e de fácil manutenção.
- **Repository Pattern:** Abstração do acesso a dados, facilitando a testabilidade e a evolução da aplicação.
- **Dependency Injection:** Para reduzir o acoplamento entre componentes e facilitar a substituição de implementações.
- **AutoMapper:** Simplifica o mapeamento entre entidades e DTOs.
- **Testes Automatizados:** Utilização de xUnit e Moq para garantir a qualidade do código.

## Escalabilidade e Resiliência
- **Escalabilidade Horizontal:** Cada API pode ser replicada independentemente para lidar com aumentos de carga.
- **Balanceamento de Carga:** Implementação de balanceadores para distribuir as requisições entre instâncias.
- **Cache:** Estratégias de cache (por exemplo, com Redis) para melhorar a performance.
- **Failover e Redundância:** Monitoramento proativo e mecanismos de recuperação para garantir alta disponibilidade.

## Diagramas Arquiteturais (Conceituais)
- **Diagrama de Componentes:**
  ```
[Transactions API]            [Consolidation API]
          |                            |
[Transactions Application]    [Consolidation Application]
          |                            |
[Transactions Domain]         [Consolidation Domain]
          |                            |
[Transactions Infrastructure] [Consolidation Infrastructure]
          |                            |
[Banco de Dados]              [Banco de Dados]
  ```
- **Diagrama de Sequência:** Demonstra o fluxo desde o lançamento de uma transação até sua consolidação e disponibilização do relatório.
- **Diagrama de Implantação:** Ilustra a distribuição dos serviços em contêineres ou servidores, possibilitando escalabilidade horizontal.

## Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core (.NET 6 ou superior)
- **ORM:** Entity Framework Core
- **Testes:** xUnit, Moq
- **Containerização:** (Opcional) Docker
