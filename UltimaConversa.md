# Ultima Conversa

## Regra de manutencao

Quando o aluno pedir para commitar e atualizar a documentacao, apagar o conteudo antigo deste arquivo e registrar apenas o novo ponto onde a mentoria parou.

## Ponto atual

A suite unitaria da `TaskItemService` foi fechada com 22 testes passando e os testes de integracao da API foram iniciados.

Ultimo resultado reportado pelo aluno:

```text
Resumo do teste: total: 23; falhou: 0; bem-sucedido: 23; ignorado: 0; duracao: 2,3s
Construir exito em 6,4s
```

## O que foi implementado depois do ultimo commit

- pacote `Microsoft.AspNetCore.Mvc.Testing` adicionado ao projeto `TaskManager.Api.Tests`;
- `Program.cs` recebeu `public partial class Program { }`;
- criada pasta `Integration` no projeto de testes;
- criado teste `Get_WhenCalled_ShouldReturnOk` em `TasksControllerIntegrationTests`;
- teste chama `GET /api/tasks` com `HttpClient` criado por `WebApplicationFactory<Program>`;
- teste valida `HttpStatusCode.OK`.

## Conceitos estudados nesta ultima parte

- diferenca entre teste unitario da Service e teste de integracao da API;
- `WebApplicationFactory<Program>` como aplicacao ASP.NET Core em memoria;
- `HttpClient`;
- `GetAsync`;
- `async Task` em testes;
- `await`;
- por que a factory precisa continuar viva enquanto o `HttpClient` e usado;
- por que um helper que cria a factory com `await using` e retorna apenas o client nao funciona bem;
- warning `Failed to determine the https port for redirect` causado por `UseHttpsRedirection()` no ambiente de teste.

## Ponto de atencao

O arquivo `TasksControllerIntegrationTests` tem um helper experimental:

```csharp
private static async Task<HttpClient> CreateClient()
{
    await using var factory = new WebApplicationFactory<Program>();
    return factory.CreateClient();
}
```

Esse helper nao deve ser usado desse jeito, porque a `WebApplicationFactory<Program>` e descartada ao sair do metodo. O `HttpClient` retornado dependeria de uma aplicacao de teste que ja foi encerrada.

## Proxima retomada

Continuar com testes de integracao.

Proxima tarefa tecnica sugerida:

```csharp
GetById_WhenTaskExists_ShouldReturnOk
```

Objetivo:

- chamar `GET /api/tasks/1`;
- validar `200 OK`;
- ler o body JSON com `ReadFromJsonAsync<TaskItem>`;
- validar que `id` e `1`;
- validar que `title` nao veio vazio.

Using novo necessario:

```csharp
using System.Net.Http.Json;
```

Perguntas sugeridas antes da implementacao:

1. O que esse teste valida alem da rota existir?
2. Por que `ReadFromJsonAsync<TaskItem>` pertence ao teste de integracao e nao ao teste unitario da Service?
3. Esse teste deve validar regra de negocio completa ou apenas fluxo HTTP + JSON basico?
