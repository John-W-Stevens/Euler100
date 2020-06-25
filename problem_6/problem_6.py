# The sum of the squares of the first ten natural numbers is,
# 1^2 + 2^2 + ... + 10^2 = 385
# The square of the sum of the first ten natural numbers is,
# (1 + 2 + ... + 10)^2 = 55^2 = 3025
# Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
# Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

import time

# iterative method
def problem_6a(n):
    sum_of_squares = 0
    square_of_sum = 0
    
    for i in range(n + 1):
        sum_of_squares += i**2
        square_of_sum += i

    return square_of_sum**2 - sum_of_squares

# mathematical method
def problem_6b(n):
    sum_of_squares = n * (n + 1) * (2*n + 1) / 6
    square_of_sums = (n * (n + 1) / 2) ** 2

    return square_of_sums - sum_of_squares    

start = time.time()
solution = problem_6a(100)
print(f"{solution} found in {time.time() - start} seconds.")
# 25164150 found in 3.981590270996094e-05 seconds.

start = time.time()
solution = problem_6b(100)
print(f"{solution} found in {time.time() - start} seconds.")
# 25164150.0 found in 1.3113021850585938e-05 seconds.