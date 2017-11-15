import nflgame

game = nflgame.games(2016, week=[1])
players = nflgame.combine(game)

for p in players:
    print p, p.formatted_stats()