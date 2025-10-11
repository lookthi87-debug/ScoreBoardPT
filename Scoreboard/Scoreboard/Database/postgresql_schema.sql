-- PostgreSQL database schema for Scoreboard application

-- Create Users table
CREATE TABLE IF NOT EXISTS Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Name VARCHAR(100),
    createDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updateDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create Matches table
CREATE TABLE IF NOT EXISTS Matches (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255),
    Team1 VARCHAR(100),
    Team2 VARCHAR(100),
    Score1 INTEGER DEFAULT 0,
    Score2 INTEGER DEFAULT 0,
    SetsName VARCHAR(50),
    Sets INTEGER DEFAULT 1,
    StartTime VARCHAR(50),
    ElapsedSeconds INTEGER DEFAULT 0,
    IsPaused INTEGER DEFAULT 0,
    Status INTEGER DEFAULT 0,
    ShowToggle BOOLEAN DEFAULT false,
    UserId INTEGER REFERENCES Users(Id),
    createDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updateDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create Settings table
CREATE TABLE IF NOT EXISTS Settings (
    Key VARCHAR(100) PRIMARY KEY,
    Value TEXT,
    createDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updateDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Trigger function to update updateDate column
CREATE OR REPLACE FUNCTION update_updateDate_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updateDate = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Add triggers for each table
CREATE TRIGGER set_updateDate_users
BEFORE UPDATE ON Users
FOR EACH ROW
EXECUTE PROCEDURE update_updateDate_column();

CREATE TRIGGER set_updateDate_matches
BEFORE UPDATE ON Matches
FOR EACH ROW
EXECUTE PROCEDURE update_updateDate_column();

CREATE TRIGGER set_updateDate_settings
BEFORE UPDATE ON Settings
FOR EACH ROW
EXECUTE PROCEDURE update_updateDate_column();