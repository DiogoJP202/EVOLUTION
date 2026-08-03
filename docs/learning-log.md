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
