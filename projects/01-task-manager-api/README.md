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
- Arquivo `TaskManager.Api.http` configurado para testar a API.

## Onde paramos

O ultimo assunto estudado foi interface aplicada a Repository e injecao de dependencia usando abstracao.

Estado tecnico atual:

- `Program.cs` registra `TaskItemService` com `builder.Services.AddSingleton<TaskItemService>();`;
- `Program.cs` registra `ITaskItemRepository` com `builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();`;
- `TasksController` recebe `TaskItemService` no construtor;
- `TaskItemService` executa as regras de negocio e retorna `ServiceResult<T>`;
- `TaskItemRepository` possui a lista em memoria, busca por id, adicao, remocao e geracao de ids;
- `TasksController` traduz os resultados da Service para respostas HTTP;
- o build esta passando, com o warning conhecido `NU1903` do pacote `Microsoft.OpenApi`.

## Pendencias proximas

- Revisar interface, implementacao concreta e inversao de dependencia.
- Testar todos os endpoints pelo arquivo `.http` apos a criacao da interface.
- Revisar responsabilidades atuais entre Controller, Service e Repository.
- Avaliar, sem pressa, uma pequena refatoracao para reduzir repeticao na traducao de `ServiceResult<T>` dentro da Controller.
- Rodar `dotnet build` apos cada pequena mudanca.
- Acompanhar o warning `NU1903` do pacote `Microsoft.OpenApi` 2.0.0 apontado pelo `dotnet build`.

## Pendencias futuras

- Persistir dados com Entity Framework Core.
- Criar validacoes mais robustas.
- Adicionar tratamento global de erros.
- Adicionar logging.
- Criar testes unitarios.
- Criar testes de integracao.
- Evoluir para autenticacao e autorizacao.
