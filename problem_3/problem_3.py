# The prime factors of 13195 are 5, 7, 13 and 29.
# What is the largest prime factor of the number 600851475143 ?

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

def problem_3(n):
    lpf = 0 # largest prime factor
    if n % 2 != 0: # if n is odd then we don't need to look at even numbers
        lower, step = 3, 2
    else: # if n is even then we need to look at odd & even numbers
        lower, step = 2, 1
    for num in range(lower, int(n**0.5 + 1), step):
        if n % num == 0:
            if is_prime(n / num): # the first value that satisfies this condition is the answer
                return (int(n/num))
            if is_prime(num):
                lpf = num
            n /= num # reduce the size of the problem at each step
    return lpf


start = time.time()
solution = problem_3(600851475143)
print(f"{solution} found in {time.time() - start} seconds.")
# 6857 found in 0.0002830028533935547 seconds.
