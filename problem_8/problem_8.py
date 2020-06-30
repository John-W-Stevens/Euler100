# The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
# Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?

# We are given a 20 by 50 (height by width) grid


import time
from functools import reduce
from queue import LifoQueue, Queue

def problem_8():
    number = [int(n) for n in open("./problem_8.txt", "r").read() if n != "\n"]
    max_product = 0

    for i in range(len(number) - 13):
        product = reduce( (lambda a,b:a*b), number[i:i+13])
        if product > max_product:
            max_product = product
            
    return max_product

start = time.time()
solution = problem_8()
print(f"{solution} found in {time.time() - start} seconds.")
# 23514624000 found in 0.003715038299560547 seconds.
