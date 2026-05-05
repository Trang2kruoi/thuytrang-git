# 🔧 REVIEW FEATURE - COMMAND LINE CHEAT SHEET

## ⚡ QUICK COMMANDS

### 🏗️ BUILD COMMANDS

```powershell
# Build the entire solution
dotnet build

# Clean then build
dotnet clean
dotnet build

# Build specific project
dotnet build src/thuytrang.Web.Mvc

# Build with release configuration
dotnet build -c Release

# Rebuild everything
dotnet clean && dotnet build
```

### 🗄️ DATABASE COMMANDS

```powershell
# Update database (apply all pending migrations)
Update-Database

# Create new migration
Add-Migration YourMigrationName

# Remove last migration
Remove-Migration

# List all migrations
Get-Migration

# Revert to specific migration
Update-Database -TargetMigration "MigrationName"

# Drop entire database
Drop-Database

# View connection string
Get-DbContext
```

### 🚀 RUN COMMANDS

```powershell
# Run main project
dotnet run

# Run specific project
dotnet run --project src/thuytrang.Web.Mvc

# Run with debugging
dotnet run -- --debug

# Run on specific port
dotnet run --urls "http://localhost:5000"

# Run in background (PowerShell)
Start-Process dotnet "run --project src/thuytrang.Web.Mvc"
```

### 🧪 TEST COMMANDS

```powershell
# Run all tests
dotnet test

# Run specific test project
dotnet test src/thuytrang.Tests

# Run specific test class
dotnet test --filter "ClassName"

# Run specific test method
dotnet test --filter "ClassName.MethodName"

# Run with verbose output
dotnet test -v detailed

# Run tests in parallel
dotnet test -p:CollectCoverageIf=true
```

---

## 📋 STEP-BY-STEP WORKFLOW

### 🎯 First Time Setup

```powershell
# 1. Navigate to project folder
cd C:\Users\Lenovo\Downloads\thuytrang\9.4.2\aspnet-core\

# 2. Build the solution
dotnet build

# 3. Update database (creates tables)
Update-Database

# 4. Navigate to web project
cd src/thuytrang.Web.Mvc

# 5. Run the application
dotnet run

# 6. Open browser
# http://localhost:5000/Review
```

### 🔄 Daily Development

```powershell
# 1. Make code changes
# 2. Build
dotnet build

# 3. If database changes, create migration
Add-Migration FeatureName

# 4. Apply migration
Update-Database

# 5. Run app
dotnet run

# 6. Test in browser
# http://localhost:5000/Review
```

### 🧹 Clean Up

```powershell
# Remove build artifacts
dotnet clean

# Remove database
Drop-Database

# Remove migrations
Remove-Migration -Force
```

---

## 🔍 DEBUGGING COMMANDS

### Visual Studio Package Manager Console

```powershell
# Set default project to src/thuytrang.EntityFrameworkCore
# (Important for migrations to work correctly)

# Check migrations status
Get-Migrations

# See pending migrations
Get-Migrations | Where-Object { $_.Name -match "Review" }

# Get database context info
Get-DbContext
```

### PowerShell Troubleshooting

```powershell
# Check if dotnet is installed
dotnet --version

# Check .NET runtimes available
dotnet --list-runtimes

# Check .NET SDKs available
dotnet --list-sdks

# Get help for any command
dotnet help
dotnet build --help
```

---

## 📦 NuGet COMMANDS

```powershell
# List packages in solution
Get-Package -ListAvailable

# Update NuGet packages
Update-Package

# Update specific package
Update-Package EntityFrameworkCore

# Install specific version
Install-Package EntityFrameworkCore -Version 8.0.0

# Remove package
Uninstall-Package PackageName
```

---

## 🚨 COMMON ISSUES & SOLUTIONS

### ❌ Issue: "Build Failed"

```powershell
# Solution 1: Clean and rebuild
dotnet clean
dotnet build

# Solution 2: Check dependencies
dotnet restore

# Solution 3: Update NuGet
Update-Package -Reinstall
```

### ❌ Issue: "Migration Failed"

```powershell
# Solution 1: Set correct default project
# (In PMC: set EntityFrameworkCore project as default)

# Solution 2: Remove failed migration
Remove-Migration

# Solution 3: Fresh migration
Add-Migration InitialCreate
Update-Database
```

### ❌ Issue: "Port Already in Use"

```powershell
# Solution 1: Use different port
dotnet run --urls "http://localhost:5001"

# Solution 2: Kill process using port
netstat -ano | findstr :5000
taskkill /PID <PID> /F

# Solution 3: Wait and try again
# (Sometimes port takes time to release)
```

### ❌ Issue: "Database Connection Failed"

```powershell
# Solution 1: Check connection string
# (In appsettings.json or appsettings.Development.json)

# Solution 2: Verify SQL Server running
# (Open SQL Server Management Studio)

# Solution 3: Reset database
Drop-Database
Update-Database
```

---

## 🎯 MONITORING COMMANDS

### Check Application Status

```powershell
# While app is running in another terminal:

# Check if port is listening
netstat -ano | findstr :5000

# Check running processes
Get-Process | grep dotnet

# View application logs
# (Check Console window of running app)
```

### Database Status

```powershell
# Check database exists
# Open SQL Server Management Studio
# Look for: Review table under Master/YourDb

# SQL Query to verify
# (In SQL Server Management Studio)
SELECT TOP 10 * FROM Reviews;
```

---

## 📝 SCRIPT TEMPLATES

### One-Command Setup

```powershell
# Copy this entire command to run everything at once:
dotnet clean; dotnet build; Update-Database; cd src/thuytrang.Web.Mvc; dotnet run
```

### Batch File (for Windows)

```batch
@echo off
echo Building solution...
dotnet build

echo.
echo Updating database...
REM Run in PMC or use this workaround:
echo Please run: Update-Database
pause

echo.
echo Starting application...
cd src\thuytrang.Web.Mvc
dotnet run

pause
```

### PowerShell Script

```powershell
# Save as build.ps1
param(
	[string]$action = "build"
)

switch($action) {
	"build" { 
		Write-Host "Building..." -ForegroundColor Green
		dotnet build 
	}
	"run" { 
		Write-Host "Running..." -ForegroundColor Green
		dotnet run 
	}
	"clean" { 
		Write-Host "Cleaning..." -ForegroundColor Yellow
		dotnet clean 
	}
	"test" { 
		Write-Host "Testing..." -ForegroundColor Cyan
		dotnet test 
	}
}
```

---

## 🌐 URL REFERENCE

### Development URLs

```
Main App:           http://localhost:5000
Review Page:        http://localhost:5000/Review
API Base:           http://localhost:5000/api
Review API:         http://localhost:5000/api/services/app/review
Create/Edit:        /api/services/app/review/createOrEdit (POST)
Get All:            /api/services/app/review/getAll (GET)
Get Single:         /api/services/app/review/get (GET)
Delete:             /api/services/app/review/delete (DELETE)
```

### Useful Developer Tools

```
F12 Developer Tools:    Press F12 in browser
- Console:              See errors and logs
- Network:              See API calls
- Application:          See cached data

SQL Server Management:  Connect to database
- Database:             See tables
- Queries:              Run SQL commands
```

---

## 📚 HELPFUL RESOURCES

```powershell
# .NET Documentation
Start-Process "https://learn.microsoft.com/dotnet/"

# Entity Framework
Start-Process "https://learn.microsoft.com/ef/"

# ABP Framework
Start-Process "https://docs.abp.io/"

# ASP.NET Core
Start-Process "https://learn.microsoft.com/aspnet/core/"
```

---

## ✅ COMMAND CHEAT SHEET

| Task | Command |
|------|---------|
| Build | `dotnet build` |
| Clean | `dotnet clean` |
| Run | `dotnet run` |
| Test | `dotnet test` |
| DB Update | `Update-Database` |
| DB Migrate | `Add-Migration Name` |
| Package List | `Get-Package` |
| Package Update | `Update-Package` |
| Restore | `dotnet restore` |

---

## 🎓 BEST PRACTICES

### ✅ DO:
```powershell
# Do clean before rebuilding
dotnet clean
dotnet build

# Do use descriptive migration names
Add-Migration AddReviewFeature

# Do check status before deploying
dotnet build
dotnet test

# Do use specific project names
dotnet build src/thuytrang.Web.Mvc
```

### ❌ DON'T:
```powershell
# Don't run multiple dotnet processes on same port
# Don't skip Update-Database when schema changes
# Don't commit build artifacts to git
# Don't hardcode passwords in appsettings.json
```

---

## 🆘 EMERGENCY COMMANDS

```powershell
# If everything breaks, try this sequence:

# 1. Stop all dotnet processes
Get-Process | Where-Object {$_.Name -eq "dotnet"} | Stop-Process

# 2. Clean everything
dotnet clean

# 3. Remove build cache
Remove-Item -Recurse -Force bin
Remove-Item -Recurse -Force obj

# 4. Restore
dotnet restore

# 5. Build fresh
dotnet build

# 6. Reset database
Drop-Database
Update-Database

# 7. Run
dotnet run
```

---

## 📞 QUICK HELP

### Get Help for Commands
```powershell
dotnet --help
dotnet build --help
dotnet run --help
Get-Help Update-Database
```

### Check Installed Versions
```powershell
dotnet --version         # .NET version
dotnet --list-runtimes   # Available runtimes
dotnet --list-sdks       # Available SDKs
```

---

**Happy Coding!** 🚀

**Last Updated**: 2024
**Status**: ✅ Ready to Use
