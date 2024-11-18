# Eventify
# Projeto Full-Stack: Angular e .NET Core

Este projeto foi desenvolvido como parte do curso **[Desenvolvimento Full-Stack com Angular e .NET Core e EF Core](https://www.udemy.com/course/angular-dotnetcore-efcore/)** da Udemy, ministrado por **Vinícius Andrade**. Ele consiste em uma aplicação web integrada, utilizando **Angular** no front-end e **ASP.NET Core** no back-end.

## 📋 Requisitos

- Conhecimentos básicos em:
  - **C#**
  - **HTML, CSS e JavaScript**
  - **SQL e Banco de Dados**
- Ferramentas instaladas:
  - **Node.js** e **npm**
  - **Angular CLI**
  - **.NET Core SDK**
  - Editor de código (ex.: **VS Code**)

## 🎯 Objetivos

- Criar uma **API RESTful** com boas práticas em **ASP.NET Core**.
- Implementar arquitetura **multi-camadas** no back-end.
- Construir uma aplicação web dinâmica com **Angular**.
- Funcionalidades como:
  - Upload de imagens
  - Paginação e filtros
  - Autenticação com **JWT**
  - Gerenciamento de entidades (ex.: palestrantes e redes sociais)
- Integração entre front-end e back-end.

## 🗂️ Estrutura

```plaintext
backend/    # Código da API (ASP.NET Core)
frontend/   # Aplicação web (Angular)
README.md   # Documentação do projeto
```
## 🚀 Execução
1. **Clone o repositório**  
```bash
git clone <URL-do-repositório>
cd <pasta-do-projeto>
```
- Crie um banco de dados MySQL.
- Configure as credenciais de acesso ao banco de dados no arquivo src/database/config/config.json.

2. **Configure o Back-End**
- Acesse backend/
- Configure o banco de dados no arquivo appsettings.json
- Execute o projeto:
  
```bash
git clone <URL-do-repositório>
cd <pasta-do-projeto>
```
3. **Configure o Front-End**
- Acesse frontend/
- Instale as dependências
 ```bash
npm install
```

- Execute o projeto:  
```bash
ng serve
```
4. Acesse a aplicação em: http://localhost:4200.  
Execute as migrations para criar as tabelas no banco de dados;

