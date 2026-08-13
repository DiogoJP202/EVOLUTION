# Trilha Fullstack C#/.NET

Repositorio de estudos praticos para evoluir em C#, .NET e desenvolvimento web profissional.

Este espaco sera usado para separar os projetos da trilha, registrar progresso, revisar conceitos e simular uma rotina real de desenvolvimento com requisitos, tarefas, commits, revisoes, testes e refatoracoes.

## Progresso geral

![Barra de progresso animada](./assets/progress.svg)

> Status atual: Projeto 01 em andamento. CRUD em memoria foi organizado em Controller, Service e Repository; a API ja filtra tarefas por status via query string e o build esta limpo.

## Objetivo

Construir uma base solida em desenvolvimento fullstack usando C# e .NET como eixo principal, aprendendo os conceitos por meio de projetos praticos e incrementais.

Ao longo da trilha, o foco sera entender:

- o que foi implementado;
- por que foi implementado dessa forma;
- como funciona internamente;
- quais alternativas existem;
- quais problemas a solucao pode apresentar;
- como testar e revisar a implementacao.

## Como vamos estudar

Cada etapa seguira este ciclo:

1. Entender o requisito.
2. Estudar os conceitos necessarios.
3. Responder perguntas para verificar entendimento.
4. Implementar a tarefa sem receber a solucao completa pronta.
5. Testar manualmente e, depois, com testes automatizados.
6. Enviar o codigo para revisao.
7. Refatorar com base na revisao.
8. Registrar aprendizados, dificuldades e pontos de revisao.

## Projetos da trilha

| Ordem | Projeto | Foco principal | Status | Pasta |
|---:|---|---|---|---|
| 01 | TaskManager API | ASP.NET Core Web API, REST, camadas, DI, validacoes, EF Core e testes | Em andamento | [projects/01-task-manager-api](./projects/01-task-manager-api) |
| 02 | Controle Financeiro Pessoal | SQL, modelagem, relacionamentos, filtros e regras de negocio | Planejado | [projects/02-controle-financeiro-pessoal](./projects/02-controle-financeiro-pessoal) |
| 03 | Biblioteca ou Estoque | CRUD profissional, busca, paginacao, status e historico | Planejado | [projects/03-biblioteca-ou-estoque](./projects/03-biblioteca-ou-estoque) |
| 04 | Frontend Consumindo API | HTML, CSS, JavaScript/TypeScript, consumo de API e formularios | Planejado | [projects/04-frontend-consumindo-api](./projects/04-frontend-consumindo-api) |
| 05 | Sistema Fullstack com Login | JWT, autorizacao, frontend protegido e backend seguro | Planejado | [projects/05-sistema-fullstack-com-login](./projects/05-sistema-fullstack-com-login) |
| 06 | Projeto Final Profissional | Arquitetura, testes, Docker, CI/CD, deploy e documentacao | Planejado | [projects/06-projeto-final-profissional](./projects/06-projeto-final-profissional) |

## Arvore de aprendizado

```text
Fullstack C#/.NET
|-- C# profissional
|   |-- OOP
|   |-- Generics
|   |-- LINQ
|   |-- async, await e Task
|   `-- Clean Code
|
|-- Backend ASP.NET Core
|   |-- Controllers
|   |-- Services
|   |-- Repositories
|   |-- Injecao de dependencia
|   |-- Middlewares
|   |-- Tratamento de erros
|   `-- Logging
|
|-- Banco de dados
|   |-- SQL
|   |-- Modelagem
|   |-- Relacionamentos
|   |-- Entity Framework Core
|   `-- Migrations
|
|-- Testes
|   |-- Testes unitarios
|   |-- Testes de integracao
|   |-- Mocks
|   `-- Testes de API
|
|-- Frontend
|   |-- HTML semantico
|   |-- CSS
|   |-- JavaScript
|   |-- TypeScript
|   |-- React ou Blazor
|   `-- Consumo de APIs
|
|-- Seguranca
|   |-- Autenticacao
|   |-- Autorizacao
|   |-- JWT
|   |-- Claims e roles
|   `-- Boas praticas web
|
`-- Ambiente profissional
    |-- Git
    |-- Pull requests
    |-- Code review
    |-- Docker
    |-- Deploy
    `-- CI/CD
```

## Registro de estudos

Os documentos de acompanhamento ficam em [docs](./docs):

- [ai-handoff.md](./docs/ai-handoff.md): contexto para outra IA continuar a mentoria.
- [learning-log.md](./docs/learning-log.md): registro do que ja foi estudado.
- [review-notes.md](./docs/review-notes.md): erros recorrentes, boas decisoes e pontos de melhoria.
- [interview-questions.md](./docs/interview-questions.md): perguntas de revisao e entrevista.

## Padrao de trabalho

Para cada tarefa, vamos simular um fluxo profissional:

- criar ou escolher uma tarefa pequena;
- entender o requisito antes de codar;
- implementar em passos pequenos;
- testar;
- fazer commit com mensagem clara;
- revisar o codigo;
- refatorar quando necessario;
- registrar o aprendizado.

Sugestao de commits:

```text
Create initial ASP.NET Core Web API project
Add task entity
Add in-memory task repository
Add task creation endpoint
Add validation for task title
Refactor task service responsibilities
Add unit tests for task creation
```

## Preparando para subir no GitHub

Quando estiver pronto para publicar:

```powershell
git branch -M main
git add .
git commit -m "Create C# fullstack learning roadmap"
git remote add origin https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git
git push -u origin main
```

Se o remoto ja existir:

```powershell
git remote set-url origin https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git
git push -u origin main
```

## Estado inicial da mentoria

Base atual:

- C# basico;
- orientacao a objetos basica;
- HTTP e REST basico;
- SQL basico;
- Git basico;
- nocao de MVC.

Pontos de reforco:

- criacao de Web API do zero;
- async, await e Task;
- Entity Framework Core;
- testes automatizados;
- organizacao profissional;
- explicacao de decisoes tecnicas sem depender de IA.

## Ponto Atual

Ultima etapa concluida:

- removido endpoint de template `/weatherforecast`;
- configurado uso de Controllers com `AddControllers()` e `MapControllers()`;
- criado endpoint `GET /api/health`;
- criada model `TaskItem`;
- criado enum `TaskItemStatus`;
- criado DTO `CreateTaskItemRequest`;
- criado DTO `UpdateTaskItemRequest`;
- criado `GET /api/tasks`;
- criado `GET /api/tasks/{id}`;
- criado `POST /api/tasks` com validacao manual de `Title`, `Trim()` e `CreatedAtAction`;
- criado `PUT /api/tasks/{id}`;
- criado `PATCH /api/tasks/{id}/complete`;
- criado `PATCH /api/tasks/{id}/cancel`;
- criado `DELETE /api/tasks/{id}`;
- configurado arquivo `.http` para testar os endpoints principais;
- criado `ServiceResult<T>` e `ServiceErrorType`;
- criado `TaskItemService` com os casos de uso principais;
- criada `TaskItemRepository` para armazenar dados em memoria;
- criada interface `ITaskItemRepository`;
- configurada DI para resolver `ITaskItemRepository` como `TaskItemRepository`;
- criado filtro opcional `GET /api/tasks?status=Pending`;
- criado helper generico `HandleServiceError<T>` na Controller;
- atualizado `Microsoft.AspNetCore.OpenApi` para remover o warning `NU1903`;
- build e teste basico funcionando sem warnings.

Onde paramos:

- a Controller usa `TaskItemService` e traduz `ServiceResult<T>` para respostas HTTP;
- a Service conhece regras de negocio e depende de `ITaskItemRepository`;
- a Repository conhece a lista em memoria e o controle de ids;
- proxima etapa conceitual: revisar route parameter vs query string, enum via URL e helper generico;
- proxima tarefa tecnica: escolher entre validacao por atributos ou primeiros testes unitarios da Service.

Pendencias planejadas do Projeto 01:

- trocar lista em memoria por Entity Framework Core;
- adicionar testes unitarios e testes de integracao;
- adicionar tratamento de erros e logging.
