# CrudConsole

Bem-vindo ao CrudConsole! Este projeto é um exemplo básico de operações CRUD (Create, Read, Update, Delete) utilizando C# e SQL Server.

## Sumário

- [Introdução](#introdução)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Uso](#uso)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Introdução

Este projeto foi desenvolvido como um exemplo simples de como realizar operações CRUD em um banco de dados SQL Server usando C#. Ele permite inserir, ler, atualizar e excluir registros na tabela `Pessoas`.

## Tecnologias Utilizadas

- C#
- .NET
- SQL Server
- Microsoft.Data.SqlClient

## Instalação

1. Clone este repositório:

    ```bash
    git clone https://github.com/seu-usuario/CrudConsole.git
    ```

2. Abra o projeto no seu editor de código favorito.

3. Configure a string de conexão no arquivo `CrudConsole.cs` com os dados do seu servidor SQL Server:

    ```csharp
    private static readonly string connectionString = "Server=SeuServidor;Database=AppCRUD;Integrated Security=True;TrustServerCertificate=True;";
    ```

4. Crie o banco de dados e a tabela `Pessoas` no SQL Server:

    ```sql
    CREATE DATABASE AppCRUD;

    USE AppCRUD;

    CREATE TABLE Pessoas (
        ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(50),
        Idade INT
    );
    ```

## Uso

Execute o projeto e siga as instruções no console para inserir, ler, atualizar ou excluir registros na tabela `Pessoas`.

### Inserir Dados

Escolha a opção `1` e siga as instruções para inserir um novo registro.

### Ler Dados

Escolha a opção `2` para ler todos os registros da tabela `Pessoas`.

### Atualizar Dados

Escolha a opção `3`, forneça o ID do registro que deseja atualizar e insira os novos valores para `Nome` e `Idade`.

### Excluir Dados

Escolha a opção `4` e forneça o ID do registro que deseja excluir.

## Contribuição

Sinta-se à vontade para contribuir com este projeto! Faça um fork do repositório, crie um branch com suas alterações e abra um pull request.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
