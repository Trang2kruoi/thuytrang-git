FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/thuytrang.Web.Host/thuytrang.Web.Host.csproj", "src/thuytrang.Web.Host/"]
COPY ["src/thuytrang.Web.Core/thuytrang.Web.Core.csproj", "src/thuytrang.Web.Core/"]
COPY ["src/thuytrang.Application/thuytrang.Application.csproj", "src/thuytrang.Application/"]
COPY ["src/thuytrang.Core/thuytrang.Core.csproj", "src/thuytrang.Core/"]
COPY ["src/thuytrang.EntityFrameworkCore/thuytrang.EntityFrameworkCore.csproj", "src/thuytrang.EntityFrameworkCore/"]
WORKDIR "/src/src/thuytrang.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/thuytrang.Web.Host", "src/thuytrang.Web.Host"]
COPY ["src/thuytrang.Web.Core", "src/thuytrang.Web.Core"]
COPY ["src/thuytrang.Application", "src/thuytrang.Application"]
COPY ["src/thuytrang.Core", "src/thuytrang.Core"]
COPY ["src/thuytrang.EntityFrameworkCore", "src/thuytrang.EntityFrameworkCore"]
WORKDIR "/src/src/thuytrang.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "thuytrang.Web.Host.dll"]
