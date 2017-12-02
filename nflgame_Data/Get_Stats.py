import nflgame

#Prints player name and number
data_file = open('data.txt', 'w')

games = nflgame.games(2016)
game_stats = nflgame.combine_play_stats(games)

# for game in games:
#     data_file.write(game.home)
#     data_file.write("\n")

for player in game_stats:
    data_file.write(player.name)
    data_file.write(" ")
    data_file.write(str(player.stats))
    data_file.write("\n")

data_file.close()
# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()