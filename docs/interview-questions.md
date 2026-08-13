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
