# Requisitos
1. Configuração Inicial:
- Crie um projeto de Web API em C# utilizando ASP.NET Core.
- Configure a conexão com o banco de dados (banco de dados da sua escolha).
- Implemente as operações básicas de CRUD para a entidade Fornecedor (listar todos os fornecedores, buscar fornecedor por ID, adicionar fornecedor, atualizar fornecedor, excluir fornecedor).

3. Endpoints da API:
o Implemente os seguintes endpoints:
- GET /api/fornecedores: Retorna todos os fornecedores.
- GET /api/fornecedores/{id}: Retorna um fornecedor específico pelo ID.
- POST /api/fornecedores: Adiciona um novo fornecedor.
- PUT /api/fornecedores/{id}: Atualiza um fornecedor existente pelo ID.
- DELETE /api/fornecedores/{id}: Remove um fornecedor pelo ID.

4. Modelagem de Dados:
- Crie o modelo de dados Fornecedor com os seguintes atributos mínimos:
  - Id (int): Identificador único do fornecedor.
  - Nome (string): Nome do fornecedor.
  - Email (string): Endereço de e-mail do fornecedor.
  - Outros campos relevantes conforme necessário.

5. Documentação:
- Utilize Swagger para documentar os endpoints da API.

# Requisito Opcional
- Criar um projeto Unity que consuma dados da API:
  - Fornecedores devem aparecer como NPCs
    - Devem possuir "Nome" e "Email" em cima de suas cabeças
    - Devem possuir um sprite de personagem aleatório
    - Devem caminhar pela tela aleatóriamente
    - Utilizar o sprite sheet [Sunnyside World](https://danieldiggle.itch.io/sunnyside)
    
    ![exemplo nome npcs](https://github.com/user-attachments/assets/7b1d395d-a03c-4906-9c89-556421586f4a)


# Sprint Planning
Definine o escopo e realiza criação de tarefas no Backlog do quadro Kanbam, simulando um sprint planning da metodologia Scrum.
Foi criado um quadro Kamban contendo tarefas para as features do projeto. O padrão escolhido para a escrita de todas as stories é:
* Justificativa: Resumo breve da necessidade dessa implementação,
* Definições Técnicas: detalha informações técnicas da implemnetação, incluindo requisitos a nível de código, o que ser utilizado e qual versão
* Definições Visuais (se houver): Mostra como exemplo uma imagem que serve como inspiração para a implementação
![image](https://github.com/user-attachments/assets/797f44af-1194-4d64-b58c-8e0ec82ed773)

