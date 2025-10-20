# TodoApp

## Description
A full-featured task management application built with ASP.NET Core MVC and Entity Framework Core. This application allows users to create, manage, and track their todo items with secure user authentication and authorization.

### Features
- User Authentication & Registration
- Create, Read, Update, and Delete (CRUD) operations for todo items
- Secure data access (users can only manage their own tasks)
- Responsive design using Bootstrap
- SQLite database for data storage

## Installation
### Prerequisites
- .NET 8 SDK ([Download here](https://dotnet.microsoft.com/en-us/download))
- Visual Studio 2022 or Visual Studio Code (recommended)
- Git (for version control)

### Steps
1. Clone the repository:
   ```powershell
   git clone https://github.com/Urmik369/TodoApp.git
   cd TodoApp
   ```

2. Restore dependencies:
   ```powershell
   dotnet restore
   ```

3. Apply database migrations:
   ```powershell
   dotnet ef database update
   ```

## How to Run the Project
1. Open PowerShell in the project directory (where `TodoApp.csproj` is located)

2. Build the project:
   ```powershell
   dotnet build
   ```

3. Run the application:
   ```powershell
   dotnet run
   ```

4. Open your browser and navigate to the URL shown in the terminal (typically https://localhost:7260 or http://localhost:5051)

Visit the app in your browser at the URL shown in the terminal (usually `http://localhost:5048`).

## Common Issues & Troubleshooting

### Installation Issues
1. **.NET SDK Version Mismatch**
   - Error: "The current .NET SDK does not support targeting .NET 8.0"
   - Error: "It was not possible to find any installed .NET Core SDKs"
   - Error: "NETSDK1045: The current .NET SDK does not support targeting .NET 8.0"
   - Solutions:
     1. Check installed .NET versions:
        ```powershell
        dotnet --list-sdks
        dotnet --list-runtimes
        ```
     2. Download and install .NET 8.0 SDK from [Microsoft's download page](https://dotnet.microsoft.com/download/dotnet/8.0)
     3. Verify installation:
        ```powershell
        dotnet --version
        ```
     4. If multiple SDKs are installed, specify version in global.json:
        ```powershell
        dotnet new globaljson --sdk-version 8.0.0
        ```
     5. If error persists, repair/reinstall .NET SDK:
        - Windows: Use "Apps & features" to repair/uninstall
        - Then install fresh from Microsoft's website

2. **Entity Framework Tools Missing**
   - Error: "No executable found matching command 'dotnet-ef'"
   - Error: "The EF Core tools version '8.0.0' is older than the targeted runtime"
   - Solutions:
     ```powershell
     # Install EF Core tools globally
     dotnet tool uninstall --global dotnet-ef
     dotnet tool install --global dotnet-ef

     # Verify installation
     dotnet ef --version
     ```

3. **SSL Certificate Issues**
   - Error: "Unable to verify the first certificate" or "SSL connection could not be established"
   - Solutions:
     ```powershell
     # Trust the development certificate
     dotnet dev-certs https --clean
     dotnet dev-certs https --trust
     ```
     - If using Chrome/Edge, clear browser cache and restart
     - If using Firefox, manually add security exception

2. **Database Migration Errors**
   - Error: "No migrations found" or "Build failed"
   - Error: "The migration 'XXXXXXXX' has already been applied"
   - Error: "SQLite Error 1: 'no such table: __EFMigrationsHistory'"
   - Solutions:
     ```powershell
     # First, ensure EF tools are installed
     dotnet tool install --global dotnet-ef

     # If migrations exist but database is corrupted
     del todo.db
     del todo.db-shm
     del todo.db-wal
     dotnet ef database update

     # If migrations are corrupted
     dotnet ef migrations remove
     dotnet ef migrations add InitialCreate
     dotnet ef database update

     # If still getting errors, complete reset
     del todo.db*
     del Migrations\*.cs
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

3. **Database Connection Errors**
   - Error: "SQLite Error 14: 'unable to open database file'"
   - Error: "Microsoft.Data.Sqlite.SqliteException: SQLite Error 8: 'attempt to write a readonly database'"
   - Solutions:
     1. Check file permissions:
        ```powershell
        # Ensure current user has write permissions
        icacls . /grant "${env:USERNAME}:(OI)(CI)F"
        ```
     2. Check if antivirus is blocking:
        - Add project folder to exclusions
        - Temporarily disable real-time protection
     3. If using network drive:
        - Move project to local drive
        - Or configure SQLite for network share

### Runtime Issues
1. **Application Won't Start**
   - Error: "Address already in use"
   - Solution: Stop existing instances:
     ```powershell
     Get-Process -Name TodoApp -ErrorAction SilentlyContinue | Stop-Process -Force
     ```

2. **Login Not Working**
   - Error: "Invalid login attempt"
   - Solution: 
     - Ensure you've registered an account first
     - Check if database exists and has Users table
     - Try registering a new account
     - If issues persist, reset database:
       ```powershell
       del todo.db todo.db-shm todo.db-wal
       dotnet ef database update
       ```

3. **Session/Cookie Issues**
   - Error: "Data protection error" or "Unable to validate login"
   - Solution: Clear temporary database files:
     ```powershell
     del todo.db-shm todo.db-wal
     ```
   - Stop the application and restart

4. **Database Locked**
   - Error: "Database is locked" or "SQLite Error 5"
   - Solution:
     ```powershell
     Get-Process -Name TodoApp -ErrorAction SilentlyContinue | Stop-Process -Force
     del todo.db-shm todo.db-wal
     ```

5. **Permission Issues**
   - Error: "Access denied" or "Cannot create file"
   - Solution: Run PowerShell as Administrator or ensure write permissions in the project folder

### Data Issues
1. **Lost Tasks/Data**
   - The app uses SQLite database stored as `todo.db`
   - To backup data: Copy `todo.db` to a safe location
   - To reset database:
     ```powershell
     del todo.db*
     dotnet ef database update
     ```

### Build Issues
1. **Compilation Errors**
   - First try:
     ```powershell
     dotnet restore
     dotnet clean
     dotnet build
     ```
   - If errors persist, check:
     - .NET SDK version matches (8.0)
     - All required packages are restored
     - No syntax errors in modified files

2. **Package Reference Errors**
   - Solution:
     ```powershell
     dotnet restore --force
     ```

## Support
If you encounter any other issues:
1. Ensure all prerequisites are installed
2. Try cleaning the solution and rebuilding
3. Check the application logs
4. Create an issue on the GitHub repository with:
   - Error message
   - Steps to reproduce
   - .NET version (`dotnet --version`)
   - Operating system