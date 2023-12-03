
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
EXPOSE 6096

WORKDIR /src

COPY *.sln ./
COPY ./Presentation/*.csproj ./Presentation/
COPY ./Data/*.csproj ./Data/
COPY ./Business/*.csproj ./Business/
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /Presentation/app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env
WORKDIR /app

VOLUME ["/app-data"]

COPY --from=build-env /src/Presentation/bin/Release/net6.0/ .
COPY ./Data /app/Data

ENTRYPOINT ["dotnet", "App.Presentation.dll"]
