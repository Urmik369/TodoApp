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

## Notes & Troubleshooting
- If you see errors about a locked `TodoApp.exe` when building, ensure no previous `dotnet run` process is still running. Stop it or kill the `TodoApp` process:

```powershell
Get-Process -Name TodoApp -ErrorAction SilentlyContinue | Stop-Process -Force
```

- If you see data protection / session cookie errors after restarting the app, delete the temporary SQLite files in the project root: `todo.db-shm` and `todo.db-wal` (they will be recreated).

- The app stores the SQLite DB in the project folder as `todo.db`. If you want a fresh database, delete `todo.db` and the `Migrations` can recreate schema on first run if migrations/DB creation are wired.

- Add generated files and the database to `.gitignore` to avoid committing runtime artifacts (recommend adding `bin/`, `obj/`, `todo.db*`).

## Next steps
- Add automated tests for controller behavior (ownership checks for Edit/Delete).
- Add a `.gitignore` and CI configuration if you plan to push to a remote repository.

If you'd like, I can add a `.gitignore` now and commit it.