FROM mcr.microsoft.com/dotnet/sdk:5.0 AS restore
WORKDIR /app

COPY Translaterr.Transman.sln .
COPY ./src/ ./src/
COPY ./tests/ ./tests/
RUN ["dotnet", "restore"]

FROM restore as build
RUN ["dotnet", "build", "--no-restore"]

FROM build as test
RUN ["dotnet", "test", "--no-restore", "--no-build"]

FROM build as publish
RUN ["dotnet", "publish", "--no-restore", "-c", "Release", "-o", "out", "./src/Translaterr.Transman.Api/Translaterr.Transman.Api.csproj"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime
COPY --from=publish /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Translaterr.Transman.Api.dll"]