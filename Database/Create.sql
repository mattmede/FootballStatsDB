CREATE TABLE Users(
    User_Id INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL
);

CREATE TABLE Players(
    Player_Id INT IDENTITY(1,1) PRIMARY KEY,
    Player_Name VARCHAR(50) NOT NULL,
    Player_Number INT NOT NULL
);

CREATE TABLE Teams(
    Team_Id INT IDENTITY(1,1) PRIMARY KEY,
    Team_Name VARCHAR(50) NOT NULL
);

CREATE TABLE Fav_Player(
    FP_Id INT IDENTITY(1,1) PRIMARY KEY,
    Player_Id INT FOREIGN KEY REFERENCES Players(Player_Id) NOT NULL,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id) NOT NULL
);

CREATE TABLE Fav_Team(
    FT_Id INT IDENTITY(1,1) PRIMARY KEY,
    Team_Id INT FOREIGN KEY REFERENCES Teams(Team_Id) NOT NULL,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id) NOT NULL
);

CREATE TABLE Player_Stats(
    Player_Stat_Id INT IDENTITY(1,1) PRIMARY KEY,
    Week INT NOT NULL,
    Year INT NOT NULL,
    Rush_Yards INT,
    Pass_Yards INT,
    Receiving_Yards INT,
    TDs INT,
    Fumbles INT,
    Interceptions_Thrown INT,
    Tackles INT,
    Sacks INT,
    Forced_Fumbles INT,
    Interceptions INT
);

CREATE TABLE Team_Stats(
    Team_Stat_Id INT IDENTITY(1,1) PRIMARY KEY,
    Week INT NOT NULL,
    Year INT NOT NULL,
    Wins INT,
    Losses INT,
    Rush_Yards INT,
    Pass_Yards INT,
    Receiving_Yards INT,
    TDs INT,
    Sacks INT,
    Interceptions INT,
    Forced_Fumbles INT
);

CREATE TABLE Player_Plays(
    PP_Id INT IDENTITY(1,1) PRIMARY KEY,
    Player_Id INT FOREIGN KEY REFERENCES Players(Player_Id) NOT NULL,
    Player_Stat_Id INT FOREIGN KEY REFERENCES Player_Stats(Player_Stat_Id) NOT NULL
);

CREATE TABLE Team_Plays(
    TP_Id INT IDENTITY(1,1) PRIMARY KEY,
    Team_Id INT FOREIGN KEY REFERENCES Teams(Team_Id) NOT NULL,
    Team_Stat_Id INT FOREIGN KEY REFERENCES Team_Stats(Team_stat_Id) NOT NULL
);