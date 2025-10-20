# TodoApp

## Description
A simple ASP.NET Core MVC Todo application that supports user accounts, sessions, and CRUD operations for tasks. It uses SQLite as the database and Entity Framework Core for data access.

## Installation
Requirements:
- .NET 8 SDK installed (https://dotnet.microsoft.com/en-us/download)
- (Optional) A recent code editor like Visual Studio or VS Code

Steps:
1. Clone or copy the project to your machine.
2. Open a PowerShell terminal in the project root (where `TodoApp.csproj` is located).

## How to run the project (PowerShell)
Build the project:

```powershell
dotnet build "c:\Users\URMIK\TodoApp\TodoApp.csproj"
```

Run the project:

```powershell
dotnet run --project "c:\Users\URMIK\TodoApp\TodoApp.csproj"
```

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