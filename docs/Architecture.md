# Arquitetura do Projeto

## Vis�o Geral
Este projeto foi desenvolvido para controlar o fluxo de caixa di�rio de um comerciante, registrando lan�amentos (d�bito e cr�dito) e gerando um relat�rio consolidado do saldo di�rio. A solu��o foi projetada com foco em escalabilidade, resili�ncia, seguran�a e desempenho.

## Arquitetura em Microsservi�os
A aplica��o foi dividida em dois servi�os principais:
- **Transactions API:** Respons�vel pelo controle de lan�amentos.
- **Consolidation API:** Respons�vel por gerar e disponibilizar o relat�rio consolidado di�rio.

Cada servi�o � composto por camadas bem definidas:
- **Domain:** Cont�m as entidades e as regras de neg�cio.
- **Application:** Implementa os casos de uso, orquestrando as opera��es do dom�nio.
- **Infrastructure:** Respons�vel pelo acesso a dados, integra��o com bancos de dados e implementa��o de reposit�rios.

## Padr�es e Boas Pr�ticas
- **SOLID:** Aplica��o dos princ�pios SOLID para garantir um c�digo modular e de f�cil manuten��o.
- **Repository Pattern:** Abstra��o do acesso a dados, facilitando a testabilidade e a evolu��o da aplica��o.
- **Dependency Injection:** Para reduzir o acoplamento entre componentes e facilitar a substitui��o de implementa��es.
- **AutoMapper:** Simplifica o mapeamento entre entidades e DTOs.
- **Testes Automatizados:** Utiliza��o de xUnit e Moq para garantir a qualidade do c�digo.

## Escalabilidade e Resili�ncia
- **Escalabilidade Horizontal:** Cada API pode ser replicada independentemente para lidar com aumentos de carga.
- **Balanceamento de Carga:** Implementa��o de balanceadores para distribuir as requisi��es entre inst�ncias.
- **Cache:** Estrat�gias de cache (por exemplo, com Redis) para melhorar a performance.
- **Failover e Redund�ncia:** Monitoramento proativo e mecanismos de recupera��o para garantir alta disponibilidade.

## Diagramas Arquiteturais (Conceituais)
- **Diagrama de Componentes:**
  ```
  [Transactions API]       [Consolidation API]
          |                        |
  [Transactions Application]  [Consolidation Application]
          |                        |
     [Transactions Domain]     [Consolidation Domain]
          |                        |
   [Transactions Infrastructure] [Consolidation Infrastructure]
          |                        |
         [Banco de Dados]         [Banco de Dados]
  ```
- **Diagrama de Sequ�ncia:** Demonstra o fluxo desde o lan�amento de uma transa��o at� sua consolida��o e disponibiliza��o do relat�rio.
- **Diagrama de Implanta��o:** Ilustra a distribui��o dos servi�os em cont�ineres ou servidores, possibilitando escalabilidade horizontal.

## Tecnologias Utilizadas
- **Linguagem:** C#
- **Framework:** ASP.NET Core (.NET 6 ou superior)
- **ORM:** Entity Framework Core
- **Testes:** xUnit, Moq
- **Mensageria:** (Opcional) RabbitMQ
- **Containeriza��o:** (Opcional) Docker
- **Seguran�a:** JWT, OAuth2 (para autentica��o e autoriza��o)
```

---


