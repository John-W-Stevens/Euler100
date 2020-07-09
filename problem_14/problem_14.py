import time

def check_chain_length(n):
    if n == 1:
        return 1
    if n in chain_table:
        return chain_table[n]
    if n % 2 == 0:
        length = check_chain_length(n//2) + 1
    else: 
        length = check_chain_length((3*n + 1)//2)+ 2
    if n < 1000000:
        chain_table[n] = length
    return length

def problem_14():
    longest_chain, number = 1,1
    for n in range(500000,1000000):
        chain_length = check_chain_length(n)
        if chain_length > longest_chain:
            longest_chain,number = chain_length, n
    return number

start = time.time()
chain_table = {}
solution = problem_14()
print(f"{solution} found in {time.time() - start} seconds.")
# 837799 found in 0.7883999347686768 seconds.