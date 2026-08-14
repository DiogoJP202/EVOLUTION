# Ultima Conversa

## Regra de manutencao

Quando o aluno pedir para commitar e atualizar a documentacao, apagar o conteudo antigo deste arquivo e registrar apenas o novo ponto onde a mentoria parou.

## Ponto pendente

Estamos refatorando testes unitarios de `TaskItemService` com xUnit, AAA e `FakeTaskItemRepository`.

Ultima pergunta conceitual feita:

> Por que o helper `CreateServiceWithTasks` pode ser `private static`?

## Contexto rapido

- Ja existem dois testes de regra de negocio em `TaskItemServiceTests`:
  - `Complete_WhenTaskIsCanceled_ShouldReturnConflict`;
  - `Cancel_WhenTaskIsCompleted_ShouldReturnConflict`.
- O segundo teste foi fortalecido para comparar o valor exato de `CompletedAt`, nao apenas `Assert.NotNull`.
- O aluno criou o helper `CreateServiceWithTasks(List<TaskItem> tasks)` para reduzir repeticao no Arrange.
- Proxima retomada: responder a pergunta sobre `private static`, revisar o helper e rodar `dotnet test`.
