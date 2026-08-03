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
- Arquivo `TaskManager.Api.http` configurado para testar a API.

## Onde paramos

O ultimo assunto estudado foi criacao de tarefas com `POST /api/tasks`, DTO de entrada e retorno `201 Created`.

A proxima tarefa e validar o campo `Title` no `POST`:

- se `Title` for nulo, vazio ou apenas espacos, retornar `400 Bad Request`;
- se `Title` for valido, criar a tarefa normalmente;
- usar `string.IsNullOrWhiteSpace(request.Title)` para entender validacao manual antes de usar atributos no DTO.

## Pendencias proximas

- Validar `Title` manualmente na Controller.
- Testar payloads invalidos no `.http`.
- Criar endpoint `GET /api/tasks/{id}`.
- Trocar `Created($"api/tasks/{id}", task)` por `CreatedAtAction` quando existir busca por id.
- Discutir por que a lista estatica e temporaria e nao e arquitetura final.
- Acompanhar o warning `NU1903` do pacote `Microsoft.OpenApi` 2.0.0 apontado pelo `dotnet build`.

## Pendencias futuras

- Separar responsabilidades em Service e Repository.
- Criar interfaces para abstrair comportamento.
- Introduzir injecao de dependencia.
- Persistir dados com Entity Framework Core.
- Criar validacoes mais robustas.
- Adicionar tratamento global de erros.
- Adicionar logging.
- Criar testes unitarios.
- Criar testes de integracao.
- Evoluir para autenticacao e autorizacao.
