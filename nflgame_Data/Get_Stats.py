import nflgame

#Prints player name and number
data_file = open('data.txt', 'w')

games = nflgame.games(2016)

#Gets the max_stats for each play in each game of the 2016 season and writes them to data.txt
for game in games:
    game_stats = game.max_player_stats()

    for stat in game_stats:
        data_file.write(str(stat.player))
        data_file.write(" Team: ")
        data_file.write(str(stat.team))
        data_file.write(" ")
        data_file.write(str(stat.formatted_stats()))
        data_file.write("\n")

data_file.close()
# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()