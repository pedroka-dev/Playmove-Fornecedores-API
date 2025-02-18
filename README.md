# Requisitos
1. Configuração Inicial:
- Crie um projeto de Web API em C# utilizando ASP.NET Core.
- Configure a conexão com o banco de dados (banco de dados da sua
escolha).
- Implemente as operações básicas de CRUD para a entidade Fornecedor
(listar todos os fornecedores, buscar fornecedor por ID, adicionar
fornecedor, atualizar fornecedor, excluir fornecedor).

3. Endpoints da API:
o Implemente os seguintes endpoints:
- GET /api/fornecedores: Retorna todos os fornecedores.
- GET /api/fornecedores/{id}: Retorna um fornecedor específico
pelo ID.
- POST /api/fornecedores: Adiciona um novo fornecedor.
- PUT /api/fornecedores/{id}: Atualiza um fornecedor existente
pelo ID.
- DELETE /api/fornecedores/{id}: Remove um fornecedor pelo ID.

4. Modelagem de Dados:
- Crie o modelo de dados Fornecedor com os seguintes atributos
mínimos:
  - Id (int): Identificador único do fornecedor.
  - Nome (string): Nome do fornecedor.
  - Email (string): Endereço de e-mail do fornecedor.
  - Outros campos relevantes conforme necessário.

5. Documentação:
- Utilize Swagger para documentar os endpoints da API.

# Planejamento Inicial 
Essa etapa foi realizada no primeiro dia, para analisar os requisitos e escopo da aplicação. O planejamento pode ser dividido em 4 sub etapas:
* Modelagem de Classe: Utilização de UML para modelar a classes que serão utilizada, para fins de documentação e para ser utilzando como referência na criação do domínio e banco de dados da aplicação
* Definições de Negócios: Define as regras de negócios levando em consideração os requisitos, simulando as definições de négocio oferecidas por um Product Manager. 
* Definições Visuais: Define a aparência da interface Windows Forms, simulando as definições visuais oferecidas por um Product Managetr.
* Sprint Planning: Definine o escopo e realiza criação de tarefas no Backlog do quadro Kanbam, simulando um sprint planning da metodologia Scrum.
