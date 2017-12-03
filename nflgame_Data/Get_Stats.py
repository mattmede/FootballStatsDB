import nflgame

#Prints player name and number
player_stats_file = open('player_stats.txt', 'w')
team_stats_file = open('team_stats.txt', 'w')



#Gets the max_stats for each play in each game of the 2016 season and writes them to data.txt
for week in range(1,18):

    games = nflgame.games(2016, week)
    
    for game in games:
        game_stats = game.max_player_stats()

        for stat in game_stats:
            player_stats_file.write(str(stat.player))
            player_stats_file.write(" Team: ")
            player_stats_file.write(str(stat.team))
            player_stats_file.write(" Week: ")
            player_stats_file.write(str(week))
            player_stats_file.write(" ")
            player_stats_file.write(str(stat.formatted_stats()))
            player_stats_file.write("\n")
        
        team_stats_file.write("\n")
        team_stats_file.write(str(game.home))
        team_stats_file.write(" Week: ")
        team_stats_file.write(str(week))
        team_stats_file.write(" ")
        team_stats_file.write(str(game.stats_home))
        team_stats_file.write("\n")
        team_stats_file.write(str(game.away))
        team_stats_file.write(" Week: ")
        team_stats_file.write(str(week))
        team_stats_file.write(" ")
        team_stats_file.write(str(game.stats_away))

player_stats_file.close()
# game = nflgame.games(2016, week=[1])
# players = nflgame.combine(game)

# for p in players:
#     print p, p.formatted_stats()