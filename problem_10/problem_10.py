import time
from prime_sieve import prime_sieve

def problem_10():
    return sum(prime_sieve(2000000))

start = time.time()
solution = problem_10()
print(f"{solution} found in {time.time() - start} seconds.")
# 142913828922 found in 0.07372689247131348 seconds.