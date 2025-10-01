# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UsersAPI.Services/UsersAPI.Services.csproj", "UsersAPI.Services/"]
COPY ["UsersAPI.Infra.IoC/UsersAPI.Infra.IoC.csproj", "UsersAPI.Infra.IoC/"]
COPY ["UsersAPI.Application/UsersAPI.Application.csproj", "UsersAPI.Application/"]
COPY ["UsersAPI.Domain/UsersAPI.Domain.csproj", "UsersAPI.Domain/"]
COPY ["UsersAPI.Infra.Data/UsersAPI.Infra.Data.csproj", "UsersAPI.Infra.Data/"]
COPY ["UsersAPI.Infra.Messages/UsersAPI.Infra.Messages.csproj", "UsersAPI.Infra.Messages/"]
COPY ["UsersAPI.Infra.Security/UsersAPI.Infra.Security.csproj", "UsersAPI.Infra.Security/"]
RUN dotnet restore "./UsersAPI.Services/UsersAPI.Services.csproj"
COPY . .
WORKDIR "/src/UsersAPI.Services"
RUN dotnet build "./UsersAPI.Services.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsersAPI.Services.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsersAPI.Services.dll"]