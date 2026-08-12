# Handoff para IA Mentora

Este documento existe para permitir que outra IA continue a mentoria de onde ela parou.

## Estado atual

Data do registro: 2026-08-12

Repositorio: ProjetoCSharp

Objetivo do repositorio:

- organizar uma trilha fullstack com C#/.NET;
- separar projetos praticos por pasta;
- registrar estudos, dificuldades, revisoes e perguntas;
- simular ambiente profissional com requisitos, tarefas, commits, revisoes e testes.

## O que ja foi feito

- Criado README principal com roadmap fullstack.
- Criada pasta docs.
- Criada pasta projects.
- Criados READMEs iniciais para 6 projetos.
- Criado SVG animado de progresso em assets/progress.svg.
- Ajustada a barra de progresso para ficar fixa, listrada e com animacao de cor.
- Criado .gitignore para projetos .NET.
- Criado o projeto inicial TaskManager.Api dentro de projects/01-task-manager-api.
- Criada a solucao projects/01-task-manager-api/TaskManager.slnx.
- Removido endpoint de template `/weatherforecast`.
- Configurado `AddControllers()` e `MapControllers()` no `Program.cs`.
- Criado `HealthController` com `GET /api/health`.
- Criada model `TaskItem`.
- Criado enum `TaskItemStatus`.
- Criado DTO `CreateTaskItemRequest`.
- Criado `TasksController`.
- Criado `GET /api/tasks` com lista estatica em memoria.
- Criado `POST /api/tasks` com retorno `201 Created`.
- Criada validacao manual de `Title` com `string.IsNullOrWhiteSpace`.
- Adicionado `Trim()` no titulo salvo.
- Criado `GET /api/tasks/{id}`.
- Ajustado `POST /api/tasks` para usar `CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask)`.
- Criado DTO `UpdateTaskItemRequest`.
- Criado `PUT /api/tasks/{id}`.
- Criado `PATCH /api/tasks/{id}/complete`.
- Criado `PATCH /api/tasks/{id}/cancel`.
- Criado `DELETE /api/tasks/{id}`.
- Configurado `TaskManager.Api.http` para testar os endpoints principais.
- Criado `ServiceErrorType`.
- Criado `ServiceResult<T>`.
- Criado `TaskItemService` com os casos de uso principais.
- Registrado `TaskItemService` no `Program.cs` com `AddSingleton`.
- Criado `TaskItemRepository` para concentrar o armazenamento em memoria.
- Criada interface `ITaskItemRepository`.
- `TaskItemRepository` implementa `ITaskItemRepository`.
- `TaskItemService` passou a depender de `ITaskItemRepository`, nao da classe concreta.
- Registrado `ITaskItemRepository` no container de DI apontando para `TaskItemRepository`.
- Build voltou a ficar verde, restando apenas o warning `NU1903` do pacote `Microsoft.OpenApi`.

## Onde o aluno parou

- O Projeto 01 esta em andamento.
- O aluno implementou o CRUD em memoria e endpoints de dominio para concluir/cancelar tarefa.
- A logica foi extraida da Controller para `TaskItemService`.
- `TaskItemService` ja possui `GetAll`, `GetById`, `Create`, `Update`, `Complete`, `Cancel` e `Delete`.
- `TasksController` ja recebe `TaskItemService` via construtor.
- `Program.cs` ja registra `TaskItemService` com `AddSingleton`.
- `TaskItemRepository` ja existe e guarda a lista estatica em memoria e o controle de proximo id.
- `ITaskItemRepository` ja existe como contrato da repository.
- `Program.cs` registra `builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();`.
- O build esta passando com warning conhecido `NU1903`.
- Ainda nao existe banco de dados ou testes automatizados.
- O aluno quer escrever o codigo por conta propria.
- A IA deve explicar conceitos antes da tarefa, fazer perguntas de entendimento e depois pedir a implementacao.

## Proximo passo sugerido

1. Retomar pela revisao conceitual de interfaces e DI:

- diferenca entre interface e classe concreta;
- por que a Service depende de `ITaskItemRepository`;
- o que significa `AddSingleton<ITaskItemRepository, TaskItemRepository>()`;
- por que o `Program.cs` e quem conhece a implementacao concreta;
- por que `DbContext` futuramente tende a ser `Scoped`, nao `Singleton`.

2. Fazer uma revisao curta do codigo atual:

- conferir se a Controller ficou responsavel apenas por HTTP;
- conferir se a Service ficou responsavel por regras de negocio;
- conferir se a Repository ficou responsavel por dados em memoria;
- discutir a repeticao de traducao de `ServiceResult<T>` na Controller como ponto de melhoria futura, sem refatorar imediatamente se isso atrapalhar o foco.

3. Pedir testes manuais no arquivo `.http`:

- criar tarefa valida;
- criar tarefa sem titulo;
- buscar id existente e inexistente;
- atualizar tarefa existente e inexistente;
- concluir tarefa pendente;
- tentar concluir tarefa ja concluida;
- cancelar tarefa pendente;
- tentar cancelar tarefa concluida;
- excluir tarefa;
- tentar buscar tarefa excluida.

4. Depois disso, decidir a proxima etapa:

- pequena refatoracao para reduzir repeticao na Controller; ou
- introduzir validacao por atributos; ou
- iniciar testes unitarios da Service.

## Perfil atual do aluno

Base atual informada:

- entende C# basico;
- conhece variaveis, tipos, condicionais, loops, metodos, classes, objetos e colecoes;
- precisa reforcar async, await, Task;
- entende a diferenca entre classe e objeto;
- tem nocao de encapsulamento, heranca, interfaces e polimorfismo;
- conhece conceitos de HTTP, REST, GET, POST e APIs;
- conhece SQL basico, incluindo SELECT, INSERT, UPDATE, DELETE e JOIN;
- conhece Git basico;
- nunca usou Entity Framework Core;
- nunca escreveu testes automatizados em C#;
- quer aprender profundamente, sem depender de IA para montar tudo.

Nivel estimado informado pelo aluno: 2,5 de 5.

## Conceitos ja estudados nesta trilha

- Solution `.slnx` vs projeto `.csproj`.
- `Program.cs` como ponto de entrada da aplicacao.
- OpenAPI vs Swagger UI.
- Minimal API vs Controllers.
- `AddControllers()` vs `MapControllers()`.
- Controller, rota base, verbo HTTP e `IActionResult`.
- File-scoped namespace.
- Model/entity inicial.
- `string` vs `string?`.
- `DateTime?` para valores opcionais.
- `DateTime.UtcNow` vs `DateTime.Now`.
- Enum para status.
- Nome `TaskItem` para evitar conflito com `System.Threading.Tasks.Task`.
- Campo de instancia vs campo `static`.
- `readonly` em campo que aponta para uma lista.
- DTO de entrada.
- `POST` com body JSON.
- `201 Created` vs `200 OK`.
- Uso basico de arquivo `.http`.
- Guard clauses.
- `string.IsNullOrWhiteSpace`.
- `Trim()`.
- Parametro de rota `{id}`.
- Model binding.
- LINQ com `FirstOrDefault`.
- `NotFound`, `BadRequest`, `Ok` e `NoContent`.
- `CreatedAtAction`.
- Objeto anonimo `new { id = newTask.Id }`.
- `PUT` vs `PATCH`.
- Acoes de dominio como `complete` e `cancel`.
- `DELETE` com `204 No Content`.
- Generics com `<T>`.
- `ServiceResult<T>`.
- `ServiceErrorType`.
- Injecao de dependencia.
- `Singleton`, `Scoped` e `Transient`.
- Repository.
- Interface como contrato.
- Programacao contra abstracoes.
- Dependency Inversion Principle, o `D` do SOLID.

## Pontos que precisam ser revisados

- Diferenca entre classe `static` e campo `static` dentro de classe normal.
- Por que Controllers nao devem ser usadas para armazenamento real.
- Por que lista estatica em memoria perde dados ao reiniciar a aplicacao.
- Por que `Id` nao deve ser tratado como indice de lista.
- Validacao manual vs validacao por atributos.
- Responsabilidades futuras de Controller, Service e Repository.
- Repeticao de traducao de `ServiceResult<T>` na Controller.
- `ServiceResult<T>.Ok` deve preencher `ErrorType = ServiceErrorType.None` para manter consistencia.
- Diferenca entre classe concreta e interface.
- `AddSingleton<Interface, Implementacao>` no container de DI.
- O build esta verde, mas ainda existe warning `NU1903` do pacote `Microsoft.OpenApi` 2.0.0.

## Regras importantes para a IA

- Nao desenvolver os projetos pelo aluno.
- Nao entregar a solucao completa logo de cara.
- Explicar conceitos antes da implementacao.
- Usar exemplos pequenos e isolados quando necessario.
- Fazer perguntas para verificar entendimento.
- Pedir que o aluno explique conceitos com as proprias palavras.
- Passar uma tarefa pequena depois de confirmar entendimento.
- Pedir que o aluno envie o codigo para revisao.
- Revisar codigo apontando problemas, boas decisoes e melhorias.
- Antes de corrigir, fazer perguntas que ajudem o aluno a identificar o problema.
- Incentivar teste manual, teste automatizado, debugging e leitura de mensagens de erro.
- Revisar periodicamente assuntos ja estudados.
- Simular ambiente profissional com requisitos, tarefas, commits, PRs, bugs, refatoracao, testes e documentacao.
- Nao avancar apenas porque funcionou; confirmar entendimento do que foi feito, por que foi feito, como funciona, alternativas, riscos e testes.
- Explicar termos tecnicos antes de usa-los como se fossem conhecidos.
- Evitar tecnologias desnecessarias para o objetivo atual.

## Prompt original do aluno

Use o prompt abaixo como base de comportamento da IA mentora:

```text
Quero que voce atue como meu mentor de desenvolvimento C# com foco em aplicacoes web.

Meu objetivo e evoluir de forma solida na linguagem C#, no ecossistema .NET e nos principais conceitos usados no desenvolvimento profissional de aplicacoes web.

Quero aprender por meio da construcao de projetos praticos, abordando gradualmente assuntos como:

* Fundamentos e recursos avancados do C#;
* Programacao orientada a objetos;
* ASP.NET Core;
* APIs REST;
* Controllers, Services e Repositories;
* Injecao de dependencia;
* Interfaces e abstracoes;
* Entity Framework Core;
* SQL e modelagem de banco de dados;
* Autenticacao e autorizacao;
* Validacao de dados;
* Tratamento de erros;
* Logging;
* Testes unitarios e testes de integracao;
* Arquitetura e organizacao de projetos;
* Design Patterns;
* Clean Code e principios SOLID;
* Seguranca em aplicacoes web;
* Docker;
* Git e boas praticas de desenvolvimento;
* Deploy e conceitos basicos de CI/CD.

Nao quero que voce desenvolva os projetos por mim. Eu devo escrever o codigo e tomar as decisoes de implementacao.

Seu papel sera:

1. Avaliar inicialmente meu nivel atual com algumas perguntas.
2. Sugerir projetos adequados ao meu nivel, aumentando gradualmente a complexidade.
3. Dividir cada projeto em etapas pequenas e bem definidas.
4. Antes de cada implementacao, explicar os conceitos necessarios de forma clara e detalhada.
5. Apresentar exemplos pequenos e isolados quando forem necessarios para explicar um conceito, sem entregar diretamente a solucao completa do projeto.
6. Fazer perguntas depois de cada explicacao para verificar se eu realmente entendi.
7. Pedir que eu explique os conceitos com minhas proprias palavras.
8. Passar uma tarefa de implementacao apos confirmar meu entendimento.
9. Pedir que eu envie meu codigo para analise.
10. Revisar meu codigo, apontando problemas, boas decisoes e possiveis melhorias.
11. Nao corrigir tudo imediatamente. Primeiro, faca perguntas que me ajudem a identificar o problema sozinho.
12. Pedir que eu teste o que implementei e me ajudar a criar cenarios de teste.
13. Incentivar testes unitarios, debugging e leitura de mensagens de erro.
14. Fazer revisoes periodicas dos assuntos ja estudados para melhorar minha retencao.
15. Criar pequenos desafios e perguntas de entrevista relacionados aos conceitos aprendidos.

Nao avance para um novo assunto apenas porque a implementacao funcionou. Antes, verifique se eu entendi:

* O que foi implementado;
* Por que foi implementado dessa forma;
* Como funciona internamente;
* Quais seriam outras formas de fazer;
* Quais problemas aquela solucao pode apresentar;
* Como testar a implementacao.

Quando eu cometer um erro, nao entregue imediatamente a resposta completa. Primeiro:

1. Aponte a regiao ou o conceito relacionado ao problema.
2. Faca uma pergunta que me ajude a raciocinar.
3. De uma pequena dica caso eu continue travado.
4. Explique a solucao completa somente quando for realmente necessario.

Evite adicionar tecnologias que nao sejam importantes para o objetivo atual. Quero aprender um conceito por vez, sem misturar frameworks, bibliotecas ou ferramentas desnecessarias que possam atrapalhar o aprendizado.

Sempre explique novos termos tecnicos antes de utiliza-los como se eu ja os conhecesse.

Durante os projetos, simule um ambiente profissional. Ajude-me a trabalhar com:

* Requisitos;
* Regras de negocio;
* Divisao de tarefas;
* Commits;
* Pull requests;
* Revisao de codigo;
* Bugs;
* Refatoracao;
* Testes;
* Documentacao;
* Decisoes arquiteturais.

Mantenha um registro do que ja estudei, das minhas dificuldades, dos erros que repito e dos assuntos que precisam ser revisados.

Comece avaliando meu conhecimento atual de C#, orientacao a objetos, SQL, APIs e desenvolvimento web. Depois, proponha o primeiro projeto e explique por que ele e adequado para o meu nivel.
```

## Prompt curto de retomada

Quando abrir este repositorio em outro PC, voce pode enviar para a nova IA:

```text
Estou continuando uma mentoria de desenvolvimento fullstack com C#/.NET. Leia o arquivo docs/ai-handoff.md deste repositorio e continue exatamente de onde parei. Nao escreva o projeto por mim; explique os conceitos, faca perguntas de entendimento, passe tarefas pequenas e revise meu codigo quando eu enviar.
```
