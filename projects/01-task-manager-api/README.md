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

## Onde paramos

O ultimo assunto estudado foi teste unitario com xUnit, padrao AAA, fake repository e isolamento entre testes.

Estado tecnico atual:

- `Program.cs` registra `TaskItemService` com `builder.Services.AddSingleton<TaskItemService>();`;
- `Program.cs` registra `ITaskItemRepository` com `builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();`;
- `TasksController` recebe `TaskItemService` no construtor;
- `TaskItemService` executa as regras de negocio e retorna `ServiceResult<T>`;
- `TaskItemRepository` possui a lista em memoria, busca por id, adicao, remocao e geracao de ids;
- `TasksController` traduz os resultados da Service para respostas HTTP;
- `GET /api/tasks` pode retornar todas as tarefas ou filtrar por `TaskItemStatus`;
- `TaskManager.Api.Tests` possui uma fake repository para montar cenarios de teste;
- ja existe 1 teste unitario passando para proteger a regra "tarefa cancelada nao pode ser concluida";
- `dotnet test` esta passando.

## Pendencias proximas

- Revisar xUnit, `[Fact]`, `Assert` e AAA.
- Revisar por que `dotnet test` compila a API sem subir servidor HTTP.
- Revisar por que `FakeTaskItemRepository` fica no projeto de testes.
- Revisar por que evitar `static` em fakes de teste.
- Criar o teste `Cancel_WhenTaskIsCompleted_ShouldReturnConflict`.
- Rodar `dotnet test` apos cada teste novo.

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
- teste existente: `Complete_WhenTaskIsCanceled_ShouldReturnConflict`;
- objetivo atual: testar regras de negocio da `TaskItemService` sem subir a API.

## Pendencias futuras

- Persistir dados com Entity Framework Core.
- Criar validacoes mais robustas.
- Adicionar tratamento global de erros.
- Adicionar logging.
- Criar testes de integracao.
- Evoluir para autenticacao e autorizacao.
