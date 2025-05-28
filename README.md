# Sistema de Gestão de Inscrições - Vestibular

## Sobre o Projeto

Este é um projeto desenvolvido de forma pessoal com o objetivo de praticar e aperfeiçoar minhas habilidades em desenvolvimento backend com **.NET** e frontend com **React**. A aplicação simula um sistema de gestão de inscrições para um vestibular, permitindo realizar o controle completo dos candidatos, processos seletivos, ofertas e suas respectivas inscrições.

O projeto possui uma API robusta, seguindo boas práticas de desenvolvimento, e um frontend moderno e responsivo.

## Funcionalidades

 CRUD completo para as entidades:
- Candidato
- Processo Seletivo
- Oferta
- Inscrição

 Endpoints adicionais:
- Buscar inscrições por CPF (retorna todas as inscrições vinculadas ao CPF informado)
- Buscar inscrições por Oferta (retorna todas as inscrições associadas a uma oferta específica)

## Tecnologias Utilizadas

### Backend (.NET)
- C#
- .NET 8
- Entity Framework Core
- PostgreSQL
- API RESTful
- Swagger para documentação
- Arquitetura em camadas (Domain, Application, Infrastructure e Presentation)
- Repository Pattern + Unit of Work

### Frontend (React)
- ReactJS
- Vite
- TypeScript
- Axios
- Tailwind CSS
- React Hook Form

### Outros
- Docker (Containerização do Backend e Banco de Dados)

## Arquitetura do Projeto

O backend foi desenvolvido seguindo o conceito de **Clean Architecture**, separando claramente as responsabilidades em camadas:

- **Domain**: Entidades e regras de negócio
- **Application**: Casos de uso e serviços
- **Infrastructure**: Acesso a dados, configuração do banco e integrações
- **Api**: Controllers e endpoints da API

## Como Executar o Projeto

### Pré-requisitos
- .NET 8 SDK
- Node.js + NPM/Yarn

### Backend (.NET)
```bash
# Na raiz do projeto backend
dotnet restore
dotnet ef database update
dotnet run
