ContactListAPI
A ContactListAPI é uma API para gerenciar contatos, permitindo criar, visualizar, atualizar e excluir informações de contatos de forma simples e eficiente.

🚀 Recursos
CRUD de contatos:
Criar novos contatos.
Listar contatos existentes.
Atualizar informações de contatos.
Remover contatos.
Suporte a autenticação e segurança.
Documentação integrada com Swagger.
🛠️ Tecnologias Utilizadas
Linguagem: C#
Framework: ASP.NET Core
Banco de Dados: SQLite (ou substituível por outra solução, como SQL Server).
Ferramentas: Entity Framework Core para gerenciamento do banco de dados.
🗂️ Estrutura do Projeto
bash
Copiar código
ContactListAPI/
├── Controllers/        # Controladores da API
├── Models/             # Modelos de dados
├── Data/               # Configuração do banco de dados e contexto
├── Migrations/         # Arquivos de migração do EF Core
├── Services/           # Lógica de negócios e serviços
└── Program.cs          # Configuração inicial da aplicação
📦 Instalação
Clone o repositório:

bash
Copiar código
git clone https://github.com/FroisPeek/ContactListAPI.git
cd ContactListAPI
Restaure os pacotes NuGet:

bash
Copiar código
dotnet restore
Configure o banco de dados:

O projeto está configurado para usar o SQLite por padrão.

Para inicializar o banco de dados, aplique as migrações:

bash
Copiar código
dotnet ef database update
Inicie o servidor:

bash
Copiar código
dotnet run
Acesse a API em: http://localhost:5000.

📖 Uso
Endpoints principais
GET /api/contacts: Retorna todos os contatos.
GET /api/contacts/{id}: Retorna um contato específico pelo ID.
POST /api/contacts: Cria um novo contato.
PUT /api/contacts/{id}: Atualiza um contato existente.
DELETE /api/contacts/{id}: Remove um contato.
Testando com Swagger
Após iniciar a aplicação, acesse a documentação interativa em:
http://localhost:5000/swagger

📋 Contribuição
Faça um fork do projeto.
Crie uma branch com sua feature:
bash
Copiar código
git checkout -b minha-feature
Faça o commit das alterações:
bash
Copiar código
git commit -m 'Adicionei uma nova feature'
Envie as alterações para a branch principal:
bash
Copiar código
git push origin minha-feature
Abra um Pull Request.
