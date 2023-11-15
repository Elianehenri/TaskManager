# TaskManager



TaskManager é uma aplicação de gerenciamento de tarefas que permite aos usuários criar, listar, obter, atualizar e excluir tarefas. A autenticação é necessária para realizar operações nas tarefas.

## Dependências

- Microsoft.EntityFrameworkCore (7.0.12)
- Microsoft.EntityFrameworkCore.Design (7.0.12)
- Microsoft.EntityFrameworkCore.SqlServer (7.0.12)
- Microsoft.AspNetCore.Authentication.JwtBearer (7.0.12)
- Microsoft.EntityFrameworkCore.Tools (7.0.12)

## Configuração do Projeto

1. Clone este repositório para o seu ambiente local.
   ``` git clone https://github.com/Elianehenri/TaskManager.git ```
2. Execute `dotnet restore` para restaurar as dependências.
3. Execute as migrações do Entity Framework Core com `dotnet ef database update`.
4. Execute o projeto com `dotnet run`.


### Configuração do Banco de Dados

No arquivo `appsettings.json`, configure a string de conexão do banco de dados:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=sua-base-de-dados;User Id=seu-usuario;Password=sua-senha;"
  }
}
```
### Configuração do JWT
```json
{
  "JWT": {
    "secretKey": "sua-chave-secreta"
  }
}
```
## Requisições
 Criar uma nova tarefa

Método: POST
- Rota: /tasks
- Autenticação: Sim
- Corpo da Requisição:
```json
{
  "title": "Nome da Tarefa",
  "description": "Descrição da Tarefa",
  "startDate": "2023-11-13",
  "endDate": "2023-11-20",
  "status": "Em Andamento"
}

```

 Listar todas as tarefas do usuario

- Método: GET
- Rota: /tasks
- Autenticação: Sim

 Obter uma tarefa específica

- Método: GET
- Rota: /tasks/{taskId}
- Autenticação: Sim
Atualizar uma tarefa

- Método: PUT
- Rota: /tasks/{taskId}
- Autenticação: Sim
- Corpo da Requisição:

```json
{
  "title": "Novo Nome da Tarefa",
  "description": "Nova Descrição da Tarefa",
  "startDate": "2023-11-15",
  "endDate": "2023-11-22",
  "status": "Concluída"
}

```

 Excluir uma tarefa

- Método: DELETE
- ota: /tasks/{taskId}
- Autenticação: Sim

  
 #
### Autor
* **Eliane Henriqueta**
