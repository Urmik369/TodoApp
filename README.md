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
   - Solution: Download and install .NET 8.0 SDK from [Microsoft's download page](https://dotnet.microsoft.com/download/dotnet/8.0)
   - Verify installation with: `dotnet --version`

2. **Database Migration Errors**
   - Error: "No migrations found" or "Build failed"
   - Solution:
     ```powershell
     dotnet tool install --global dotnet-ef
     dotnet ef database update
     ```
   - If error persists, try removing the existing database:
     ```powershell
     del todo.db
     dotnet ef database update
     ```

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