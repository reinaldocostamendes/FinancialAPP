#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CashBook_Api/CashBook_Api.csproj", "CashBook_Api/"]
COPY ["CashBook_Application/CashBook_Application.csproj", "CashBook_Application/"]
COPY ["CashBook.Domain/CashBookDomain.csproj", "CashBook.Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["CashBook_API_Client/CashBook_API_Client.csproj", "CashBook_API_Client/"]
RUN dotnet restore "CashBook_Api/CashBook_Api.csproj"
COPY . .
WORKDIR "/src/CashBook_Api"
RUN dotnet build "CashBook_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashBook_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashBook_Api.dll"]