# TodoApp - Task Management Application

A full-featured task management application built with ASP.NET Core MVC and Entity Framework Core. This application allows users to create, manage, and track their todo items with secure user authentication and authorization.

## 📸 Screenshots

### Login Page
![Login Page](https://github.com/Urmik369/TodoApp/blob/main/screenshots/login.png)

### Task List (My Tasks)
![Task List](https://github.com/Urmik369/TodoApp/blob/main/screenshots/task-list.png)

### Add New Task
![Add Task](https://github.com/Urmik369/TodoApp/blob/main/screenshots/add-task.png)

### Task with Actions
![Task Actions](https://github.com/Urmik369/TodoApp/blob/main/screenshots/task-actions.png)

## ✨ Features

- 🔐 User Authentication & Registration
- ✅ Create, Read, Update, and Delete (CRUD) operations for todo items
- 🔒 Secure data access (users can only manage their own tasks)
- 📱 Responsive design using Bootstrap
- 💾 SQLite database for data storage
- 🚀 Modern ASP.NET Core architecture

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (Required)
- [Visual Studio Code](https://code.visualstudio.com/) (Recommended)
- [Git](https://git-scm.com/downloads) (For version control)

### Required VS Code Extensions

Install these extensions for the best development experience:

1. **C#** (Microsoft) - C# language support
2. **SQLite Viewer** - View and edit SQLite databases

**To install extensions via Command Line:**
```bash
code --install-extension ms-dotnettools.csharp
code --install-extension alexcvzz.vscode-sqlite
```

**Or install manually in VS Code:**
1. Press `Ctrl+Shift+X` (Windows/Linux) or `Cmd+Shift+X` (Mac)
2. Search for the extension name
3. Click "Install"

### Optional Recommended Extensions

- **C# Dev Kit** (Microsoft) - Additional C# development tools
- **NuGet Package Manager** - For managing packages via GUI
- **.NET Install Tool** - For managing .NET SDK versions

## 🚀 Installation & Setup

### Step 1: Clone the Repository

Open your terminal (PowerShell, Command Prompt, or VS Code integrated terminal) and run:

```bash
git clone https://github.com/Urmik369/TodoApp.git
cd TodoApp
```

### Step 2: Open in VS Code

```bash
code .
```

Or manually: File → Open Folder → Select the TodoApp folder

### Step 3: Verify .NET Installation

Open the integrated terminal in VS Code (`Ctrl+` ` or View → Terminal) and check your .NET version:

```bash
dotnet --version
```

You should see version 8.0.x or higher. If not, download and install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

### Step 4: Install Entity Framework Core Tools

```bash
dotnet tool install --global dotnet-ef
```

Verify installation:

```bash
dotnet ef --version
```

### Step 5: Restore Dependencies

```bash
dotnet restore
```

### Step 6: Install Required NuGet Packages

The following packages are required for this application:

```bash
# SQLite Database Support
dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Authentication
dotnet add package Microsoft.AspNetCore.Authentication.Cookies
```

**Note:** If these packages are already in your `.csproj` file, `dotnet restore` will install them automatically.

### Step 7: Build the Project

```bash
dotnet build
```

### Step 8: Create/Update Database

The database will be created automatically on first run, but you can manually create it:

```bash
dotnet ef database update
or
dotnet ef database update --context ApplicationDbContext
```

### Step 9: Run the Application

```bash
dotnet run
```

Or press `F5` in VS Code to run with debugging.

### Step 10: Access the Application

Open your browser and navigate to:
- HTTPS: `https://localhost:7260`
- HTTP: `http://localhost:5051`

The exact ports will be displayed in the terminal output.

## 🎯 Quick Start Commands (VS Code Terminal)

### Complete Installation (Copy & Paste All)

```bash
# Clone and setup
git clone https://github.com/Urmik369/TodoApp.git
cd TodoApp
code .

# Install VS Code extensions (run from terminal)
code --install-extension ms-dotnettools.csharp
code --install-extension alexcvzz.vscode-sqlite

# Install EF Core tools (one-time)
dotnet tool install --global dotnet-ef

# Restore dependencies
dotnet restore

# Install required packages (if not already in project)
dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Authentication.Cookies

# Build and run
dotnet build
dotnet ef database update
or
dotnet ef database update --context ApplicationDbContext
dotnet run
```

### Just Run (If Already Set Up)

```bash
cd TodoApp
dotnet run
```

## 📁 Project Structure

```
TodoApp/
├── Controllers/         # MVC Controllers
├── Models/             # Data models
├── Views/              # Razor views
├── Data/               # Database context
├── Migrations/         # EF Core migrations
├── wwwroot/           # Static files (CSS, JS, images)
├── appsettings.json   # Configuration
├── Program.cs         # Application entry point
└── todo.db           # SQLite database (created on first run)
```

## 🔧 Common VS Code Tasks

### Running the Application

**Option 1: Using Terminal**
```bash
dotnet run
```

**Option 2: Using Debug (F5)**
1. Press `F5` or click Run → Start Debugging
2. Select ".NET Core" if prompted
3. The app will start with debugging enabled

### Stopping the Application

- Terminal: Press `Ctrl+C`
- Debug: Press `Shift+F5` or click the red stop button

### Hot Reload (Development)

```bash
dotnet watch run
```

This automatically reloads the app when you save changes.

## 🐛 Troubleshooting

### Installation Issues

#### .NET SDK Version Mismatch

**Errors:**
- "The current .NET SDK does not support targeting .NET 8.0"
- "It was not possible to find any installed .NET Core SDKs"
- "NETSDK1045: The current .NET SDK does not support targeting .NET 8.0"

**Solutions:**

1. Check installed .NET versions:
```bash
dotnet --list-sdks
dotnet --list-runtimes
```

2. Download and install [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

3. Verify installation:
```bash
dotnet --version
```

4. If multiple SDKs are installed, specify version in global.json:
```bash
dotnet new globaljson --sdk-version 8.0.0
```

5. If error persists, repair/reinstall .NET SDK:
   - Windows: Use "Apps & features" to repair/uninstall
   - Then install fresh from Microsoft's website

#### Entity Framework Tools Missing

**Errors:**
- "No executable found matching command 'dotnet-ef'"
- "The EF Core tools version '8.0.0' is older than the targeted runtime"

**Solutions:**
```bash
# Install EF Core tools globally
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef

# Verify installation
dotnet ef --version
```

#### SSL Certificate Issues

**Errors:**
- "Unable to verify the first certificate"
- "SSL connection could not be established"

**Solutions:**
```bash
# Trust the development certificate
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

- If using Chrome/Edge, clear browser cache and restart
- If using Firefox, manually add security exception

#### Database Migration Errors

**Errors:**
- "No migrations found" or "Build failed"
- "The migration 'XXXXXXXX' has already been applied"
- "SQLite Error 1: 'no such table: __EFMigrationsHistory'"

**Solutions:**

1. First, ensure EF tools are installed:
```bash
dotnet tool install --global dotnet-ef
```

2. If migrations exist but database is corrupted:
```bash
del todo.db
del todo.db-shm
del todo.db-wal
dotnet ef database update
```

3. If migrations are corrupted:
```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. If still getting errors, complete reset:
```bash
del todo.db*
del Migrations\*.cs
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Database Connection Errors

**Errors:**
- "SQLite Error 14: 'unable to open database file'"
- "Microsoft.Data.Sqlite.SqliteException: SQLite Error 8: 'attempt to write a readonly database'"

**Solutions:**

1. Check file permissions:
```bash
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

#### Application Won't Start

**Error:** "Address already in use"

**Solution:** Stop existing instances:
```bash
Get-Process -Name TodoApp -ErrorAction SilentlyContinue | Stop-Process -Force
```

#### Login Not Working

**Error:** "Invalid login attempt"

**Solutions:**
- Ensure you've registered an account first
- Check if database exists and has Users table
- Try registering a new account
- If issues persist, reset database:
```bash
del todo.db todo.db-shm todo.db-wal
dotnet ef database update
```

#### Session/Cookie Issues

**Errors:**
- "Data protection error"
- "Unable to validate login"

**Solution:** Clear temporary database files:
```bash
del todo.db-shm todo.db-wal
```
Stop the application and restart

#### Database Locked

**Errors:**
- "Database is locked"
- "SQLite Error 5"

**Solution:**
```bash
Get-Process -Name TodoApp -ErrorAction SilentlyContinue | Stop-Process -Force
del todo.db-shm todo.db-wal
```

#### Permission Issues

**Errors:**
- "Access denied"
- "Cannot create file"

**Solution:** Run PowerShell as Administrator or ensure write permissions in the project folder

### Data Issues

#### Lost Tasks/Data

- The app uses SQLite database stored as `todo.db`
- To backup data: Copy `todo.db` to a safe location
- To reset database:
```bash
del todo.db*
dotnet ef database update
```

### Build Issues

#### Compilation Errors

**First try:**
```bash
dotnet restore
dotnet clean
dotnet build
```

**If errors persist, check:**
- .NET SDK version matches (8.0)
- All required packages are restored
- No syntax errors in modified files

#### Package Reference Errors

**Solution:**
```bash
dotnet restore --force
```

---

### 🆘 Still Having Issues?

If you encounter any other problems:

1. Ensure all prerequisites are installed
2. Try cleaning the solution and rebuilding
3. Check the application logs
4. Create an issue on the [GitHub repository](https://github.com/Urmik369/TodoApp/issues) with:
   - Error message
   - Steps to reproduce
   - .NET version (`dotnet --version`)
   - Operating system

## 💡 Development Tips

### Using VS Code Terminal Efficiently

1. **Open multiple terminals:** Click the "+" button in the terminal panel
2. **Split terminal:** Click the split terminal icon
3. **Toggle terminal:** Press `` Ctrl+` ``

### Useful VS Code Shortcuts

- `F5` - Start debugging
- `Ctrl+Shift+B` - Build
- `Ctrl+` ` - Toggle terminal
- `Ctrl+P` - Quick file open
- `Ctrl+Shift+P` - Command palette

### NuGet Package Management in VS Code

**Via Terminal:**
```bash
# Add a package
dotnet add package PackageName

# Remove a package
dotnet remove package PackageName

# List packages
dotnet list package
```

**Via Extension:**
1. Install "NuGet Package Manager" extension
2. Press `Ctrl+Shift+P`
3. Type "NuGet" and select package management option

## 📦 Database Management

### View Database Contents

#### Option 1: Using DB Browser for SQLite (Recommended)

**Step 1: Install DB Browser for SQLite**

If not installed:
1. Go to https://sqlitebrowser.org/dl/
2. Download the Windows (64-bit) installer
3. Install it (next → next → finish)

**Step 2: Open Your Database**

1. Open DB Browser for SQLite
2. Click **"Open Database"**
3. Browse to your database file:
```
C:\Users\YOUR_USERNAME\TodoApp\todo.db
```
Replace `YOUR_USERNAME` with your actual Windows username

4. Click **Open**

**Step 3: View the Data**

- Go to the **"Browse Data"** tab
- In the Table dropdown, you'll see:
  - `Users` - All registered users
  - `TodoItems` - All tasks
- Select a table to view its records

**Step 4: (Optional) Run SQL Commands**

Go to the **"Execute SQL"** tab to run commands manually:

```sql
-- View all users
SELECT * FROM Users;

-- View all todo items
SELECT * FROM TodoItems;

-- View tasks with user information
SELECT t.*, u.Username 
FROM TodoItems t 
JOIN Users u ON t.UserId = u.Id;
```

#### Option 2: Using SQLite Viewer Extension in VS Code

1. Install the **SQLite Viewer** extension in VS Code
2. Open Extensions (`Ctrl+Shift+X`)
3. Search "SQLite Viewer"
4. Install it
5. Right-click `todo.db` → **"Open Database"**

### Backup Database

```bash
# Windows
Copy-Item todo.db todo.db.backup

# Linux/Mac
cp todo.db todo.db.backup
```

### Reset Database

```bash
# Delete database
Remove-Item todo.db* -Force  # Windows
rm -f todo.db*               # Linux/Mac

# Recreate from migrations
dotnet ef database update
```

## 📚 Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [VS Code C# Documentation](https://code.visualstudio.com/docs/languages/csharp)
- [.NET CLI Reference](https://docs.microsoft.com/dotnet/core/tools/)
