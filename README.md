# study-dot-net-core-jwt
Aplicação .Net core 2.0 utilizando JWT para autenticação e autorização de usuário.

### Visão Geral

Este projeto é um estudo geral sobre a utilização de JWT em projetos Dot Net Core (2.0).

Nesta página existe uma visão geral sobre a construção do projeto. Para mais detalhes, acesse o link: 
https://drive.google.com/file/d/1DbK_AE-9-D1MYZdyxsHXLkZzsJBgbcrG/view?usp=sharing

A seguir está uma descrição dos itens necessários é um *top level description* de sua funcionalidade. Acompanhe a descrição navegando entre as classes. 

 ##### Necessário


#### JWT 

JWT (Json Web token) é um padrão aberto que permite o envio de informações via HTTP HEADER ou POST entre duas partes (Cliente / Servidor) em um formato JSON.
As informações enviadas neste Token podem ser validadas devido a sua "assinatura" digital, gerada por meio de um código "secrete" com algoritmo HMAC ou chaves publica/privada usando RSA.

Entenda mais neste link: 


#### Configuração

 Neste tutorial é utilizado um projeto .Net Core 2.0

 O primeiro passo é acrição de um projeto "ASP.NET Core Web Application" e utlizar o Web API.

 ##### Entidades/
 ()
 Adicione uma pasta entidade e crie duas classes: Usuario e ObjetoResposta. 
 **Usuario** será utilizado para guardar as informações do usuário logado na aplicação
 **ObjetoResposta** é o objeto padrão de resposta da nossa aplicação.

 ##### Controller/
 ()
 Adicione uma controller chamada UsuarioController. 
 Esta controller será utilizada para Authenticar nossos usuários. *A validação de dados de autenticação está alem do apresentado neste tutorial*.

 Crie 3 chamadas GET de API "api/Usuario/Administrador", "api/Usuario/RH" e "api/Usuario/Desenvolvedor".

 Para cada uma destas chamadas, crie um objeto Usuário, alterando os valores de acordo com cada perfil. 

 Altere o tipo da resposta das chamadas para enviar um ObjetoResposta. Desta maneira, nós padronizamos a resposta para o cliente.

 ##### Config/ChaveConfiguracao.cs

 Adicione uma pasta chamada **Config** à raiz da aplicação. 
 Esta pasta conterá a classe ChaveConfiguracao.cs.

 Esta classe é responsável por gerar a chave de criptografia do algoritmo JWT.

 ##### Config/Tokenfiguracao.cs

 Adicione à pasta **Config** a classe TokenConfiguracao.

 Esta classe armazenará as configurações que faremos em appsettings.json. Esta atribuição de valores ocorerá na Startup.cs


 ##### Appsettings.json

 Adicione um objeto **TokenConfigurations** ao arquivo. Nele devemos ter os mesmos campos criados em TokenConfiguracao.cs.
 Pois será deste objeto que iremos  popular a classe TokenConfigracao.

 ##### Startup.cs

Ela é responsável por amarrar a configuração da Chave de criptografia e carregamento das configurações de Token e instancia-las como Singleton para a aplicação.

Também fará o papel de definir qual a regra de validação do Token e da criação da regra de autorização para as APIs restritas a usuários autenticados.


 ###### Config/Autenticacao

 A classe é responsável por criar o JWT (token).

 Nela nós criamos as Claims de acordo com as informações do usuário: Nome, Email, Grupo e Id.  Também temos as informações configuradas em appsettings (TokenConfiguracao.cs) e o tempo de expiração baseado na Data/hora da autenticação.

 Ao final é criado o token por meio do metodo WriteToken() e populado o objeto ObjetoResposta com os dados do usuário e o token.
 








