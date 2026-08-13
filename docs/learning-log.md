# Registro de Estudos

Este arquivo sera atualizado ao final de cada etapa importante.

## Base inicial

Data: 2026-07-29

Assuntos que ja possuem alguma base:

- C# basico;
- orientacao a objetos;
- HTTP;
- REST;
- SQL;
- Git;
- MVC.

Assuntos que precisam de reforco:

- async, await e Task;
- criacao de Web API do zero;
- Entity Framework Core;
- testes automatizados;
- organizacao profissional de projetos.

## Historico

| Data | Projeto | Assunto | Observacoes |
|---|---|---|---|
| 2026-07-29 | Trilha geral | Planejamento | Roadmap criado e estrutura do repositorio preparada. |
| 2026-07-29 | Trilha geral | Handoff | Criado arquivo docs/ai-handoff.md para permitir retomada da mentoria em outro PC ou com outra IA. |
| 2026-08-03 | TaskManager API | Controllers | Removido endpoint `/weatherforecast`, configurado `AddControllers()` e `MapControllers()`, criado `HealthController`. |
| 2026-08-03 | TaskManager API | Models | Criados `TaskItem` e `TaskItemStatus`; revisados nullable reference types, enum, `DateTime.UtcNow` e `DateTime?`. |
| 2026-08-03 | TaskManager API | GET e POST | Criado `TasksController` com lista estatica em memoria, `GET /api/tasks`, DTO `CreateTaskItemRequest` e `POST /api/tasks` retornando `201 Created`. |
| 2026-08-03 | TaskManager API | Onde paramos | Proxima tarefa: validar manualmente `Title` no `POST`, retornando `400 Bad Request` para valores nulos, vazios ou apenas espacos. |
| 2026-08-10 | TaskManager API | CRUD em memoria | Implementados busca por id, validacao de criacao, update, complete, cancel e delete na Controller. |
| 2026-08-10 | TaskManager API | ServiceResult e DI | Criados `ServiceResult<T>`, `ServiceErrorType` e inicio de `TaskItemService`; registrado service com `AddSingleton`. |
| 2026-08-10 | TaskManager API | Onde paramos | Build falha porque `TasksController` ja recebe `TaskItemService`, mas ainda referencia `_tasks` e `_nextId`; proxima etapa e migrar `GET` e `GetById` para o service. |
| 2026-08-12 | TaskManager API | Service completa | Migrados `GetAll`, `GetById`, `Create`, `Update`, `Complete`, `Cancel` e `Delete` para `TaskItemService`; Controller passou a traduzir `ServiceResult<T>` para respostas HTTP. |
| 2026-08-12 | TaskManager API | Repository | Criado `TaskItemRepository` para concentrar lista em memoria, busca por id, adicao, remocao e geracao de ids. |
| 2026-08-12 | TaskManager API | Interface e DI | Criada `ITaskItemRepository`; `TaskItemService` passou a depender da interface e `Program.cs` passou a registrar `ITaskItemRepository -> TaskItemRepository`. |
| 2026-08-12 | TaskManager API | Onde paramos | Build e teste basico funcionaram. Proxima etapa: revisar se Controller, Service e Repository estao com responsabilidades claras e testar todos os endpoints pelo `.http`. |
| 2026-08-13 | TaskManager API | Query string | Adicionado filtro opcional `GET /api/tasks?status=Pending`; revisados query string, route parameter, enum via URL e validacao automatica do `[ApiController]`. |
| 2026-08-13 | TaskManager API | Controller helper | Criado `HandleServiceError<T>` para centralizar traducao de `ServiceResult<T>` para respostas HTTP e reduzir repeticao na Controller. |
| 2026-08-13 | TaskManager API | Pacotes NuGet | Atualizado `Microsoft.AspNetCore.OpenApi` para `10.0.11`, removendo o warning `NU1903` causado pela dependencia transitiva `Microsoft.OpenApi` vulneravel. |
| 2026-08-13 | TaskManager API | Onde paramos | Build passou sem warnings. Proxima etapa sugerida: revisar a feature de filtro e decidir entre validacao por atributos ou primeiros testes unitarios da Service. |
