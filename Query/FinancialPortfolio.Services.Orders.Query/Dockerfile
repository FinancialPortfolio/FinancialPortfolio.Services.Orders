FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Query/FinancialPortfolio.Services.Orders.Query/FinancialPortfolio.Services.Orders.Query.csproj", "FinancialPortfolio.Services.Orders.Query/"]
RUN dotnet restore "Query/FinancialPortfolio.Services.Orders.Query/FinancialPortfolio.Services.Orders.Query.csproj"
COPY . .
WORKDIR "/src/FinancialPortfolio.Services.Orders.Query"
RUN dotnet build "FinancialPortfolio.Services.Orders.Query.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinancialPortfolio.Services.Orders.Query.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialPortfolio.Services.Orders.Query.dll"]
