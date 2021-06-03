FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
COPY ./Rettsjekk-Register.csproj .
RUN dotnet restore 
COPY . .
RUN dotnet publish -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "Rettsjekk-Register.dll"]