import nflgame

game = nflgame.games(2016, week=[1])
players = nflgame.combine(game)

for p in players:
    print p, p.formatted_stats()


#Prints player name and number
players = nflgame.players

for p in players:
    if players[p].team != "":
        print players[p].name, players[p].uniform_number



#Print team name. T is a list containing multiple versions of the name
teams = nflgame.teams
for t in teams:
    print t[0]



