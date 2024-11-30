
# ContactListAPI

A ContactListAPI é uma API para gerenciar contatos, permitindo criar, visualizar, atualizar e excluir informações de contatos de forma simples e eficiente.

🚀 Recursos
- CRUD de contatos:
- Criar novos contatos.
- Listar contatos existentes.
- Atualizar informações de contatos.
- Remover contatos.
- Suporte a autenticação e segurança.
- Documentação integrada com Swagger.

# 🛠️ Tecnologias Utilizadas
- Linguagem: C#
- Framework: ASP.NET Core
- Banco de Dados: SQLite (ou substituível por outra solução, como SQL Server).
- Ferramentas: Entity Framework Core para gerenciamento do banco de dados.

# 🗂️ Estrutura do Projeto
```
ContactListAPI/
├── Controllers/        # Controladores da API
├── Models/             # Modelos de dados
├── Data/               # Configuração do banco de dados e contexto
├── Migrations/         # Arquivos de migração do EF Core
├── Services/           # Lógica de negócios e serviços
└── Program.cs          # Configuração inicial da aplicação
```

# 📦 Instalação
1. Clone o repositório:

``` 
git clone https://github.com/FroisPeek/ContactListAPI.git
cd ContactListAPI
```

2. Restaure os pacotes NuGet:
```
dotnet restore
```

3. Configure o banco de dados:

- O projeto está configurado para usar o SQLite por padrão.
- Para inicializar o banco de dados, aplique as migrações:
```
dotnet ef database update
``` 

4. Inicie o servidor:
```
dotnet run 
```

Acesse a API em: http://localhost:5000.
