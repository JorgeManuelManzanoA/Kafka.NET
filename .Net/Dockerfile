# Usar la imagen oficial de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Crear un nuevo proyecto de consola .NET directamente en el contenedor
RUN dotnet new console -o KafkaHelloWorld
WORKDIR /app/KafkaHelloWorld

# Agregar el paquete NuGet de Kafka
RUN dotnet add package Confluent.Kafka

# Copiar el archivo de código del proyecto
COPY Program.cs .

# Compilar y publicar la aplicación
RUN dotnet publish -c Release -o out

# Usar la imagen de .NET Runtime para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/KafkaHelloWorld/out .

# Configurar el punto de entrada
ENTRYPOINT ["dotnet", "KafkaHelloWorld.dll"]

