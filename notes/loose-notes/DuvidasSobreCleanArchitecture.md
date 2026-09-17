# TaskManager.Domain
O domain é o coração do sistema, é onde ficam as coisas que representam o seu negócio, sem se preocupar como os dados são trazidos ou coletados, é o molde para os dados do negócio.

Exemplo:
```txt
TaskManager.Domain
│
├── Entities
│   ├── TaskItem.cs
│   └── User.cs
│
├── Enums
│   └── TaskStatus.cs
│
├── ValueObjects
│   └── Email.cs
│
├── Exceptions
│   └── InvalidTaskException.cs
│
└── Services
    └── TaskDomainService.cs
```

# TaskManager.Application

> Casos de uso são ações que o sistema pode realizar, é basicamente uma funcionalidade do sistema vista como ação. Você não pensa só focando em um banco ou em uma classe, você é mais amplo: `Receber título -> Validar dados -> Criar TaskItem -> Salvar no repositório -> Retornar o ID criado`. Uma coisa interessante, é que Service, Handler, UseCase, CommandHandler etc. às vezes são nomes diferentes usados para representar praticamente essa mesma ideia, dependendo da arquitetura escolhida 

Aqui é onde fica casos de uso da aplicação, também é onde fica DTOs e Interface do repository. Ele não cria a repository só sabe usar ela. 

Exemplo:
```txt
TaskManager.Application
│
├── Tasks
│   ├── Create
│   │   ├── CreateTaskCommand.cs
│   │   └── CreateTaskHandler.cs
│   │
│   ├── GetById
│   │   ├── GetTaskQuery.cs
│   │   └── GetTaskHandler.cs
│   │
│   └── Complete
│       └── CompleteTaskHandler.cs
│
├── DTOs
│   └── TaskDto.cs
│
└── Interfaces
    └── ITaskRepository.cs
```

# TaskManager.Infrastructure

A camada de Infrastructure implementa a abstração de todo o sistema, é onde fica os detalhes tecnicos do sistema que as outras camadas não conhecem. Aqui que entra DbContext, Repository, Injeção de dependências, alguns serviços e conexões de fora. 

> **Dependency Inversion**: permite que o código de negócio não fique acoplado aos detalhes técnicos, fazendo os detalhes técnicos dependerem dos contratos necessários pelo negócio.

Exemplo:
```txt
TaskManager.Infrastructure
│
├── Persistence
│   ├── TaskManagerDbContext.cs
│   │
│   ├── Configurations
│   │   └── TaskItemConfiguration.cs
│   │
│   ├── Repositories
│   │   └── TaskRepository.cs
│   │
│   └── Migrations
│
├── Services
│   ├── EmailService.cs
│   └── FileStorageService.cs
│
└── DependencyInjection.cs
```

# TaskManager.Api

A camada de API cuida da parte de HTTP e apresentação final. Ideiamente ela faz: `HTTP Request -> Controller -> Application -> Domain -> Infrastructure -> Application -> Controller HTTP Response`.

Exemplo:

```txt
TaskManager.Api
│
├── Controllers
│   └── TasksController.cs
│
├── Middlewares
│   ├── ExceptionMiddleware.cs
│   └── LoggingMiddleware.cs
│
├── Filters
│
├── Extensions
│
├── Program.cs
│
├── appsettings.json
└── appsettings.Development.json
```

# TaskManager.Tests 

Essa é a camada de teste, ela tem os testes de todas as camadas.

```txt
TaskManager.Tests
│
├── Domain
│   └── TaskItemTests.cs
│
├── Application
│   └── CreateTaskHandlerTests.cs
│
├── Infrastructure
│   └── TaskRepositoryTests.cs
│
└── Api
    └── TasksControllerTests.cs
```

> Pode ser serparadas em TaskManager.UnitTests e TaskManager.IntegrationTests em projetos maiores.

# Visualização

```txt
TaskManager.Domain
└── não referencia ninguém

TaskManager.Application
└── referencia Domain

TaskManager.Infrastructure
├── referencia Domain
└── referencia Application

TaskManager.Api
├── referencia Application
└── referencia Infrastructure

TaskManager.Tests
├── referencia Domain
├── referencia Application
├── referencia Infrastructure
└── referencia Api
```