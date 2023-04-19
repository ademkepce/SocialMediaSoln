FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY ./Onion/Core/SocialMediaSoln.Application/*.csproj ./SocialMediaSoln.Application/
COPY ./Onion/Core/SocialMediaSoln.Domain/*.csproj ./SocialMediaSoln.Domain/
COPY ./Onion/Infrastructure/SocialMediaSoln.Persistence/*.csproj ./SocialMediaSoln.Persistence/
COPY ./Onion/Presentation/SocialMediaSoln.API/*.csproj ./SocialMediaSoln.API/
COPY *.sln .
RUN dotnet Restore
COPY . .
RUN dotnet publish ./Onion/Presentation/SocialMediaSoln.API/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","SocialMediaSoln.API.dll"]