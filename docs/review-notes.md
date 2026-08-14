# Notas de Revisao

Este arquivo sera usado para registrar dificuldades, erros recorrentes, boas decisoes e melhorias percebidas durante as revisoes de codigo.

## Erros recorrentes

- Confundir `Program.cs` com `Project.cs`; lembrar que `.csproj` e o arquivo de projeto.
- Esquecer que `Task` ja existe em C# para programacao assincrona; por isso a entidade foi chamada de `TaskItem`.
- Confundir campo de instancia com campo `static`; lista dentro da Controller sem `static` e recriada por instancia.
- Assumir que `Id` e indice da lista sao equivalentes; isso quebra quando itens sao removidos, reordenados ou filtrados.
- Iniciar uma extracao de Service removendo campos da Controller antes de migrar todos os usos; isso gerou erros `CS0103` para `_tasks` e `_nextId`.
- Achar que build verde sempre significa arquitetura correta; no caso da interface, o build passava mesmo quando a Service ainda dependia da classe concreta.
- Confundir valor numerico de enum com posicao de lista; `status=999` e invalido porque nao existe no enum, nao porque acessa indice.
- Usar `static` em fake de teste pode compartilhar estado entre testes e tornar resultados imprevisiveis.

## Boas decisoes

- Escolha de `TaskItem` para evitar conflito com `System.Threading.Tasks.Task`.
- Uso de `TaskItemStatus` em vez de `bool IsCompleted`, permitindo evoluir estados da tarefa.
- Uso de `Description` como `string?`, pois descricao e opcional.
- Uso de `CompletedAt` como `DateTime?`, pois tarefa pendente ainda nao tem data de conclusao.
- Troca de `DateTime.Now` por `DateTime.UtcNow` para evitar dependencia do fuso horario da maquina.
- Retornar a variavel `newTask` no `POST` em vez de buscar a tarefa criada por indice na lista.
- Usar `CreatedAtAction` depois de criar `GetById`, conectando o `Location` do `POST` a uma action real.
- Criar endpoints de dominio separados para `complete` e `cancel`, em vez de deixar o cliente alterar `Status` livremente.
- Escolher `ServiceResult<T>` para separar resultado de negocio de resposta HTTP.
- Migrar a logica de negocio da Controller para `TaskItemService`.
- Criar `TaskItemRepository` para isolar o acesso aos dados em memoria.
- Criar `ITaskItemRepository` e fazer a Service depender da abstracao.
- Registrar `ITaskItemRepository` apontando para `TaskItemRepository` no `Program.cs`.
- Colocar o filtro por status na Service, mantendo a Controller focada em HTTP.
- Criar `HandleServiceError<T>` para evitar repetir a traducao de erros em cada action.
- Atualizar o pacote direto `Microsoft.AspNetCore.OpenApi` para corrigir vulnerabilidade em dependencia transitiva.
- Criar projeto de testes separado para manter codigo de teste fora da API.
- Usar `FakeTaskItemRepository` para testar a Service contra a interface `ITaskItemRepository`.
- Refatorar a fake para receber dados pelo construtor, permitindo cada teste montar seu proprio cenario.
- Criar o primeiro teste unitario de regra de negocio: tarefa cancelada nao pode ser concluida.
- Fortalecer o teste de tarefa concluida comparando o valor exato de `CompletedAt`, nao apenas verificando que ele nao e nulo.
- Criar helper pequeno de teste para reduzir repeticao sem esconder o comportamento testado.

## Pontos para revisar depois

- async, await e Task;
- responsabilidades entre Controller, Service e Repository;
- testes unitarios;
- Entity Framework Core.
- `static` vs instancia;
- `readonly` em campos que apontam para listas;
- DTOs de entrada;
- `201 Created` vs `200 OK`;
- validacao manual vs validacao por atributos.
- DI container;
- `Singleton`, `Scoped` e `Transient`;
- diferenca entre retornar dados na Service e retornar `IActionResult` na Controller;
- traducao de `ServiceResult<T>` para `Ok`, `NotFound`, `BadRequest` e `NoContent`.
- interfaces como contratos;
- diferenca entre depender de classe concreta e depender de abstracao;
- `AddSingleton<ITaskItemRepository, TaskItemRepository>()`;
- Dependency Inversion Principle, o `D` do SOLID;
- quando usar `Conflict` para conflito de regra/estado.
- route parameter vs query string;
- `[FromQuery]`;
- enum recebido pela URL;
- dependencia transitiva em pacotes NuGet.
- xUnit, `[Fact]` e `Assert`;
- padrao AAA: Arrange, Act, Assert;
- fake repository;
- isolamento entre testes;
- estado compartilhado e por que evitar `static` em fakes;
- Project Reference entre projeto de testes e projeto da API.
- helpers de teste;
- quando usar `private static` em metodo auxiliar de teste;
- diferenca entre `Assert.NotNull` e `Assert.Equal` ao preservar um valor.
