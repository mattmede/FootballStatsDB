import nflgame

#Prints player name and number
data_file = open('data.txt', 'w')

players = nflgame.players
games = nflgame.games(2016)

for game in games:
    data_file.write(game)


# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()