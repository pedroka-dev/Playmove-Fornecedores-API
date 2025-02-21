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



# Sprint Planning
Definine o escopo e realiza criação de tarefas no Backlog do quadro Kanbam, simulando um sprint planning da metodologia Scrum.
Foi criado um quadro Kamban contendo tarefas para as features do projeto. O padrão escolhido para a escrita de todas as stories é:
* Justificativa: Resumo breve da necessidade dessa implementação, a nível de produto
* Definições Técnicas: Detalha informações a nível de desenvolvimento, incluindo requisitos a nível de código, o que ser utilizado e qual versão
* Definições Visuais (se houver): Demonstra um exemplo estético da implementação 
![image](https://github.com/user-attachments/assets/73bd4ed6-64e6-485c-981f-3c022ef3b215)
    

# Arquitetura
Foi utilizado o draw.io para realizar o planejamento da arquietura própria desse projeto, com inspiração na arquitetura ASP.NET MVC.
Neste projeto, as duas formas que o usuário podem interagir com a aplicação são através da interface do Swagger (com chamadas do tipo GET, PUT, POST e DELETE) ou através do jogo Unity (será demonstrado apenas chamads GET) para a WebAPI.
A WebAPI por sua vez tem requisições tratadas pelo Controller, que realizada lógica de operações diretamente com a camada ORM.
Por sua vez, a camada ORM gerencia migrations e a entrada ou saída de valores no banco de dados através do EntityFramework 6.

![Projeto playmove drawio](https://github.com/user-attachments/assets/0af39845-6d4f-435c-af1d-30baac166346)


## Arquitetura da camada Model
![image](https://github.com/user-attachments/assets/a0c7a214-82be-4eb8-914f-ca1c71321978)

Para o modelo foi criada a clase abstrata base chamada Entity, com só o atributo Id e metodos comuns. Qualquer classe que fosse criada deveria herdar ela.
Foi criada também a classe Fornecedor, com atributos nome e email, que herda dessa classe

![image](https://github.com/user-attachments/assets/90d2084a-bc5a-4f1b-acef-33b0ccd68d87)
![image](https://github.com/user-attachments/assets/fe3f877f-0c62-4d0b-89a3-1718cee8cb29)

## Arquitetura da camada ORM
![image](https://github.com/user-attachments/assets/2f36777f-8f99-415c-93e2-ee6e8dccc825)

Na camada ORM, utilizamos o Entityframework 6 para fazer automaticammente o gerenciamento de um banco SQLite. 
Diferente do padrão ADO.NET, após mapear a nossa classe de modelo em um arquivo configuration, o EF6 cuida automaticamente de novas alterações através das migrations criadas com o comando "add-migration nomemigration"
Para facilitar os testes, foi populado inicialmente o banco por padrão com 4 fornecedores

![image](https://github.com/user-attachments/assets/3337233a-065f-4c22-ba3e-21cbcca4eb4a)
![image](https://github.com/user-attachments/assets/9bc53951-d015-4899-953c-5ee7010da6f6)

As operações de banco podem ser chamadas através de um repositório genérico.

![image](https://github.com/user-attachments/assets/d0508fca-626d-41e2-99f0-143b9a0fe337)


## Arquitetura das camadas WebAPI (Controller + API)
![image](https://github.com/user-attachments/assets/216f96e3-4c3b-4fde-abbe-dd7853648f38)

A Api provém chamadas GET, POST, PUT e DELETE para o caminho "/fornecedor/" na porta 5274.

![image](https://github.com/user-attachments/assets/adc36754-9a5d-44d4-b248-b88be741ba66)

Essas chamadas, por sua vez, chamam métodos do Controller, que interage diretamente com o repositório da camada ORM
![image](https://github.com/user-attachments/assets/268f0ef8-dbb3-4c4c-851d-524f1c107cc8)


## Swagger
Ao rodar o projeto e ir para o link http://localhost:5274/swagger/index.html, o desenvolvedor tem acesso as chamadas dessa API. 
Para melhorar a usabilidade, foi adicionado comentários descritivos na chamada e moodo escuro ao Swagger. 
Todas as chamadas demonstram estar funcionando.

![image](https://github.com/user-attachments/assets/1d2594f8-ac02-4013-8012-0fca74cea8a5)
![image](https://github.com/user-attachments/assets/1fb14a2b-f304-40d9-84bb-383fc1400416)
![image](https://github.com/user-attachments/assets/5f5839c7-3049-4356-b41b-8d91c412d29d)


## Unity Game
![image](https://github.com/user-attachments/assets/a4f9c59c-0f73-4c54-b4b1-8838f55495e8)
![image](https://github.com/user-attachments/assets/c5c26c8a-4c28-490b-aaf8-468ea1a49f81)

No projeto Unity, foi possível pegar os dados da API através da utilização de método GET da biblioteca UnityWebRequest.
Após pegarmos a lista de fornecedores, é instanciado vários personagens "Fornecedores" em posição aleatória pelo mapa.

Essa etapa pode ser testada abrindo o projeto do jogo no Unity versão 2022.2.20f1 ou [através da execução direta das binaries que disponibilizei na aba do Github de release](https://github.com/pedroka-dev/Playmove-Fornecedores-API/releases/tag/binary) em uma VM 

![image](https://github.com/user-attachments/assets/0a33c196-bb72-4407-bc1d-fe1cb9feffd2)
![image](https://github.com/user-attachments/assets/39cf53dc-3f8a-4d89-9dfc-3b2cb38e2075)
![image](https://github.com/user-attachments/assets/8b6e032f-53e0-4011-be0f-a15cc06e26ef)
![image](https://github.com/user-attachments/assets/cc1d1dc8-2afe-4abb-808c-79b2eba42507)

O nome e email do personagem mudam de acordo com os dados da API. A cor do texto e direção que o personagem está virado mudam aleatóriamente

![image](https://github.com/user-attachments/assets/7f8a1914-848b-4d5d-8225-2bca6096281b)

![image](https://github.com/user-attachments/assets/ece4dae5-d1c0-45b5-8ba8-1e04c21ee695)

Arvores, pedras e folhas que estão espalhadas pelo mapa também mudam aleatoriamente. 
![image](https://github.com/user-attachments/assets/66f932b3-bdff-4781-9b74-7fbf8ebf1926)
![image](https://github.com/user-attachments/assets/d24f3e57-ee94-4a61-a4ce-8003f27e89ca)
![image](https://github.com/user-attachments/assets/90cd227d-d6a8-4938-9b37-e626fcbd7f10)


### Resultado final
![image](https://github.com/user-attachments/assets/778dfe23-0155-4f54-a712-c0b28265fa42)

https://github.com/user-attachments/assets/96abc38a-b971-4ee8-8202-afeecad51a65


# Débito técnico
Algumas tarefas planejadas não foram possíveis de terminar, incluindo a ideia de personagens caminhando (com animação) e cabelos aleatórios para cada personagem instanciado. 
![image](https://github.com/user-attachments/assets/47d9f05f-278e-4aad-ad43-e76e00fe1251)
