# Step 1: Build the application
# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
# Set the working directory in the container
WORKDIR /app
# Copy the project files
# Copy the project files and restore dependencies
COPY TripMatch.Xplore.Platform/*.csproj TripMatch.Xplore.Platform/
# Restore dependencies
RUN dotnet restore ./TripMatch.Xplore.Platform
# Copy the rest of the application files
COPY . .

# Step 2: Deploy the application to builder stage
# Publish the application in Release mode
RUN dotnet publish ./TripMatch.Xplore.Platform -c Release -o out

# Step 3: Publish to Production and Run the application
# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0
# Set the working directory in the container
WORKDIR /app
# Copy the published application from the builder stage
COPY --from=builder /app/out .
EXPOSE 80
# Set EntryPoint to run the application
ENTRYPOINT ["dotnet", "TripMatch.Xplore.Platform.dll"]
