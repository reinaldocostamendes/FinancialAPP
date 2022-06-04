#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Document_Api/Document_Api.csproj", "Document_Api/"]
COPY ["CashBook_API_Client/CashBook_API_Client.csproj", "CashBook_API_Client/"]
COPY ["CashBook.Domain/CashBookDomain.csproj", "CashBook.Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Document_Application/Document_Application.csproj", "Document_Application/"]
COPY ["Document.Domain/DocumentDomain.csproj", "Document.Domain/"]
RUN dotnet restore "Document_Api/Document_Api.csproj"
COPY . .
WORKDIR "/src/Document_Api"
RUN dotnet build "Document_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Document_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Document_Api.dll"]