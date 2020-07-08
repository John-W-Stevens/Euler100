import time
from functools import reduce

# Easy way -> cast string to integers
def easy_peezy():
    return str(sum([int(n) for n in open("./problem_13.txt", "r").read().split("\n")]))[0:10]    
print(easy_peezy()) # Output -> 5537376230

# The way that works in JavaScript & C# ->
def add(n1, n2):
    """
    Adds two strings of digits representing numbers
    """
    # ensure n1 is the longest
    if len(n2) > len(n1):
        n1, n2 = n2, n1

    diff = len(n1) - len(n2)
    n1 = list(n1)
    n2 = ["0"] * diff + list(n2)
    # output
    output = ["0"] * (len(n1) + 1)

    carry_over = 0
    for i in range(len(n1)-1, -1, -1):
        s = int(n1[i]) + int(n2[i]) + carry_over
        carry_over = 0
        if s > 9:
            s = str(s)
            carry_over = int(s[0])
            output[i+1] = s[1]
        else:
            output[i+1] = str(s)
    if carry_over != 0:
        output[0] = str(carry_over)

    j = 0
    while output[j] == "0":
        j += 1        
    return "".join(output[j::])

def problem_13():
    numbers = [n for n in open("./problem_13.txt", "r").read().split("\n")]
    return reduce( (lambda a,b: add(a,b)), numbers)[0:10]

start = time.time()
solution = problem_13()
print(f"{solution} found in {time.time() - start} seconds.")
# 5537376230 found in 0.005017280578613281 seconds.