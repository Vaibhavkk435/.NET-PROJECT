FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Food-Delivery/Food-Delivery.csproj", "Food-Delivery/"]
RUN dotnet restore "Food-Delivery/Food-Delivery.csproj"
COPY . .
WORKDIR "/src/Food-Delivery"
RUN dotnet build "Food-Delivery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Food-Delivery.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables for production
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

ENTRYPOINT ["dotnet", "Food-Delivery.dll"]
