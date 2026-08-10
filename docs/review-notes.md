# Notas de Revisao

Este arquivo sera usado para registrar dificuldades, erros recorrentes, boas decisoes e melhorias percebidas durante as revisoes de codigo.

## Erros recorrentes

- Confundir `Program.cs` com `Project.cs`; lembrar que `.csproj` e o arquivo de projeto.
- Esquecer que `Task` ja existe em C# para programacao assincrona; por isso a entidade foi chamada de `TaskItem`.
- Confundir campo de instancia com campo `static`; lista dentro da Controller sem `static` e recriada por instancia.
- Assumir que `Id` e indice da lista sao equivalentes; isso quebra quando itens sao removidos, reordenados ou filtrados.
- Iniciar uma extracao de Service removendo campos da Controller antes de migrar todos os usos; isso gerou erros `CS0103` para `_tasks` e `_nextId`.

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
- warning `NU1903` do pacote `Microsoft.OpenApi` 2.0.0 gerado pelo template.
- DI container;
- `Singleton`, `Scoped` e `Transient`;
- diferenca entre retornar dados na Service e retornar `IActionResult` na Controller;
- traducao de `ServiceResult<T>` para `Ok`, `NotFound`, `BadRequest` e `NoContent`.
