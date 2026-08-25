# Projeto 01 - TaskManager API

## Objetivo

Construir uma API REST para gerenciamento de tarefas, com evolucao gradual de armazenamento em memoria para banco de dados com Entity Framework Core.

## Conceitos principais

- ASP.NET Core Web API;
- Controllers;
- Services;
- Repositories;
- injecao de dependencia;
- DTOs;
- validacao;
- tratamento de erros;
- EF Core;
- testes unitarios;
- testes de integracao.

## Funcionalidades

- criar tarefa;
- listar tarefas;
- buscar tarefa por id;
- atualizar tarefa;
- concluir tarefa;
- excluir tarefa;
- filtrar por status.

## Status

Em andamento.

## Ja implementado

- Projeto ASP.NET Core Web API criado.
- Template `/weatherforecast` removido.
- `Program.cs` configurado com OpenAPI e Controllers.
- `HealthController` criado em `GET /api/health`.
- Model `TaskItem` criada.
- Enum `TaskItemStatus` criado.
- DTO `CreateTaskItemRequest` criado.
- `TasksController` criado.
- `GET /api/tasks` lista tarefas em memoria.
- `POST /api/tasks` cria tarefas em memoria e retorna `201 Created`.
- `POST /api/tasks` valida `Title` manualmente com `IsNullOrWhiteSpace`.
- `POST /api/tasks` normaliza `Title` com `Trim()`.
- `POST /api/tasks` usa `CreatedAtAction` apontando para `GetById`.
- `GET /api/tasks/{id}` busca tarefa por id e retorna `404` quando nao encontra.
- DTO `UpdateTaskItemRequest` criado.
- `PUT /api/tasks/{id}` atualiza titulo e descricao.
- `PATCH /api/tasks/{id}/complete` conclui uma tarefa e preenche `CompletedAt`.
- `PATCH /api/tasks/{id}/cancel` cancela uma tarefa.
- `DELETE /api/tasks/{id}` remove uma tarefa e retorna `204 No Content`.
- `ServiceResult<T>` e `ServiceErrorType` criados.
- `TaskItemService` criado com `GetAll`, `GetById`, `Create`, `Update`, `Complete`, `Cancel` e `Delete`.
- `TaskItemService` registrado no container de DI com `AddSingleton`.
- `TaskItemRepository` criado para concentrar a lista em memoria e o controle de ids.
- Interface `ITaskItemRepository` criada.
- `TaskItemRepository` implementa `ITaskItemRepository`.
- `TaskItemService` depende de `ITaskItemRepository`.
- `Program.cs` registra `ITaskItemRepository` apontando para `TaskItemRepository`.
- `GET /api/tasks` aceita filtro opcional por query string: `?status=Pending`, `?status=Completed`, etc.
- `TasksController` usa `HandleServiceError<T>` para centralizar a traducao de erros da Service para HTTP.
- Pacote `Microsoft.AspNetCore.OpenApi` atualizado para `10.0.11`, removendo o warning `NU1903`.
- Arquivo `TaskManager.Api.http` configurado para testar a API.
- Projeto `TaskManager.Api.Tests` criado com xUnit.
- Projeto de testes adicionado na solution.
- Projeto de testes referencia `TaskManager.Api`.
- `FakeTaskItemRepository` criada para testar `TaskItemService` sem HTTP e sem repository real.
- Primeiro teste unitario criado: `Complete_WhenTaskIsCanceled_ShouldReturnConflict`.
- Segundo teste unitario criado: `Cancel_WhenTaskIsCompleted_ShouldReturnConflict`.
- Helper `CreateServiceWithTasks` criado para reduzir repeticao no Arrange.
- Suite `TaskItemServiceTests` ampliada para 22 testes unitarios.
- Cobertos cenarios de criacao, busca, listagem, update, complete, cancel e delete.
- Testados validacao de titulo, `Trim()` de titulo/descricao, filtro por status, conflitos de estado e remocao real de tarefa.
- Revisada a suite para reduzir asserts repetidos, corrigir nomes e manter `Assert.NotNull(result.Data)` antes de acessar `result.Data!`.
- Pacote `Microsoft.AspNetCore.Mvc.Testing` adicionado ao projeto de testes.
- `Program.cs` recebeu `public partial class Program { }` para permitir `WebApplicationFactory<Program>`.
- Pasta `Integration` criada no projeto de testes.
- Primeiro teste de integracao criado: `Get_WhenCalled_ShouldReturnOk`.
- `GET /api/tasks` testado por HTTP em memoria com `HttpClient`, retornando `200 OK`.

## Onde paramos

O ultimo assunto estudado foi a diferenca entre teste unitario da Service e teste de integracao da API. A suite unitaria foi fechada e os testes de integracao foram iniciados.

Estado tecnico atual:

- `Program.cs` registra `TaskItemService` com `builder.Services.AddSingleton<TaskItemService>();`;
- `Program.cs` registra `ITaskItemRepository` com `builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();`;
- `TasksController` recebe `TaskItemService` no construtor;
- `TaskItemService` executa as regras de negocio e retorna `ServiceResult<T>`;
- `TaskItemRepository` possui a lista em memoria, busca por id, adicao, remocao e geracao de ids;
- `TasksController` traduz os resultados da Service para respostas HTTP;
- `GET /api/tasks` pode retornar todas as tarefas ou filtrar por `TaskItemStatus`;
- `TaskManager.Api.Tests` possui uma fake repository para montar cenarios de teste;
- ja existem 22 testes unitarios protegendo as regras principais da `TaskItemService`;
- ja existe 1 teste de integracao para `GET /api/tasks`;
- o ultimo `dotnet test` reportado passou com 23 testes.

## Pendencias proximas

- Revisar `WebApplicationFactory<Program>` como aplicacao ASP.NET Core em memoria para testes.
- Revisar `HttpClient`, `GetAsync`, `async Task` e `await`.
- Revisar por que um helper que usa `await using var factory` e retorna apenas `HttpClient` descarta a factory cedo demais.
- Criar teste de integracao `GetById_WhenTaskExists_ShouldReturnOk`.
- Ler o body JSON com `ReadFromJsonAsync<TaskItem>`.
- Validar `200 OK`, `id = 1` e `title` preenchido.
- Observar o warning `Failed to determine the https port for redirect` causado por `UseHttpsRedirection()` no ambiente de teste.
- Rodar `dotnet test` antes de cada commit relevante.

## Testes

Projeto de testes:

```text
TaskManager.Api.Tests
```

Comando para rodar:

```powershell
dotnet test
```

Estado atual:

- framework usado: xUnit;
- fake criada: `FakeTaskItemRepository`;
- testes existentes:
  - `Complete_WhenTaskIsCanceled_ShouldReturnConflict`;
  - `Cancel_WhenTaskIsCompleted_ShouldReturnConflict`;
  - `GetById_WhenTaskDoesNotExist_ShouldReturnNotFound`;
  - `Create_WhenTitleIsEmpty_ShouldReturnValidation`;
  - `Create_WhenTitleHasOnlySpaces_ShouldReturnValidation`;
  - `Create_WhenTitleIsValid_ShouldCreateTask`;
  - `Create_WhenDescriptionIsNull_ShouldCreateTaskWithNullDescription`;
  - `Create_WhenDescriptionHasSpaces_ShouldTrimDescription`;
  - `GetById_WhenTaskExists_ShouldReturnTask`;
  - `GetAll_WhenStatusFilterIsNull_ShouldReturnAllTasks`;
  - `GetAll_WhenStatusFilterIsCompleted_ShouldReturnOnlyCompletedTasks`;
  - `Update_WhenTaskDoesNotExist_ShouldReturnNotFound`;
  - `Update_WhenTitleIsEmpty_ShouldReturnValidation`;
  - `Update_WhenTitleHasOnlySpaces_ShouldReturnValidation`;
  - `Update_WhenDataIsValid_ShouldUpdateTask`;
  - `Complete_WhenTaskDoesNotExist_ShouldReturnNotFound`;
  - `Complete_WhenTaskIsPending_ShouldCompleteTask`;
  - `Cancel_WhenTaskDoesNotExist_ShouldReturnNotFound`;
  - `Cancel_WhenTaskIsPending_ShouldCancelTask`;
  - `Delete_WhenTaskDoesNotExist_ShouldReturnNotFound`;
  - `Delete_WhenTaskExists_ShouldRemoveTask`;
  - `Create_WhenDescriptionHasOnlySpaces_ShouldTrimDescriptionToEmptyString`;
- helper existente: `CreateServiceWithTasks`;
- objetivo atual: manter a Service protegida por testes unitarios antes de evoluir infraestrutura.
- pacote de integracao: `Microsoft.AspNetCore.Mvc.Testing`;
- teste de integracao existente:
  - `Get_WhenCalled_ShouldReturnOk`;
- total reportado no ultimo `dotnet test`: 23 testes passando;
- objetivo atual: iniciar testes de integracao da API sem subir servidor real em `localhost`.

## Pendencias futuras

- Persistir dados com Entity Framework Core.
- Criar validacoes mais robustas.
- Adicionar tratamento global de erros.
- Adicionar logging.
- Ampliar testes de integracao.
- Evoluir para autenticacao e autorizacao.
