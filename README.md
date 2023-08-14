# ExpensesApi

This api was built in collaboration with vibbra to manage billed accounts.

## Requirements

- DotNet Core SDK 5
- Docker
- VS Code
    - Extensions
        - SQL Server

## Optional requirements

- Windows Terminal

## Install

<aside>
💡 Note: On Windows preferencially use powershell
</aside>  

Windows Terminal

```bash
winget install -e --id Microsoft.WindowsTerminal
```

.Net Core SDK

```bash
winget install -e --id Microsoft.DotNet.SDK.5
```

Docker

```bash
winget install -e --id Docker.DockerDesktop
```

VS Code

```bash
winget install -e --id Microsoft.VisualStudioCode
```

Configure https cert

```bash
dotnet dev-certs https --clean;
dotnet dev-certs https -ep $env:userprofile\.aspnet\https\aspnetapp.pfx -p password123;
dotnet dev-certs https --trust
```

creating docker volume

```bash
mkdir c:/data;
```
## Executing on Docker

<aside>
💡 Note: review and configure docker environment variables
</aside>  

```bash
docker-compose up -d --build
```

After the execution, access endpoints through Swagger:

[https://localhost:5001/swagger](https://localhost:5001/swagger)
