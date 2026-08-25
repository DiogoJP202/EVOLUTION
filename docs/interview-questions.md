# Perguntas de Revisao e Entrevista

Este arquivo guardara perguntas curtas para revisar conceitos aprendidos.

## C# e Orientacao a Objetos

- Qual a diferenca entre classe e objeto?
- O que e encapsulamento?
- Quando uma interface ajuda no design do codigo?
- O que e polimorfismo?

## Web e APIs

- Qual a responsabilidade de um Controller?
- Qual a diferenca entre GET, POST, PUT, PATCH e DELETE?
- O que significa uma API ser REST?
- Quando retornar 200, 201, 204, 400, 404, 409 e 500?
- Qual a diferenca entre route parameter e query string?
- Quando voce usaria `/api/tasks/{id}` e quando usaria `/api/tasks?status=Pending`?
- O que o `[FromQuery]` indica em uma action?
- Quem retorna o `400` quando `[ApiController]` nao consegue converter uma query string para enum?

## Arquitetura e DI

- Qual a responsabilidade de uma Service?
- Qual a responsabilidade de uma Repository?
- Por que a Controller nao deveria conter regra de negocio?
- O que e o container de injecao de dependencia?
- Qual a diferenca entre `Singleton`, `Scoped` e `Transient`?
- Qual a diferenca entre interface e classe concreta?
- O que significa registrar `ITaskItemRepository` apontando para `TaskItemRepository`?
- Por que depender de uma abstracao facilita trocar uma repository em memoria por uma repository com banco?
- O que o `D` do SOLID quer dizer na pratica?
- Por que `ServiceResult<T>` nao deve retornar `IActionResult`?
- Por que `HandleServiceError<T>` pertence a Controller, mesmo sendo generico?
- O que e uma dependencia transitiva em NuGet?

## Banco de Dados

- O que e chave primaria?
- O que e chave estrangeira?
- Qual a diferenca entre INNER JOIN e LEFT JOIN?

## Testes

- O que e um teste unitario?
- O que e um teste de integracao?
- Por que testar regra de negocio no Service costuma ser mais simples do que testar direto no Controller?
- O que e xUnit?
- Para que serve o atributo `[Fact]`?
- O que significa AAA em testes?
- Qual a diferenca entre Arrange, Act e Assert?
- Por que um teste unitario da Service nao precisa subir a API com `dotnet run`?
- Por que o projeto de testes referencia o projeto da API?
- O que e uma fake repository?
- Por que estado `static` em fakes pode causar testes imprevisiveis?
- Por que cada teste deve montar seu proprio cenario?
- O que o teste `Complete_WhenTaskIsCanceled_ShouldReturnConflict` protege?
- O que o teste `Cancel_WhenTaskIsCompleted_ShouldReturnConflict` protege?
- Por que comparar `CompletedAt` com `Assert.Equal` e mais forte do que usar apenas `Assert.NotNull`?
- Por que um helper de teste pode ser `private static`?
- Por que `Assert.Single` pode ser mais expressivo do que `Assert.NotEmpty`?
- Por que validar `Assert.NotNull(result.Data)` antes de acessar `result.Data!`?
- Quando usar `GetAll` ou `GetById` em um teste para confirmar que houve ou nao houve efeito colateral?
- O que significa overtesting?
- Por que teste unitario de Service nao deve validar status HTTP como `BadRequest` ou `NotFound`?
- Quais regras principais a suite `TaskItemServiceTests` protege hoje?
- Qual a diferenca entre chamar `service.Create(request)` e fazer `POST /api/tasks` em um teste?
- O que um teste de integracao da API consegue pegar que um teste unitario da Service nao pega?
- O que `WebApplicationFactory<Program>` cria durante um teste?
- Por que o teste de integracao usa `HttpClient`?
- Por que um teste com `GetAsync` deve ser `async Task`?
- Por que `partial class Program { }` deve ser `public` para uso com `WebApplicationFactory<Program>`?
- Por que um helper que retorna `HttpClient` depois de descartar a `WebApplicationFactory` pode falhar?
- Para que serve `ReadFromJsonAsync<T>()`?
- O primeiro teste de integracao `Get_WhenCalled_ShouldReturnOk` valida regra de negocio ou apenas a existencia funcional da rota?
