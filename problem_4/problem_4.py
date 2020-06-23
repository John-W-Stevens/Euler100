# A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
# Find the largest palindrome made from the product of two 3-digit numbers.

import time

def is_pal(astring):
    return astring == astring[::-1]

def problem_4():
    largest_pal = 0
    for i in range(999, 100, -1):
        for j in range(i, 100, -1):
            number = i * j
            if number < largest_pal: # optimization 1
                break
            if number % 11 != 0: # optimization 2
                continue
            if is_pal(f"{number}"):
                largest_pal = number
    return largest_pal

start = time.time()
solution = problem_4()
print(f"{solution} found in {time.time() - start} seconds.")
# 906609 found in 0.001230001449584961 seconds.