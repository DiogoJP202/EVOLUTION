# Ultima Conversa

## Regra de manutencao

Quando o aluno pedir para commitar e atualizar a documentacao, apagar o conteudo antigo deste arquivo e registrar apenas o novo ponto onde a mentoria parou.

## Ponto pendente

Estamos criando testes unitarios para `TaskItemService` usando xUnit e uma `FakeTaskItemRepository`.

Ultima pergunta conceitual feita:

> Por que, no teste `Cancel_WhenTaskIsCompleted_ShouldReturnConflict`, faz sentido verificar que `CompletedAt` continua preenchido?

## Contexto rapido

- O primeiro teste unitario util criado foi `Complete_WhenTaskIsCanceled_ShouldReturnConflict`.
- Ele valida que uma tarefa cancelada nao pode ser concluida.
- A proxima tarefa sugerida foi criar o teste irmao: uma tarefa concluida nao pode ser cancelada.
- Ao testar cancelamento de uma tarefa concluida, devemos confirmar que a Service retorna `Conflict` e nao altera dados da tarefa.
