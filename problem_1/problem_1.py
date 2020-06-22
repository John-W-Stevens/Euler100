# Problem:
# # If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
# # The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.

import time

# The iterative approach:
def problem_1a(n):
    total = 0
    for i in range(n):
        if i % 3 == 0 or i % 5 == 0:
            total += i
    return total

start = time.time()
solution = problem_1a(1000)
print(f"{solution} found in {time.time() - start} seconds.")
# 233168 found in 0.0001900196075439453 seconds.

# The mathematical approach:
def sum_arithmetic_series(a, d, n):
    """
        a: first term in series,
        d: difference between each term
        n: number of terms we want to sum 
    """
    return n/2 * (2*a + (n-1) * d)

def problem_1b(n):
    x = sum_arithmetic_series(3, 3, (n-1)//3)
    y = sum_arithmetic_series(5, 5, (n-1)//5)
    z = sum_arithmetic_series(15, 15, (n-1)//15)
    return x + y - z

start = time.time()
solution = problem_1b(1000)
print(f"{solution} found in {time.time() - start} seconds.")
# 233168.0 found in 9.059906005859375e-06 seconds.
