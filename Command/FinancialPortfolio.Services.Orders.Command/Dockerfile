FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FinancialPortfolio.Services.Orders/Command/FinancialPortfolio.Services.Orders.Command/FinancialPortfolio.Services.Orders.Command.csproj", "Command/FinancialPortfolio.Services.Orders.Command/"]
COPY ["FinancialPortfolio.Services.Orders/Common/FinancialPortfolio.Services.Orders.Infrastructure/FinancialPortfolio.Services.Orders.Infrastructure.csproj", "Common/FinancialPortfolio.Services.Orders.Infrastructure/"]
COPY ["FinancialPortfolio.Services.Orders/Command/FinancialPortfolio.Services.Orders.Command.Application/FinancialPortfolio.Services.Orders.Command.Application.csproj", "Command/FinancialPortfolio.Services.Orders.Command.Application/"]
COPY ["FinancialPortfolio.Services.Orders/Common/FinancialPortfolio.Services.Orders.Domain/FinancialPortfolio.Services.Orders.Domain.csproj", "Common/FinancialPortfolio.Services.Orders.Domain/"]
COPY ["FinancialPortfolio.Services.Orders/Query/FinancialPortfolio.Services.Orders.Query.Application/FinancialPortfolio.Services.Orders.Query.Application.csproj", "Query/FinancialPortfolio.Services.Orders.Query.Application/"]
COPY ["NugetPackages", "LocalNugetPackages"]
RUN dotnet restore -s LocalNugetPackages -s https://api.nuget.org/v3/index.json "Command/FinancialPortfolio.Services.Orders.Command/FinancialPortfolio.Services.Orders.Command.csproj"
COPY ./FinancialPortfolio.Services.Orders .
WORKDIR "/src/Command/FinancialPortfolio.Services.Orders.Command"
RUN dotnet build "FinancialPortfolio.Services.Orders.Command.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialPortfolio.Services.Orders.Command.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialPortfolio.Services.Orders.Command.dll"]
