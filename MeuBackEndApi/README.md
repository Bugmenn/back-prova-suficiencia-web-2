# Criar projeto back
ETAPA 1: Criar o back-end em ASP.NET Core

Abra o Visual Studio Community.

Vá em Criar um novo projeto.

Escolha ASP.NET Core Web API.

Clique em Avançar.

Dê um nome (ex: MeuBackEndApi), escolha uma pasta, clique em Criar.

Na próxima tela, selecione:

✅ Plataforma: .NET 6 ou superior

✅ Desmarque a opção "Enable OpenAPI" (se quiser deixar mais simples)

Clique em Criar

## adicionais
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add package BCrypt.Net-Next

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

## Especificações do projeto
Criado no visual studio community

Usado ASP.NET Core Web API

.NET versão 8.0

## gerar migração
dotnet ef migrations add 'NomeDaMigracao'

dotnet ef database update