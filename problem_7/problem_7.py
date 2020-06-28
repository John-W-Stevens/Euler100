# By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
# What is the 10 001st prime number?

import time
from prime_sieve import prime_sieve

def problem_7(n, limit):
    return prime_sieve(limit)[n]

start = time.time()
solution = problem_7(10001, 150000)
print(f"{solution} found in {time.time() - start} seconds.")
# 104759 found in 0.005792140960693359 seconds.