import nflgame

#Prints player name and number
data_file = open('data.txt', 'w')

games = nflgame.games(2016)

count = 0

for game in games:
    game_stats = nflgame.combine_game_stats(games)

    if count == 40000:
        break


    for player in game_stats:
        
        if count == 40000:
            break

        data_file.write(player.name)
        data_file.write(" ")
        data_file.write(str(player.stats))
        data_file.write("\n")
        count = count + 1

data_file.close()
# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()