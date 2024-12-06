# Web API com .NET e SQL Server | CRUD + Repository Pattern

## Descrição

Este projeto é uma Web API criada com .NET, que se conecta a um banco de dados SQL Server. A API implementa operações CRUD (Create, Read, Update, Delete) e utiliza o padrão Repository para uma melhor separação de responsabilidades e facilidade de manutenção do código.

## Tecnologias Utilizadas

- **.NET 6.0**
- **SQL Server**
- **Entity Framework Core**
- **Repository Pattern**
- **Swagger** (para documentação e teste da API)

## Estrutura do Projeto

```plaintext
src/
├── Controllers/
│   └── FuncionariosController.cs
├── Models/
│   └── Funcionario.cs
├── Repositories/
│   ├── IFuncionarioRepository.cs
│   └── FuncionarioRepository.cs
├── Services/
│   └── FuncionarioService.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Dtos/
│   ├── FuncionarioCreateDto.cs
│   └── FuncionarioUpdateDto.cs
├── Program.cs
├── Startup.cs
