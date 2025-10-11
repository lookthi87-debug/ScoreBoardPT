# Project Structure

This document describes the organized structure of the Scoreboard application.

## Directory Structure

```
Scoreboard/
├── Scoreboard.sln                 # Solution file
├── Scoreboard/                    # Main project directory
│   ├── Scoreboard.csproj          # Project file
│   ├── Program.cs                 # Application entry point
│   ├── packages.config            # NuGet package references
│   ├── scoreboard.db              # SQLite database (deprecated)
│   ├── README.txt                 # Project README
│   ├── Properties/                # Project properties
│   │   ├── Resources.Designer.cs
│   │   └── Resources.resx
│   ├── Database/                  # Database access layer
│   │   ├── Repository.cs          # Data access methods
│   │   ├── PostgreSQLHelper.cs    # PostgreSQL connection helper
│   │   └── postgresql_schema.sql  # PostgreSQL database schema
│   ├── Utilities/                 # Utility classes
│   │   └── Security.cs            # Password hashing/verification
│   ├── Models/                    # Data models
│   │   ├── User.cs                # User model
│   │   ├── MatchModel.cs          # Match model
│   │   └── MatchState.cs          # Match state model
│   ├── Forms/                     # Windows Forms
│   │   ├── LoginForm.cs           # Login form
│   │   ├── AdminForm.cs           # Admin dashboard
│   │   ├── MainForm.cs            # Main user interface
│   │   ├── AddUpdateMatchs.cs     # Add/update matches form
│   │   ├── AddUserDialog.cs       # Add user dialog
│   │   ├── MultiSelectDialog.cs   # Multi-select dialog
│   │   ├── Toggle.cs              # Toggle form
│   ├── UserControls/              # Custom user controls
│   │   ├── ucFormView_Toggle.cs   # Toggle user control
│   │   ├── ucFormView_User.cs     # User view user control
│   └── bin/                       # Compiled output
└── .vs/                           # Visual Studio files
```

## Key Improvements

1. **Separated Models**: Moved data models (User, MatchModel, MatchState) to their own directory for better organization
2. **Logical Grouping**: Organized files into meaningful directories based on their function
3. **Database Migration**: Migrated from SQLite to PostgreSQL for better scalability
4. **Maintained References**: All existing code references to models continue to work without changes

## Namespace Structure

All classes maintain their original namespaces to ensure compatibility:
- Database access: `Scoreboard.Database`
- Models: `Scoreboard.Database` (User, MatchModel, MatchState)
- Forms: `Scoreboard`
- Utilities: `Scoreboard.Utilities`

## Database Configuration

The application now uses PostgreSQL instead of SQLite. You need to:

1. Install PostgreSQL server
2. Create a database named "scoreboard"
3. Execute the SQL script in `Database/postgresql_schema.sql` to create tables
4. Update the connection parameters in `Database/PostgreSQLHelper.cs`:
   - Host: localhost (or your PostgreSQL server address)
   - Port: 5432 (default PostgreSQL port)
   - Database: scoreboard
   - Username: postgres (or your PostgreSQL username)
   - Password: postgres (or your PostgreSQL password)

This structure makes the codebase easier to navigate and maintain while preserving all existing functionality.