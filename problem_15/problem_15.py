import time

def problem_15(m, n, memo = {}):
    if m == 1 or n == 1:
        return 1
    try:
        return memo[(m,n)]
    except KeyError:
        result = problem_15(m-1, n, memo) + problem_15(m, n-1, memo)
        memo[(m,n)] = result
        return result

start = time.time()
solution = problem_15(21,21)
print(f"{solution} found in {time.time() - start} seconds.")
# 137846528820 found in 0.0006380081176757812 seconds.