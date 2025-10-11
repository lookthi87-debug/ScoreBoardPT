# ScoreBoardPT

Scoreboard application for managing sports matches with a clean UI.

## Project Structure

```
ScoreBoardPT/
├── README.md
└── Scoreboard/
    ├── Scoreboard.sln
    ├── Scoreboard/
    │   ├── Scoreboard.csproj
    │   ├── Program.cs
    │   ├── packages.config
    │   ├── scoreboard.db
    │   ├── README.txt
    │   ├── Properties/
    │   │   ├── Resources.Designer.cs
    │   │   └── Resources.resx
    │   ├── Database/
    │   │   ├── Repository.cs
    │   │   ├── PostgreSQLHelper.cs
    │   │   └── postgresql_schema.sql
    │   ├── Utilities/
    │   │   └── Security.cs
    │   ├── Models/
    │   │   ├── User.cs
    │   │   ├── MatchModel.cs
    │   │   └── MatchState.cs
    │   ├── Forms/
    │   │   ├── LoginForm.cs
    │   │   ├── LoginForm.resx
    │   │   ├── AdminForm.cs
    │   │   ├── AdminForm.resx
    │   │   ├── MainForm.cs
    │   │   ├── MainForm.resx
    │   │   ├── AddUpdateMatchs.cs
    │   │   ├── AddUpdateMatchs.resx
    │   │   ├── AddUserDialog.cs
    │   │   ├── AddUserDialog.resx
    │   │   ├── MultiSelectDialog.cs
    │   │   ├── Toggle.cs
    │   │   └── Toggle.resx
    │   ├── UserControls/
    │   │   ├── ucFormView_Toggle.cs
    │   │   ├── ucFormView_Toggle.Designer.cs
    │   │   ├── ucFormView_Toggle.resx
    │   │   ├── ucFormView_User.cs
    │   │   ├── ucFormView_User.Designer.cs
    │   │   └── ucFormView_User.resx
    │   └── bin/
    │       └── (compiled output)
    └── .vs/
        └── (Visual Studio files)
```

## Getting Started

1. Install PostgreSQL database server
2. Create a database named "scoreboard"
3. Execute the SQL script in `Database/postgresql_schema.sql` to create tables
4. Update the connection settings in `Database/PostgreSQLHelper.cs` if needed
5. Open `Scoreboard.sln` in Visual Studio
6. Restore NuGet packages
7. Build the solution
8. Run the application

Default admin credentials: admin/admin123

## Database Configuration

The application now uses PostgreSQL instead of SQLite. You need to:

1. Install PostgreSQL server
2. Create a database named "scoreboard"
3. Update the connection parameters in `Database/PostgreSQLHelper.cs`:
   - Host: localhost (or your PostgreSQL server address)
   - Port: 5432 (default PostgreSQL port)
   - Database: scoreboard
   - Username: postgres (or your PostgreSQL username)
   - Password: postgres (or your PostgreSQL password)