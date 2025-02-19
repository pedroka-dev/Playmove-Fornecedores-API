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

# Requisito Extra
- Criar um projeto Unity que consuma dados da API:
  - Fornecedores devem aparecer como NPCs
    - Devem possuir "Nome" e "Email" em cima de suas cabeças
    - Devem possuir um sprite de personagem aleatório
    - Devem caminhar pela tela aleatóriamente
    - Utilizar o sprite sheet [Sunnyside World](https://danieldiggle.itch.io/sunnyside)
    - Exemplo:

    ![exemplo nome npcs](https://github.com/user-attachments/assets/7b1d395d-a03c-4906-9c89-556421586f4a)

# Arquitetura
Foi utilizado o draw.io para realizar o planejamento da arquietura própria desse projeto, com inspiração na arquitetura ASP.NET MVC.
Neste projeto, as duas formas que o usuário podem interagir com a aplicação são através da interface do Swagger (com chamadas do tipo GET, PUT, POST e DELETE) ou através do jogo Unity (será demonstrado apenas chamads GET) para a WebAPI.
A WebAPI por sua vez tem requisições tratadas pelo Controller, que realizada lógica de operações diretamente com a camada ORM.
Por sua vez, a camada ORM gerencia migrations e a entrada ou saída de valores no banco de dados através do EntityFramework 6.

![Arquiteture projeto Playmove](https://github.com/user-attachments/assets/fdb4a96d-c8d3-4ab0-b267-35dd6cce8378)



# Sprint Planning
Definine o escopo e realiza criação de tarefas no Backlog do quadro Kanbam, simulando um sprint planning da metodologia Scrum.
Foi criado um quadro Kamban contendo tarefas para as features do projeto. O padrão escolhido para a escrita de todas as stories é:
* Justificativa: Resumo breve da necessidade dessa implementação, a nível de produto
* Definições Técnicas: Detalha informações a nível de desenvolvimento, incluindo requisitos a nível de código, o que ser utilizado e qual versão
* Definições Visuais (se houver): Demonstra um exemplo estético da implementação 
![image](https://github.com/user-attachments/assets/73bd4ed6-64e6-485c-981f-3c022ef3b215)


