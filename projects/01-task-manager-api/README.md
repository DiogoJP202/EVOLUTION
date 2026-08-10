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
- `TaskItemService` iniciado com `GetAll()` e `GetById(int id)`.
- `TaskItemService` registrado no container de DI com `AddSingleton`.
- Arquivo `TaskManager.Api.http` configurado para testar a API.

## Onde paramos

O ultimo assunto estudado foi injecao de dependencia e inicio da extracao da logica da Controller para `TaskItemService`.

Estado tecnico atual:

- `Program.cs` registra `TaskItemService` com `builder.Services.AddSingleton<TaskItemService>();`;
- `TasksController` recebe `TaskItemService` no construtor;
- `TaskItemService` possui a lista em memoria e os metodos `GetAll()` e `GetById(int id)`;
- a Controller ainda nao foi migrada para usar `_taskItemService` nos endpoints;
- o build esta falhando porque `TasksController` ainda referencia `_tasks` e `_nextId`, que nao existem mais na Controller.

## Pendencias proximas

- Revisar DI, container, `Singleton`, `Scoped` e `Transient`.
- Migrar `GET /api/tasks` para usar `_taskItemService.GetAll()`.
- Migrar `GET /api/tasks/{id}` para usar `_taskItemService.GetById(id)`.
- Criar um helper ou bloco simples na Controller para traduzir `ServiceErrorType.NotFound` em `NotFound(...)`.
- Depois migrar `Create`, `Update`, `Complete`, `Cancel` e `Delete` para o service, um por vez.
- Rodar `dotnet build` novamente apos cada pequena migracao.
- Acompanhar o warning `NU1903` do pacote `Microsoft.OpenApi` 2.0.0 apontado pelo `dotnet build`.

## Pendencias futuras

- Finalizar separacao de responsabilidades entre Controller e Service.
- Criar Repository para remover armazenamento da Service.
- Criar interfaces para abstrair comportamento.
- Persistir dados com Entity Framework Core.
- Criar validacoes mais robustas.
- Adicionar tratamento global de erros.
- Adicionar logging.
- Criar testes unitarios.
- Criar testes de integracao.
- Evoluir para autenticacao e autorizacao.
