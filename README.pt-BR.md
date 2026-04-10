# Hedge Calculator

[English](README.md) | [Português](README.pt-BR.md)

Um projeto simples de estudo desenvolvido em C#, WPF e .NET 10 para calcular como dividir um caixa total entre uma odd principal e uma odd secundária.

O objetivo do projeto não é prever resultados, estimar probabilidades ou recomendar apostas. Trata-se apenas de uma calculadora matemática que ajuda a determinar:

- qual é a odd secundária mínima necessária para que a odd principal continue sendo lucrativa
- quanto do caixa total deve ser alocado na odd principal
- quanto do caixa total deve ser alocado na odd secundária
- qual seria o retorno e o lucro em cada cenário

## Objetivo

Este projeto foi criado como um caso de estudo com foco no backend.

A ideia original era manter toda a lógica de negócio dentro de um projeto de domínio e validar todo o comportamento exclusivamente através de testes unitários, sem depender de interface gráfica.

Depois que a lógica principal ficou pronta, uma pequena interface em WPF foi adicionada apenas para facilitar a visualização e os testes manuais.

## Aviso Importante

Este projeto NÃO é:

- uma ferramenta de recomendação de apostas
- um gerador de estratégias de apostas
- uma calculadora de probabilidades
- um sistema de previsão esportiva
- uma garantia de lucro

A aplicação não analisa partidas, times, estatísticas, tendências ou resultados do mundo real.

Ela apenas realiza cálculos matemáticos com base nos valores informados pelo usuário.

O usuário é totalmente responsável pela forma como decidir utilizar os números gerados pela aplicação.

## Exemplo de Cenário

Suponha que você tenha:

- Odd principal: `1.35`
- Caixa total: `100`

A aplicação pode calcular:

- qual é a odd secundária mínima necessária para que a odd principal ainda gere lucro
- quanto deve ser colocado em cada uma das duas apostas
- qual seria o resultado se a odd principal vencer
- qual seria o resultado se a odd secundária vencer

A odd secundária foi pensada para proteger o caixa total, enquanto a odd principal continua sendo a principal fonte de lucro.

## Tecnologias Utilizadas

- C#
- .NET 10
- WPF
- xUnit

## Estrutura do Projeto

```text
HedgeCalculator/
├── HedgeCalculator.Domain
│   ├── Services
│   └── Models
├── ProtectionCalculatorServiceTests
└── HedgeCalculator.Wpf
```

### HedgeCalculator.Domain
Contém toda a lógica de cálculo e as regras de negócio.

### HedgeCalculator.Wpf
Pequena interface desktop construída em WPF para inserir os valores e exibir os resultados dos cálculos.

### ProtectionCalculatorServiceTests
Testes unitários escritos com xUnit para validar todos os cenários de cálculo.

## Principais Funcionalidades

- Calcular a odd secundária mínima
- Calcular a divisão ideal do caixa total
- Exibir lucro ou prejuízo em ambos os cenários
- Informar se a odd secundária protege totalmente o caixa
- Interface WPF simples e limpa
- Cobertura completa da lógica através de testes unitários

## Como Executar o Projeto

1. Clone o repositório
2. Abra a solução no Visual Studio 2022 ou superior
3. Certifique-se de que o SDK do .NET 10 está instalado
4. Defina `HedgeCalculator.Wpf` como projeto de inicialização
5. Execute a aplicação

## Como Executar os Testes

Abra o Test Explorer no Visual Studio e execute todos os testes, ou utilize:

```bash
 dotnet test
```

## Licença

Este projeto está disponível sob a licença MIT.

---

Criado como projeto pessoal de estudo por Gustavo Mariano.

