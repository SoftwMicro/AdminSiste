# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o csproj e restaura dependências
COPY ["AdminSiste.csproj", "./"]
RUN dotnet restore "./AdminSiste.csproj"

# Copia todo o código e publica a aplicação
COPY . .
RUN dotnet publish "AdminSiste.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Porta padrão do ASP.NET Core
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "AdminSiste.dll"]
