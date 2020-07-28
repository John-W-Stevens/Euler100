import time
from string_math import *

def sum_digits(string_number):
    return sum([int(n) for n in string_number])

def get_product_of_numbers(list_of_string_numbers):
    return reduce( (lambda a,b: multiply(a,b)), list_of_string_numbers)

def problem_20():
    first_hundred_numbers = [str(n) for n in range(1,101)]
    return sum_digits(get_product_of_numbers(first_hundred_numbers))

start = time.time()
print(f"{problem_20()} found in {time.time() - start} seconds.")
# 648 found in 0.026152849197387695 seconds.
