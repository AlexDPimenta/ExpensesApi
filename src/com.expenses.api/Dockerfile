#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["com.expenses.api/com.expenses.api.csproj", "com.expenses.api/"]
COPY ["com.expenses.datacomunication/com.expenses.datacomunication.csproj", "com.expenses.datacomunication/"]
COPY ["com.expenses.domain/com.expenses.domain.csproj", "com.expenses.domain/"]
COPY ["com.expenses.infra/com.expenses.infra.csproj", "com.expenses.infra/"]
COPY ["com.expenses.service/com.expenses.service.csproj", "com.expenses.service/"]
COPY ["com.expenses.tools/com.expenses.tools.csproj", "com.expenses.tools/"]
RUN dotnet restore "TesteVibbra/com.expenses.api.csproj"
COPY . .
WORKDIR "/src/com.expenses.api"
RUN dotnet build "com.expenses.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "com.expenses.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "com.expenses.api.dll"]