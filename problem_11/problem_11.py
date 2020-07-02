import time

def problem_11():
    grid = [ [int(n) for n in line.split(" ")] for line in open("./problem_11.txt", "r").readlines()]
    max_horizontal = max([ max([row[i] * row[i+1] * row[i+2] * row[i+3] for i in range(17)]) for row in grid ])
    max_vertical = max([ max([grid[i][j] * grid[i+1][j] * grid[i+2][j] * grid[i+3][j] for i in range(17)]) for j in range(20) ])
    max_diagonal_right = max([ max([grid[i][j] * grid[i+1][j+1] * grid[i+2][j+2] * grid[i+3][j+3] for i in range(17)]) for j in range(17) ])
    max_diagonal_left = max([ max([grid[i][j+3] * grid[i+1][j+2] * grid[i+2][j+1] * grid[i+3][j] for i in range(17)]) for j in range(17) ])

    return max( [max_horizontal, max_vertical, max_diagonal_right, max_diagonal_left] )

start = time.time()
solution = problem_11()
print(f"{solution} found in {time.time() - start} seconds.")
# 70600674 found in 0.0007121562957763672 seconds.