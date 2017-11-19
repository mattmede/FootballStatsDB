import nflgame

# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()


#Prints player name and number
playersFile = open('insert_players.sql', 'w')
playersFile.write("INSERT INTO Players (Player_Name, Player_Number) VALUES \n")

players = nflgame.players
count = 0
count2 = 0
insertFlag = False

for p in players:
    if players[p].team != "":
        if count2 == 1000:
            playersFile.write("\n\nINSERT INTO Players (Player_Name, Player_Number) VALUES \n")
            count2 = 0
        if count + 1 == len(players)-2 or insertFlag == True:
            player =  players[p].name.replace("'", "''")
            player_number = str(players[p].number)
            playersFile.write("('" + player + "'," + player_number + ");\n")
            count2 = count2 + 1
            insertFlag = False
        else:
            player =  players[p].name.replace("'", "''")
            player_number = str(players[p].number)
            playersFile.write("('" + player + "'," + player_number + "0),\n")
            count2 = count2 + 1
            if count2 == 999:
                insertFlag = True
    count = count + 1

playersFile.close()



#Print team name. T is a list containing multiple versions of the name
teamsFile = open('insert_teams.sql', 'w')
teamsFile.write('INSERT INTO Teams (Team_Name) VALUES \n')

teams = nflgame.teams
for t in teams[:-1]:
    teamsFile.write("('" + t[0] + "'),\n")
teamsFile.write("('" + teams[-1][0] + "');")

teamsFile.close()



