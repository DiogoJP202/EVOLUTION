# Notas de Revisao

Este arquivo sera usado para registrar dificuldades, erros recorrentes, boas decisoes e melhorias percebidas durante as revisoes de codigo.

## Erros recorrentes

- Confundir `Program.cs` com `Project.cs`; lembrar que `.csproj` e o arquivo de projeto.
- Esquecer que `Task` ja existe em C# para programacao assincrona; por isso a entidade foi chamada de `TaskItem`.
- Confundir campo de instancia com campo `static`; lista dentro da Controller sem `static` e recriada por instancia.
- Assumir que `Id` e indice da lista sao equivalentes; isso quebra quando itens sao removidos, reordenados ou filtrados.

## Boas decisoes

- Escolha de `TaskItem` para evitar conflito com `System.Threading.Tasks.Task`.
- Uso de `TaskItemStatus` em vez de `bool IsCompleted`, permitindo evoluir estados da tarefa.
- Uso de `Description` como `string?`, pois descricao e opcional.
- Uso de `CompletedAt` como `DateTime?`, pois tarefa pendente ainda nao tem data de conclusao.
- Troca de `DateTime.Now` por `DateTime.UtcNow` para evitar dependencia do fuso horario da maquina.
- Retornar a variavel `newTask` no `POST` em vez de buscar a tarefa criada por indice na lista.

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
