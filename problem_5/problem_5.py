# 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
# What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

import time

def is_prime(n):
    """ Returns Boolean """
    if n <= 1: return False
    if n == 2 or n == 3: return True
    if n % 2 == 0 or n % 3 == 0: return False
    i, w, = 5, 2
    while i * i <= n:
        if n % i == 0:
            return False
        i += w
        w = 6 - w
    return True

def prime_factorization(n):
    """ 
    Assumes n >= 2
    Returns a dict mapping the prime factors of n and their respective powers 
    """
    if is_prime(n):
        return {n: 1}
    prime_factors = {2:0, 3:0,}
    while n % 2 == 0:
        prime_factors[2] += 1
        n /= 2
    while n % 3 == 0:
        prime_factors[3] += 1
        n /= 3  
    for i in range(5, int(n**0.5)+1, 2):
        if not is_prime(i):
            continue
        while n % i == 0:
            try:
                prime_factors[i] += 1
            except KeyError:
                prime_factors[i] = 1
            n /= i
    return prime_factors        

def problem_5(n):
    """ Returns the smallest number divisible by every number <= n """
    output = 1
    prime_factor_map = {}

    for i in range(2, n+1):
        prime_factors = prime_factorization(i)
        for p,e in prime_factors.items():
            try:
                if prime_factor_map[p] < e:
                    prime_factor_map[p] = e
            except KeyError:
                prime_factor_map[p] = e

    for p,e in prime_factor_map.items():
        output *= pow(p,e)
    return output

start = time.time()
solution = problem_5(20)
print(f"{solution} found in {time.time() - start} seconds.")
# 232792560 found in 3.1948089599609375e-05 seconds.
