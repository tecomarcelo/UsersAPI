# UsersAPI - COTI Informática

API para controle de usuários - Curso C# Avançado Formação Arquiteto

## Informações

- **Título:** UsersAPI - COTI Informática
- **Descrição:** API para controle de usuários - Curso C# Avançado Formação Arquiteto
- **Contato:** 
  - **Nome:** COTI Informática
  - **URL:** [http://www.cotiinformatica.com.br](http://www.cotiinformatica.com.br)
  - **Email:** contato@cotiinformatica.com.br
- **Versão:** v1

## Endpoints

### Autenticação (Auth)

- **Autenticar o usuário**
  - Método: POST
  - URL: `/api/auth/login`
  - Descrição: Autentica o usuário
  - Resposta de Sucesso: 200 OK

- **Recuperar senha de acesso do usuário**
  - Método: POST
  - URL: `/api/auth/forgot-password`
  - Descrição: Recupera a senha de acesso do usuário
  - Resposta de Sucesso: 200 OK

- **Reiniciar senha de acesso do usuário**
  - Método: POST
  - URL: `/api/auth/reset-password`
  - Descrição: Reinicia a senha de acesso do usuário
  - Resposta de Sucesso: 200 OK

### Usuários (Users)

- **Criar conta de usuário**
  - Método: POST
  - URL: `/api/users`
  - Descrição: Cria uma nova conta de usuário
  - Resposta de Sucesso: 200 OK

- **Alterar os dados da conta do usuário**
  - Método: PUT
  - URL: `/api/users`
  - Descrição: Altera os dados da conta do usuário
  - Resposta de Sucesso: 200 OK

- **Excluir conta de usuário**
  - Método: DELETE
  - URL: `/api/users`
  - Descrição: Exclui a conta do usuário
  - Resposta de Sucesso: 200 OK

- **Consultar os dados da conta do usuário**
  - Método: GET
  - URL: `/api/users`
  - Descrição: Consulta os dados da conta do usuário
  - Resposta de Sucesso: 200 OK


