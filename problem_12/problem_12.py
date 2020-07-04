
import time
from mods import prime_sieve, prime_factorization

def generate_triangle_number(n):
    return n * (n + 1) / 2

def problem_12():
    primes = prime_sieve(100)
    n = 1
    found = False
    while not found:
        triangle_number = n*(n+1)/2
        if prime_factorization(triangle_number, primes, num_divisors=True ) > 500:
            return triangle_number
        n += 1

start = time.time()
solution = problem_12()
print(f"{solution} found in {time.time() - start} seconds.")
# 76576500.0 found in 0.06789588928222656 seconds.