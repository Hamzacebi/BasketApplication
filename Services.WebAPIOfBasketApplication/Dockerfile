FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services.WebAPIOfBasketApplication/Services.WebAPIOfBasketApplication.csproj", "Services.WebAPIOfBasketApplication/"]
RUN dotnet restore "Services.WebAPIOfBasketApplication/Services.WebAPIOfBasketApplication.csproj"
COPY . .
WORKDIR "/src/Services.WebAPIOfBasketApplication"
RUN dotnet build "Services.WebAPIOfBasketApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Services.WebAPIOfBasketApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Services.WebAPIOfBasketApplication.dll"]