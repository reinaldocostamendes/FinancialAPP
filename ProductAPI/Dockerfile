#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
COPY ["BuyRequest_Application/BuyRequest_Application.csproj", "BuyRequest_Application/"]
COPY ["CashBook_API_Client/CashBook_API_Client.csproj", "CashBook_API_Client/"]
COPY ["CashBook.Domain/CashBookDomain.csproj", "CashBook.Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["BuyRequest.Domain/BuyRequestDomain.csproj", "BuyRequest.Domain/"]
RUN dotnet restore "ProductAPI/ProductAPI.csproj"
COPY . .
WORKDIR "/src/ProductAPI"
RUN dotnet build "ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAPI.dll"]